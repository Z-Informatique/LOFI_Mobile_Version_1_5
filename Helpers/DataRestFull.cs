using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace LOFI.Helpers
{
    public class DataRestFull<T>
    {
        private readonly string _weburl;
        private readonly HttpClient _client = new HttpClient();
        public DataRestFull(string url)
        {
            _weburl = url;
        }
        public async Task<List<T>> GetAsync()
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Settings.Token);
            string json = await _client.GetStringAsync(_weburl);
            List<T> taskModels = JsonConvert.DeserializeObject<List<T>>(json);
            return taskModels;
        }
        public async Task<ObservableCollection<T>> GetAsyncObservable()
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Settings.Token);
            string json = await _client.GetStringAsync(_weburl);
            ObservableCollection<T> taskModels = JsonConvert.DeserializeObject<ObservableCollection<T>>(json);
            return taskModels;
        }
        public async Task<T> ChangePassword(string telephone, string currentPassword, string password)
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Settings.Token);
            string json = await _client.GetStringAsync(_weburl + $"/ChangePassword?telephone={telephone}&current={currentPassword}&password={password}");
            T userModel = JsonConvert.DeserializeObject<T>(json);
            return userModel;
        }
        public async Task<bool> Delete(int Id)
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Settings.Token);
            HttpResponseMessage result = await _client.DeleteAsync(_weburl + $"/{Id}");
            return result.IsSuccessStatusCode;
        }
        public async Task<List<T>> GetDataByIdAsync(string parameter, int Id)
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Settings.Token);
            string json = await _client.GetStringAsync(_weburl + $"/{parameter}={Id}");
            List<T> taskModels = JsonConvert.DeserializeObject<List<T>>(json);
            return taskModels;
        }

        public async Task<T> GetDataByParameter(string url)
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Settings.Token);
            string json = await _client.GetStringAsync(_weburl + $"/{url}");
            T modelData = JsonConvert.DeserializeObject<T>(json);
            return modelData;
        }

        public async Task<List<T>> GetDataListByParameter(string urlParameter)
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Settings.Token);
            string json = await _client.GetStringAsync(_weburl + $"/{urlParameter}");
            List<T> taskModels = JsonConvert.DeserializeObject<List<T>>(json);
            return taskModels;
        }
        public async Task<ObservableCollection<T>> GetDataListByParameterObs(string urlParameter)
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Settings.Token);
            string json = await _client.GetStringAsync(_weburl + $"/{urlParameter}");
            ObservableCollection<T> taskModels = JsonConvert.DeserializeObject<ObservableCollection<T>>(json);
            return taskModels;
        }
        public async Task<T> VerifyUser(string email, string telephone)
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Settings.Token);
            string json = await _client.GetStringAsync(_weburl + $"/VerifUser?email={email}&telephone={telephone}");
            T taskModels = JsonConvert.DeserializeObject<T>(json);
            return taskModels;
        }
        public async Task<T> PutAsync(int Id, T t)
        {
            string json = JsonConvert.SerializeObject(t);
            HttpContent content = new StringContent(json);

            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Settings.Token);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            HttpResponseMessage response = await _client.PutAsync(_weburl + "/" + Id, content);
            T data = JsonConvert.DeserializeObject<T>(await response.Content.ReadAsStringAsync());
            return data;
        }
        public async Task<T> PutAsyncByUrl(string urlParameter, int Id, T t)
        {
            string json = JsonConvert.SerializeObject(t);
            HttpContent content = new StringContent(json);

            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Settings.Token);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            HttpResponseMessage response = await _client.PutAsync(_weburl + $"/{urlParameter}/" + Id, content);
            T data = JsonConvert.DeserializeObject<T>(await response.Content.ReadAsStringAsync());
            return data;
        }
        public async Task<T> GetById(int Id)
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Settings.Token);
            string result = await _client.GetStringAsync(_weburl + $"/{Id}");
            T t = JsonConvert.DeserializeObject<T>(result);
            return t;
        }
        public async Task<T> GetDataByString(string data)
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Settings.Token);
            string result = await _client.GetStringAsync(_weburl + $"/GetData?data={data}");
            T t = JsonConvert.DeserializeObject<T>(result);
            return t;
        }
        public async Task<T> GetDataByTwoIntParameter(int IdOne, int IdTwo)
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Settings.Token);
            string result = await _client.GetStringAsync(_weburl + $"/GetData?IdOne={IdOne}&IdTwo={IdTwo}");
            T t = JsonConvert.DeserializeObject<T>(result);
            return t;
        }
        public async Task<decimal> getDataDecimal(string route)
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Settings.Token);
            string result = await _client.GetStringAsync(_weburl + $"/{route}");
            decimal count = JsonConvert.DeserializeObject<decimal>(result);
            return count;
        }
        public async Task<int> CountAllData(string route)
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Settings.Token);
            string result = await _client.GetStringAsync(_weburl + $"/{route}");
            int count = JsonConvert.DeserializeObject<int>(result);
            return count;
        }
        public async Task<T> Login(string telephone, string password)
        {
            string result = await _client.GetStringAsync(_weburl + $"/Login?Telephone=" + telephone + "&" + "Password=" + password);
            T t = JsonConvert.DeserializeObject<T>(result);
            return t;
        }
        public async Task<T> PostAsync(T t)
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Settings.Token);
            string json = JsonConvert.SerializeObject(t);
            HttpContent content = new StringContent(json);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            HttpResponseMessage response = await _client.PostAsync(_weburl, content);
            T data = JsonConvert.DeserializeObject<T>(await response.Content.ReadAsStringAsync());
            return data;
        }
        public async Task<T> GetUserByAccesstokenAsync(string accesstoken)
        {
            //_client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Settings.Token);
            string result = await _client.GetStringAsync(_weburl + $"/GetUserByAccesstoken?token=" + accesstoken);
            T returnedUser = JsonConvert.DeserializeObject<T>(result);
            return returnedUser;
        }
    }
}
