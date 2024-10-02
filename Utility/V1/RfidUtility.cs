using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text.Json;
using System.Web;
using WMSWebAPI.Models.V1.Request;

namespace WMSWebAPI.Utility.V1
{
    public class RfidUtility
    {
        SqlParameter[] param;
        DBActivity obj;
        public RfidUtility()
        {
            obj = new DBActivity();
        }
        public async Task<JsonElement> GetRfidTagging(GetRfidTaggingRequest req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@CurrentPage", Int32.Parse(req.CurrentPage)),
                        new SqlParameter("@RecordLimit", Int64.Parse(req.RecordLimit)),
                        new SqlParameter("@CustomerId", Int64.Parse(req.CustomerId)),
                        new SqlParameter("@WarehouseId", Int64.Parse(req.WarehouseId)),
                        new SqlParameter("@UserId", Int64.Parse(req.UserId)),
                        new SqlParameter("@SearchKey", req.SearchKey),
                        new SqlParameter("@ListType", req.ListType),
                        new SqlParameter("@ActiveTab", req.ActiveTab),
        };
            return await obj.ConvertDataSetToJObject(obj.Return_DataSet("sp_api_getrfidInfo", param));
        }
        public string UpdateRfid(UpdateRfidRequest req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@RfidLabel", req.RfidLabel),
                        new SqlParameter("@RecordId", Int32.Parse(req.RecordId)),
                        new SqlParameter("@Code", req.Code),
                        new SqlParameter("@CodeId", Int32.Parse(req.CodeId)),
                        new SqlParameter("@UserId", Int32.Parse(req.UserId)),

                    };
            return obj.Return_ScalerValue("sp_api_rfidupdate", param);
        }
        public string MultipleRfidUnassign(MultipleRfidUnassignRequest req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@RecordId", req.RecordId),
                        new SqlParameter("@UserId", Int64.Parse(req.UserId)),
                    };
            return obj.Return_ScalerValue("sp_api_rfidMultipleUnassign", param);
        }
        public string InsertRfid(InsertRfidRequest req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@RfidLabel", req.RfidLabel),
                        new SqlParameter("@RfidType", req.RfidType),
                        new SqlParameter("@Code", req.Code),
                        new SqlParameter("@codeId", Int64.Parse(req.CodeId)),
                        new SqlParameter("@Description", req.Description),
                        new SqlParameter("@UserId", Int64.Parse(req.UserId)),
                    };
            return obj.Return_ScalerValue("sp_api_rfidinsert", param);
        }

    }
}