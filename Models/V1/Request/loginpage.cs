namespace WMSWebAPI.Models.V1.Request
{
    public class GetloginRequest
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
    public class ResetPasswordRequest1
    {
        public string UserName { get; set; }
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
        public string UserID { get; set; }
    }
    public class ForgetPasswordRequest
    {
        public string EmailID { get; set; }
        public string UserName { get; set; }
    }

    public class reqOTP
    {
        public string EmailID { get; set; }
        public string UserName { get; set; }
        public string OTP { get; set; }
    }

    public class changePassword
    {
        public string EmailID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }

    public class checkUserName
    {
        public string EmailID { get; set; }
        public string UserName { get; set; }
    }
}
