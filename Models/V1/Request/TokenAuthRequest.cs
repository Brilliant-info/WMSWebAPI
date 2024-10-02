namespace WMSWebAPI.Models.V1.Request
{
    public class AuthApiAccessRequest
    {
        public string UserID { get; set; }
        public string Token { get; set; }
    }
    public class SaveNewTokenAuthRequest
    {
        public string Token { get; set; }
        public string UserID { get; set; }
        public string UserName { get; set; }
        public string CompanyID { get; set; }
        public string CustomerId { get; set; }
    }
    public class CloseTokenAuthRequest
    {
        public string Token { get; set; }
        public string UserID { get; set; }
        public string CompanyID { get; set; }
    }
    public class GetActiveTokenForUserRequest
    {
        public string UserID { get; set; }
    }
    /* API to lock and unlock user sessions - 06 Dec 2023 */
    public class CloseUserSessionsRequest
    {
        public string RequesterUserId { get; set; }
        public string UserName { get; set; }
        public string SessionUserId { get; set; }
        public string SessionCompanyId { get; set; }
    }
}
