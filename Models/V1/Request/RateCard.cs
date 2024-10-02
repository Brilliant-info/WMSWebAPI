using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WMSWebAPI.Models.V1.Request
{
    public class GetRateCardListRequest
    {
        public string CurrentPage { get; set; }
        public string RecordLimit { get; set; }
        public string CustomerId { get; set; }
        public string UserId { get; set; }
        public string Filter { get; set; }
        public string Search { get; set; }
    }
    public class GetUnitTypeRequest
    {
        public string CompanyId { get; set; }
        public string UserId { get; set; }

    }
    public class GetAccNameRequest
    {
        public string ActivityType { get; set; }
        public string CompanyId { get; set; }
        public string UserId { get; set; }

    }
    public class GetActivtyTypeRequest
    {
        public string CurrentPage { get; set; }
        public string RecordLimit { get; set; }
        public string CustomerId { get; set; }
        public string UserId { get; set; }
        public string Filter { get; set; }
        public string Search { get; set; }

    }
    public class GetObjectZoneRequest
    {
        public string CustomerId { get; set; }
        public string UserId { get; set; }

    }
    public class AddZoneRequest
    {
        public string CompanyId { get; set; }
        public string UserId { get; set; }
        public string CustomerId { get; set; }
        public string ID { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string ZoneCode { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string ZoneName { get; set; }
    }
    public class AddRateActivtyRequest
    {
        public string CompanyId { get; set; }
        public string UserId { get; set; }
        public string CustomerId { get; set; }
        public string ObjectID { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string ActivityName { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string Remark { get; set; }
        public string ZoneId { get; set; }
    }
    public class AddRateCardRequest
    {
        public string ID { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string AccountType { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string AccountName { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string AccountTypeID { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string ActivityTypeID { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string ERPCode { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string RateTitle { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string Rate { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string RateForUnit { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string UnitTypeID { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string BillFrequency { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string BillMethodID { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string BillGroup { get; set; }
        public string CompanyID { get; set; }
        public string UserID { get; set; }

    }
    public class GetRateDetailRequest
    {
        public string ID { get; set; }
    }
    public class UpdateRateGroupRequest
    {
        public string ID { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string BillGroup { get; set; }
        public string UserId { get; set; }
    }
    public class UpdateRateActiveRequest
    {
        public string ID { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string Active { get; set; }
        public string UserId { get; set; }
    }
    public class GetRateParameterListRequest
    {
        public string RateId { get; set; }
        public string UserId { get; set; }

    }
    public class GetRateParameterRequest
    {
        public string CompanyId { get; set; }
        public string UserId { get; set; }

    }
    public class AddRateParameterRequest
    {
        public string ID { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string RateID { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string ParameterID { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string Value { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string From { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string To { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string FromDate { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string ToDate { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string EffectiveDate { get; set; }
        public string CustomerID { get; set; }
        public string CompanyID { get; set; }
        public string UserID { get; set; }

    }
    public class GetRateParameterbyIdRequest
    {
        public string ID { get; set; }
    }
    public class GetRateHistoryRequest
    {
        public string RateID { get; set; }
    }
}
