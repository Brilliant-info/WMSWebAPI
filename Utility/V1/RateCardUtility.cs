using Newtonsoft.Json.Linq;
using System;
using System.Data.SqlClient;
using System.Text.Json;
using WMSWebAPI.Models.V1.Request;

namespace WMSWebAPI.Utility.V1
{
    public class RateCardUtility
    {
        SqlParameter[] param;
        DBActivity obj;
        public RateCardUtility()
        {
            obj = new DBActivity();
        }
        public async Task<JsonElement> RateCardList(GetRateCardListRequest req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@CurrentPage", Int64.Parse(req.CurrentPage)),
                        new SqlParameter("@RecordLimit", Int64.Parse(req.RecordLimit)),
                        new SqlParameter("@CustomerId", Int64.Parse(req.CustomerId)),
                        new SqlParameter("@UserId", Int64.Parse(req.UserId)),
                        new SqlParameter("@Search", req.Search),
                        new SqlParameter("@Filter", req.Filter)
                    };
            return await obj.ConvertDataSetToJObject(obj.Return_DataSet("RateCardList", param));

        }
        public async Task<JsonElement> UnitTypeBillingMethod(GetUnitTypeRequest req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@CompanyId", Int64.Parse(req.CompanyId)),
                        new SqlParameter("@UserId", Int64.Parse(req.UserId))
                    };
            return await obj.ConvertDataSetToJObject(obj.Return_DataSet("GetUnitTypeBillmethod", param));

        }
        public async Task<JsonElement> AccountName(GetAccNameRequest req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@Acctype", req.ActivityType),
                        new SqlParameter("@CompanyId", Int64.Parse(req.CompanyId)),
                        new SqlParameter("@UserId", Int64.Parse(req.UserId))
                    };
            return await obj.ConvertDataSetToJObject(obj.Return_DataSet("GetAccName", param));

        }
        public async Task<JsonElement> ActivityTypeList(GetActivtyTypeRequest req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@CurrentPage", Int64.Parse(req.CurrentPage)),
                        new SqlParameter("@RecordLimit", Int64.Parse(req.RecordLimit)),
                        new SqlParameter("@CustomerId", Int64.Parse(req.CustomerId)),
                        new SqlParameter("@UserId", Int64.Parse(req.UserId)),
                        new SqlParameter("@Search", req.Search),
                        new SqlParameter("@Filter", req.Filter)
                    };
            return await obj.ConvertDataSetToJObject(obj.Return_DataSet("GetActivityType", param));

        }
        public async Task<JsonElement> ObjectZone(GetObjectZoneRequest req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@CustomerId", Int64.Parse(req.CustomerId)),
                        new SqlParameter("@UserId", Int64.Parse(req.UserId))
                    };
            return await obj.ConvertDataSetToJObject(obj.Return_DataSet("GetObjectZone", param));

        }
        public async Task<JsonElement> Zone(GetObjectZoneRequest req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@CustomerId", Int64.Parse(req.CustomerId)),
                        new SqlParameter("@UserId", Int64.Parse(req.UserId))
                    };
            return await obj.ConvertDataSetToJObject(obj.Return_DataSet("GetZone", param));

        }
        public string AddZone(AddZoneRequest req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@ID", Int64.Parse(req.ID)),
                        new SqlParameter("@zonecode", req.ZoneCode),
                        new SqlParameter("@zonename", req.ZoneName),
                        new SqlParameter("@companyid", Int64.Parse(req.CompanyId)),
                        new SqlParameter("@customerid", Int64.Parse(req.CustomerId)),
                        new SqlParameter("@userid", Int64.Parse(req.UserId))
                    };
            return obj.Return_ScalerValue("SaveZone", param);
        }
        public string AddRateCard(AddRateCardRequest req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@ID", Int64.Parse(req.ID)),
                        new SqlParameter("@acctype", req.AccountType),
                        new SqlParameter("@accountid", Int64.Parse(req.AccountTypeID)),
                        new SqlParameter("@accname", req.AccountName),
                        new SqlParameter("@acttypeid", Int64.Parse(req.ActivityTypeID)),
                        new SqlParameter("@erpcode", req.ERPCode),
                        new SqlParameter("@ratetitle", req.RateTitle),
                        new SqlParameter("@rate", Decimal.Parse(req.Rate)),
                        new SqlParameter("@rateforunit", Int32.Parse(req.RateForUnit)),
                        new SqlParameter("@unittypeid", Int64.Parse(req.UnitTypeID)),
                        new SqlParameter("@billfreqncy", req.BillFrequency),
                        new SqlParameter("@billmethdid", Int64.Parse(req.BillMethodID)),
                        new SqlParameter("@billgrp", req.BillGroup),
                        new SqlParameter("@companyid", Int64.Parse(req.CompanyID)),
                        new SqlParameter("@userid", Int64.Parse(req.UserID))
                    };
            return obj.Return_ScalerValue("SaveRateCard", param);
        }
        public async Task<JsonElement> GetRateDetailByID(GetRateDetailRequest req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@ID", Int64.Parse(req.ID))
                    };
            return await obj.ConvertDataSetToJObject(obj.Return_DataSet("GetRateDetailByID", param));

        }
        public string UpdateRateGroup(UpdateRateGroupRequest req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@ID", Int64.Parse(req.ID)),
                        new SqlParameter("@billgrp", req.BillGroup),
                        new SqlParameter("@userid", Int64.Parse(req.UserId))
                    };
            return obj.Return_ScalerValue("UpdateRateGroup", param);
        }
        public string RemoveRateGroup(UpdateRateGroupRequest req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@rateid", Int64.Parse(req.ID)),
                        new SqlParameter("@key", req.BillGroup),
                        new SqlParameter("@uid", Int64.Parse(req.UserId))
                    };
            return obj.Return_ScalerValue("RemoveRateKeyward", param);
        }
        public string UpdateRateActive(UpdateRateActiveRequest req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@ID", Int64.Parse(req.ID)),
                        new SqlParameter("@active", req.Active),
                        new SqlParameter("@userid", Int64.Parse(req.UserId))
                    };
            return obj.Return_ScalerValue("UpdateRateActive", param);
        }
        public async Task<JsonElement> RateParameterList(GetRateParameterListRequest req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@rid", Int64.Parse(req.RateId)),
                        new SqlParameter("@userid", Int64.Parse(req.UserId))
                    };
            return await obj.ConvertDataSetToJObject(obj.Return_DataSet("GetRateParameterList", param));

        }
        public async Task<JsonElement> RateParameter(GetRateParameterRequest req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@companyid", Int64.Parse(req.CompanyId)),
                        new SqlParameter("@userid", Int64.Parse(req.UserId))
                    };
            return await obj.ConvertDataSetToJObject(obj.Return_DataSet("GetRateParameter", param));

        }
        public string AddRateParameter(AddRateParameterRequest req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@ID", Int64.Parse(req.ID)),
                        new SqlParameter("@rateid", Int64.Parse(req.RateID)),
                        new SqlParameter("@parameterid", Int64.Parse(req.ParameterID)),
                        new SqlParameter("@value", req.Value),
                        new SqlParameter("@frm", req.From),
                        new SqlParameter("@to", req.To),
                        new SqlParameter("@frmdate", DateTime.ParseExact(req.FromDate, "dd-MMM-yyyy", System.Globalization.CultureInfo.InvariantCulture)),
                        new SqlParameter("@todate", DateTime.ParseExact(req.ToDate, "dd-MMM-yyyy", System.Globalization.CultureInfo.InvariantCulture)),
                        new SqlParameter("@effectivedate", DateTime.ParseExact(req.EffectiveDate, "dd-MMM-yyyy", System.Globalization.CultureInfo.InvariantCulture)),
                        new SqlParameter("@customerid", Int64.Parse(req.CustomerID)),
                        new SqlParameter("@companyid", Int64.Parse(req.CompanyID)),
                        new SqlParameter("@userid", Int64.Parse(req.UserID))
                    };
            return obj.Return_ScalerValue("SaveRateParameter", param);
        }
        public async Task<JsonElement> RateParameterById(GetRateParameterbyIdRequest req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@ID", Int64.Parse(req.ID))
                    };
            return await obj.ConvertDataSetToJObject(obj.Return_DataSet("GetRateParameterById", param));

        }
        public async Task<JsonElement> RateHistory(GetRateHistoryRequest req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@rateid", Int64.Parse(req.RateID))
                    };
            return await obj.ConvertDataSetToJObject(obj.Return_DataSet("RateHistoryList", param));

        }
        public string UpdateActivityActive(UpdateRateActiveRequest req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@ID", Int64.Parse(req.ID)),
                        new SqlParameter("@active", req.Active),
                        new SqlParameter("@userid", Int64.Parse(req.UserId))
                    };
            return obj.Return_ScalerValue("UpdateActivityActive", param);
        }
        public string AddRateActivity(AddRateActivtyRequest req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@objid", Int64.Parse(req.ObjectID)),
                        new SqlParameter("@actname", req.ActivityName),
                        new SqlParameter("@remark", req.Remark),
                        new SqlParameter("@zoneid", Int64.Parse(req.ZoneId)),
                        new SqlParameter("@customerid", Int64.Parse(req.CustomerId)),
                        new SqlParameter("@userid", Int64.Parse(req.UserId)),
                        new SqlParameter("@companyid",Int64.Parse(req.CompanyId))
                    };
            return obj.Return_ScalerValue("AddRateActivity", param);
        }
    }
}
