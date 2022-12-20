using LOFI.ApiMomoModel;
using LOFI.Helpers;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Web;

namespace LOFI.Data;

public class MomoClass
{
    private readonly HttpClientHandler handler;
    private readonly HttpClient _client;
    /*
     * Constructeur de classe 
     */
    public MomoClass()
    {
        handler = new HttpClientHandler
        {
            ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => { return true; }
        };
        _client = new HttpClient(handler);
    }
    public async Task<bool> createUser(string unique_ref, UserCreateModel userCreateModel)
    {
        // Request headers
        _client.DefaultRequestHeaders.Add("X-Reference-Id", $"{unique_ref}");
        _client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", $"{Links.subscription_key_remittance}");

        string json = JsonConvert.SerializeObject(userCreateModel);
        HttpContent content = new StringContent(json);
        content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
        HttpResponseMessage response = await _client.PostAsync(Links.urlApiUser, content);

        if(!response.IsSuccessStatusCode)
        {
            clearPreferences();
            return false;
        }
        return true;
    }
    //Cette fonction permet de créer une clé d'api pour l'utilisateur identifier
    public async Task<string> CreateApiKey(string unique_ref)
    {
        var client = new HttpClient();
        var queryString = HttpUtility.ParseQueryString(string.Empty);

        // Request headers
        client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", $"{Links.subscription_key_remittance}");

        HttpContent content = new StringContent("");
        content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
        HttpResponseMessage response = await _client.PostAsync(Links.urlApiUser +$"/{unique_ref}/apikey", content);

        if (response.IsSuccessStatusCode)
        {
            var getResult = JObject.Parse(await response.Content.ReadAsStringAsync());
            string key = getResult["apiKey"].ToString();

            var result = await CreateAccessToken(unique_ref, key);

            if (result)
            {
                return key;
            }
            return string.Empty;
        }
        clearPreferences();
        return string.Empty;
    }

    private void clearPreferences()
    {
        Preferences.Remove("uuid");
        Preferences.Remove("apikey");

        Preferences.Remove("basicid");
        Preferences.Remove("basicidExpire");
        Preferences.Remove("basicidInt");

        Preferences.Remove("accessToken");
        Preferences.Remove("tokenType");
        Preferences.Remove("tokenExpire");

    }

    // Authentification basique sur le serveur concerné
    //public async Task<bool> CreateBasicAuth(string unique_ref, string apiKey)
    //{
    //    string stringToEncode = unique_ref + ":" + apiKey;

    //    string EncodedString = Links.EncodeTo64(stringToEncode);

    //    // Request headers
    //    _client.DefaultRequestHeaders.Add("Authorization", $"Basic {EncodedString}");
    //    //_client.DefaultRequestHeaders.Add("X-Callback-Url", "");
    //    _client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", $"{Links.subscription_key_remittance}");
    //    _client.DefaultRequestHeaders.Add("X-Target-Environment", $"{Links.targetEnvironment}");

    //    HttpContent content = new StringContent("");
    //    content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
    //    HttpResponseMessage response = await _client.PostAsync(Links.r_basic_auth, content);

    //    if (response.IsSuccessStatusCode)
    //    {
    //        var data = JsonConvert.DeserializeObject<AuthModel>(await response.Content.ReadAsStringAsync());
    //        Preferences.Set("basicid", data.auth_req_id);
    //        Preferences.Set("basicidExpire", data.expires_in);
    //        Preferences.Set("basicidInt", data.interval);

    //        return true;
    //    }
    //    clearPreferences();
    //    return false;
    //}
    //Créer du jeton d'accès aux différentes transactions
    public async Task<bool> CreateAccessToken(string auth, string key)
    {
        string stringToEncode = auth + ":" + key;
        string EncodedString = Links.EncodeTo64(stringToEncode);
        // Request headers
        _client.DefaultRequestHeaders.Add("Authorization", $"Basic {EncodedString}");
        _client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", $"{Links.subscription_key_remittance}");

        HttpResponseMessage response;

        // Request body
        byte[] byteData = Encoding.UTF8.GetBytes("{body}");

        using (var content = new ByteArrayContent(byteData))
        {
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            response = await _client.PostAsync(Links.r_token, content);
        }

        if (response.IsSuccessStatusCode)
        {
            var getResult = JObject.Parse(await response.Content.ReadAsStringAsync());
            string access_token = getResult["access_token"].ToString();
            string token_type = getResult["token_type"].ToString();
            string expires_in = getResult["expires_in"].ToString();

            Preferences.Set("accessToken", access_token);
            Preferences.Set("tokenType", token_type);
            Preferences.Set("tokenExpire", expires_in);

            return true;
        }

        clearPreferences();
        return false;
    }



}
