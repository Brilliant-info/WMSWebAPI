namespace WMSWebAPI.Models.V1.Request
{
    public class getEmailSmsList
    {
        public string UserId { get; set; }
        public string CustomerID { get; set; }
        public string WarehouseID { get; set; }

    }
    public class getEmailSmSActive
    {
        public string TemplateID { get; set; }
        public string UserID { get; set; }
        public string CustomerID { get; set; }
        public string CompanyID { get; set; }
        public string WarehouseID { get; set; }
        public string Email { get; set; }
        public string SMS { get; set; }
        public string whatsup { get; set; }

    }
    public class getEmailSMSTemplate
    {
        public string EmailTemplateID { get; set; }
        public string WarehouseID { get; set; }
        public string CompanyID { get; set; }
        public string UserID { get; set; }
        public string CustomerID { get; set; }
        public string Application { get; set; }

    }

    public class GetSaveEmailSMS
    {
        public string EmailTemplateID { get; set; }
        public string WarehouseID { get; set; }
        public string CompanyID { get; set; }
        public string UserID { get; set; }
        public string CustomerID { get; set; }
        public string Application { get; set; }
        public string AddEmail { get; set; }


    }
    public class GetroleSaveEmailSMS
    {
        public string EmailTemplateID { get; set; }
        public string WarehouseID { get; set; }
        public string CompanyID { get; set; }
        public string UserID { get; set; }
        public string CustomerID { get; set; }
        public string Application { get; set; }
        public string AddRole { get; set; }


    }
    public class GetRemoveEmailSMS
    {
        public string EmailTemplateID { get; set; }
        public string WarehouseID { get; set; }
        public string CompanyID { get; set; }
        public string UserID { get; set; }
        public string CustomerID { get; set; }
        public string Application { get; set; }
        public string AddEmail { get; set; }

    }
    public class GetRoleRemoveEmailSMS
    {
        public string EmailTemplateID { get; set; }
        public string WarehouseID { get; set; }
        public string CompanyID { get; set; }
        public string UserID { get; set; }
        public string CustomerID { get; set; }
        public string Application { get; set; }
        public string AddRole { get; set; }

    }
}
