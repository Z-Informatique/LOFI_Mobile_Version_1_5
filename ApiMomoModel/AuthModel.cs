

namespace LOFI.ApiMomoModel;

public class AuthModel
{
    public string auth_req_id { get; set; }
    public int interval { get; set; }
    public int expires_in { get; set; }
}

public class AuthToken
{
    public string access_token { get; set; }
    public string token_type { get; set; }
    public int expires_in { get; set; }
}