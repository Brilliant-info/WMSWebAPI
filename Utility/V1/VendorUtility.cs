using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text.Json;
using System.Web;
using WMSWebAPI.Models.V1.Request;

namespace WMSWebAPI.Utility.V1
{
    public class VendorUtility
    {
        SqlParameter[] param;
        DBActivity obj;
        public VendorUtility()
        {
            obj = new DBActivity();
        }
        public async Task<JsonElement> VendorList(GetVendorListRequest req)
        {
            DataSet ds = new DataSet();
            param = new SqlParameter[]
                    {
                        new SqlParameter("@CurrentPage", req.CurrentPage),
                        new SqlParameter("@RecordLimit", req.RecordLimit),
                        new SqlParameter("@CustomerID", req.CustomerID),
                        new SqlParameter("@UserId", req.UserId),
                        new SqlParameter("@Search", req.Search),
                        new SqlParameter("@Filter", req.Filter)
                    };
            ds = obj.Return_DataSet("sp_getVendorListRecord", param);

            String jsonString = String.Empty;
            int totcnt = Convert.ToInt32(ds.Tables[0].Rows[0]["TotalRecord"]);
            jsonString = "{\"VendorListResult\":[{";
            jsonString = jsonString + "\"CurrentPage\":\"" + req.CurrentPage + "\",";
            jsonString = jsonString + "\"TotalRecords\":\"" + totcnt + "\",";

            if (totcnt > 0)
            {
                jsonString = jsonString + "\"Table\":";
                jsonString = jsonString + JsonConvert.SerializeObject(ds.Tables[1]).TrimStart('{').TrimEnd('}');
            }
            else
            {
                jsonString = jsonString + "\"Table\":[]";
            }
            jsonString = jsonString + "}]}";

           // return JObject.Parse(jsonString);
            JsonDocument doc = JsonDocument.Parse(jsonString);
            JsonElement respjson = doc.RootElement;
            return respjson;

        }
        public string AddEditVendor(AddEditVendorRequest req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@CompanyId", Int64.Parse(req.CompanyID)),
                        new SqlParameter("@VendorId", Int64.Parse(req.VendorId)),
                        new SqlParameter("@CustomerId", Int64.Parse(req.CustomerId)),
                        new SqlParameter("@UserId", Int64.Parse(req.UserId)),
                        new SqlParameter("@VendorName", req.VendorName),
                        new SqlParameter("@VendorCode", req.VendorCode),
                       // new SqlParameter("@Sector", req.Sector),
                        new SqlParameter("@VendorType", Int64.Parse(req.VendorType)),
                        new SqlParameter("@VendorEmail",req.VendorEmail),
                        new SqlParameter("@vendorContact", req.VendorContact),
                        new SqlParameter("@LedgerNo", req.LedgerNo),
                        new SqlParameter("@Active", req.Active)
                    };
            return obj.Return_ScalerValue("saveVendor", param);
        }
        //vendor dropdown
        public async Task<JsonElement> vendorTypeList()
        {
            param = new SqlParameter[]
                    {

                    };
            return await obj.ConvertDataSetToJObject(obj.Return_DataSet("sp_dllVendorType", param));
        }
    }
}
