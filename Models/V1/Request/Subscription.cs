using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
namespace WMSWebAPI.Models.V1.Request
{
    //public class RegistrationDetaills
    //{
    //    public string CompanyName { get; set; }
    //    public string Website { get; set; }
    //    public string EmailID { get; set; }
    //    public string Address { get; set; }
    //    public string Country { get; set; }
    //    public string Landmark { get; set; }
    //    public string State { get; set; }
    //    public string City { get; set; }
    //    public string ZipCode { get; set; }
    //    public string PhoneNo { get; set; }
    //    public string Logopath { get; set; }
    //    public string FirstName { get; set; }
    //    public string LastName { get; set; }
    //    public string UserEmail { get; set; }
    //    public string UserName { get; set; }         
    //}
    public class RegistrationDetaills
    {
        public string CompanyName { get; set; }
        public string Website { get; set; }
        public string EmailID { get; set; }
        public string Address { get; set; }
        public string Country { get; set; }
        public string Landmark { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        public string PhoneNo { get; set; }
        public string Logopath { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserEmail { get; set; }
        public string UserName { get; set; }
        public string PlanID { get; set; }
        public string PaymentId { get; set; }
        public string CustSubHeadId { get; set; }
        public string TransactionReference { get; set; }
        public string PeriodType { get; set; }

    }
    public class SubReqCheckUsername
    {
        public string UserName { get; set; }
    }
    public class UpdateTransactionRequest
    {
        public string OrderId { get; set; }
        public string CompanyId { get; set; }
        public string CustomerId { get; set; }
        public string Discount { get; set; }
        public string TotalAmount { get; set; }
        public string TransactionID { get; set; }
        public string TransactionID1 { get; set; }
        public string TransactionID2 { get; set; }
    }
    public class ChecklimitRequest
    {
        public string CompanyId { get; set; }
    }

    public class ReqGetSubscription
    {
        public long CompanyID { get; set; }
        public long CustomerID { get; set; }
        public long UserID { get; set; }
    }

    public class ReqGetSubscriptionPlans
    {
        public string PlanCode { get; set; }
    }

    public class ReqGetInvoiceRpt
    {
        public long CompanyID { get; set; }
        public long CustomerID { get; set; }
        public long InvoiceID { get; set; }
    }

    public class ReqGetInvoiceDetails
    {
        public long CompanyID { get; set; }
        public long CustomerID { get; set; }
        public long UserID { get; set; }
        public string PlanCode { get; set; }
        public string PlanTitle { get; set; }

    }

    public class ReqAddDummyData
    {
        public long companyid { get; set; }
        public long userid { get; set; }
        public long customerid { get; set; }
    }

    public class ReqCheckDummyData
    {
        public long CompanyID { get; set; }
        public long CustomerID { get; set; }
        public long UserID { get; set; }
    }

    public class ReqRemoveDummyData
    {
        public long CompanyID { get; set; }
        public long CustomerID { get; set; }
        public long UserID { get; set; }
    }

    public class ReqSaveSubscribePlan
    {
        public long CompanyID { get; set; }
        public long CustomerID { get; set; }
        public long UserID { get; set; }
        public long PlanID { get; set; }
        public decimal PlanAmount { get; set; }
        public decimal Discount { get; set; }
        public decimal TotalTax { get; set; }
        public string TransactionNo { get; set; }
        public string paymentmethod { get; set; }

    }

    public class ContactUsForm
    {
        public string CompanyName { get; set; }
        public string ContactPerson { get; set; }
        public string EmailID { get; set; }
        public string ContactNo { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string PlanDetails { get; set; }

    }

    public class CheckSubscription
    {
        public long CompanyID { get; set; }
        public long CustomerID { get; set; }
        public long UserID { get; set; }
    }

    public class getWarehouseIDandName
    {
        public long CompanyID { get; set; }
        public long CustomerID { get; set; }
        public long UserID { get; set; }
    }

}
