namespace WMSWebAPI.Models.V1.Request
{
    public class DemandPortalClass
    {
    }
    public class reqEmailOtp
    {
        public string Email { get; set; }
        public string OTP { get; set; }
    }
    public class emailParaD
    {
        public string Email_host { get; set; }
        public string Email_password { get; set; }
        public string Email_port { get; set; }
        public string from { get; set; }
    }
    public class reqOTPValidate
    {
        public string Email { get; set; }
        public string Otp { get; set; }
    }
    public class reUserRegister
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string MobileNo { get; set; }
        public string EmployeeNo { get; set; }
        public string ClientID { get; set; }
        public string ClientName { get; set; }
        public string UserType { get; set; }
        public string Zipcode { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        //public string CompanyID { get; set; }
    }
    public class reqLogin
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }

    public class reqForgotPass
    {
        public string EmailId { get; set; }
        public string OTP { get; set; }
    }
    public class reqValidateEmailPass
    {
        public string EmailId { get; set; }
    }

    public class reqResetPassword
    {
        public string OTP { get; set; }
    }

    public class setNewPassword
    {
        public string newPassword { get; set; }
        public string Email { get; set; }
    }
    public class reqUserList
    {
        public string ClientId { get; set; }
        public string recordLimit { get; set; }
        public string CurrentPage { get; set; }
        public string SerchPara { get; set; }
        public string SerchVal { get; set; }
        public string UserId { get; set; }
    }
    public class reqApporveUser
    {
        public string UserId { get; set; }
        public string ObjectName { get; set; }

    }
    public class reqcheckUserName
    {
        public string Username { get; set; }

    }
    public class reqTemplateList
    {
        public string UserId { get; set; }
        public string ClientId { get; set; }
    }
    public class createTemplate
    {
        public string Id { get; set; }
        public string OrderId { get; set; }
        public string UserId { get; set; }
        public string OrderRefNo { get; set; }
        public string ClientId { get; set; }
        public string CustomerId { get; set; }
        public string CompanyId { get; set; }
        public string Title { get; set; }
        public string flag { get; set; }
        public string OrderJson { get; set; }
        public string OrderHead { get; set; }
    }
    public class RemoveTemplate
    {
        public string TemplateID { get; set; }
        public string OrderID { get; set; }
        public string UserID { get; set; }
        public string flag { get; set; }

    }
    public class viewWMSOrderDetails
    {
        public string OrderId { get; set; }

    }
    public class approveOrderDisp
    {
        public string UserId { get; set; }
        public string OrderId { get; set; }
        public string ClientId { get; set; }
        public string WarehouseId { get; set; }
        public string Remkar { get; set; }
        public string OrderStatus { get; set; }
        public string Email { get; set; }
        public string ReasonText { get; set; }
    }
    public class viewDispatchOrder
    {
        public string OrderId { get; set; }

    }
    public class saveTemplateOrder
    {
        public string OrderRefNo { get; set; }
        public string OrderId { get; set; }
        public string UserId { get; set; }
        public string ClientId { get; set; }
        public string CustomerId { get; set; }
        public string WarehouseId { get; set; }

    }
    public class ReqReasonList
    {
        public string UserId { get; set; }

    }
    public class ReqRejectOrderList
    {
        public string ReasonId { get; set; }
        public string Remark { get; set; }
        public string OrderId { get; set; }
        public string Email { get; set; }
    }

    public class reqSalesOrder
    {
        public string OrderId { get; set; }
    }

    public class ReqSalesOrders
    {
        public string BillBlock { get; set; }
        public string SaleDocumentNo { get; set; }
        public string CustRefDate { get; set; }
        public string DocType { get; set; }
        public string ReqDelivDate { get; set; }
        public string PriceDate { get; set; }
        public string SalesOrg { get; set; }
        public string DistrChan { get; set; }
        public string DocumentDate { get; set; }
        public string Division { get; set; }

        public List<SaleOrderItemSet> SaleOrderItemSet;
        public List<SaleOrderPartnerSet> SaleOrderPartnerSet;
        public List<ReturnMessageSet> ReturnMessageSet;
    }
    public class SaleOrderItemSet
    {
        public string ItemNumber { get; set; }
        public string Paytterms { get; set; }
        public string Material { get; set; }
        public string Plant { get; set; }
        public string StoreLocation { get; set; }
        public string TargetQty { get; set; }
        public string TargetQu { get; set; }
    }

    public class SaleOrderPartnerSet
    {
        public string Name { get; set; }
        public string PartnerRole { get; set; }
        public string PartnerNumber { get; set; }
        public string ItemNumber { get; set; }
    }
    //public class ReturnMessageSet
    //{

    //}
    public class reqTemplateView
    {
        public string TemplateID { get; set; }
        public string ClinetId { get; set; }
        public string CustomerId { get; set; }
        public string WarehouseId { get; set; }
        public string UserId { get; set; }
    }

    public class reqTopFiveOrderList
    {
        public string UserId { get; set; }
    }
    public class reqDropdownList
    {
        public string UserId { get; set; }
    }
    public class reqDeleteOrderId
    {
        public string UserId { get; set; }
        public string OrderId { get; set; }
    }

    public class reqUserReport
    {
        public string Object { get; set; }
    }
}
