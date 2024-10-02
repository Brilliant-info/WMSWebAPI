using System.ComponentModel.DataAnnotations;

namespace WMSWebAPI.Models.V1.Request
{
    public class GetCustomerListRequest
    {
        public string CurrentPage { get; set; }
        public string RecordLimit { get; set; }
        public string CompanyId { get; set; }
        public string UserId { get; set; }
        public string Filter { get; set; }
        public string Search { get; set; }
    }
    public class AddCustomerRequest
    {
        public string CompanyId { get; set; }
        public string UserId { get; set; }
        public string CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerCode { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string City { get; set; }
        public string Address { get; set; }
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string Zipcode { get; set; }
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string Landmark { get; set; }
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string MobileNo { get; set; }
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string EmailID { get; set; }
        // public string FaxNo { get; set; }
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string Website { get; set; }
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string ManufacturingCode { get; set; }
        public string Active { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string logopath { get; set; }
        public byte logo { get; set; }
    }
    public class ShowWarehouseRequest
    {
        public string CompanyId { get; set; }
        public string UserId { get; set; }
        public string CustomerId { get; set; }
        public string Skey { get; set; }



    }
    public class SelectWarehouseRequest
    {
        public string CompanyId { get; set; }
        public string UserId { get; set; }
        public string WarehouseId { get; set; }
        public string CustomerId { get; set; }

    }
    public class RemoveWarehouseRequest
    {
        public string CompanyId { get; set; }
        public string UserId { get; set; }
        public string WarehouseId { get; set; }
        public string CustomerId { get; set; }

    }
    public class reqLottableCutomer
    {
        public string CustomerID { get; set; }
        public string CompanyID { get; set; }
        public string Lottable { get; set; }
        public string Active { get; set; }
    }
    public class EditCustomerRequest
    {
        public string UserId { get; set; }
        public string CID { get; set; }
    }

    public class AssginCustomerWarehouseRequest
    {
        public string UserId { get; set; }
        public string CustomerID { get; set; }
        public string CompanyId { get; set; }
        public string WarehouseId { get; set; }
    }

    public class getcompanyRequest
    {
        public long UserID { get; set; }

    }
    public class reqCustomerDemandOtp
    {
        public string Email { get; set; }
        public string OTP { get; set; }
        public string Active { get; set; }
        public string CustomerID { get; set; }
        public string WarehouseId { get; set; }
        public string UserId { get; set; }
    }
    public class reqValidateOTP
    {
        public string Email { get; set; }
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string OTP { get; set; }
        public string CustomerId { get; set; }
        public string UserId { get; set; }

    }
    public class reqSendLink
    {
        public string ActivationLink { get; set; }
        public string Email { get; set; }
        public string CustomerID { get; set; }
        public string UserId { get; set; }
        public string WarehouseId { get; set; }
        public string CompanyId { get; set; }
    }
    public class reqPickDropList
    {
        public string CustomerID { get; set; }
        public string UserId { get; set; }
        public string WarehouseId { get; set; }
        public string CompanyId { get; set; }
    }
    public class GetDispDemandActivationLinkRequest
    {
        public long CompanyId { get; set; }
        public long CustomerId { get; set; }
        public long WarehouseId { get; set; }
        public long UserId { get; set; }


    }
    public class reqSaveDemandObject
    {
        public string Obj { get; set; }
        public string point { get; set; }
        public string CustomerID { get; set; }
        public string WarehouseId { get; set; }
        public string CompanyId { get; set; }
        public string UserId { get; set; }
    }

    public class reqDemandObjectList
    {
        public string Obj { get; set; }
        public string CustomerId { get; set; }
        public string WarehouseId { get; set; }
        public string UserId { get; set; }
        public string CompanyId { get; set; }

    }
    public class reqRemoveObjPoint
    {
        public string ObjectId { get; set; }
        public string Obj { get; set; }
        public string CustomerId { get; set; }
        public string WarehouseId { get; set; }
        public string CompanyId { get; set; }
        public string UserId { get; set; }
    }
    public class reqLottableCustomerList
    {
        public string CustomerID { get; set; }
        public string CompanyID { get; set; }
        public string UserId { get; set; }

    }
    public class reqLottablesavelist
    {
        public string CustomerID { get; set; }
        public string CompanyID { get; set; }
        public string UserId { get; set; }

    }
    //public sealed class HttpPostedFile
    //{
    //    public string FileName { get; }
    //    public string ContentType { get; }
    //    public int ContentLength { get; }
    //    public Stream InputStream { get; }

    //    //public void SaveAs(string filename);
    //}

    public class emailParaC
    {
        public string Email_host { get; set; }
        public string Email_password { get; set; }
        public string Email_port { get; set; }
        public string from { get; set; }
    }
}
