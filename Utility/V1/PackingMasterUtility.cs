using Newtonsoft.Json.Linq;
using System.Data.SqlClient;
using System.Text.Json;
using WMSWebAPI.Models.V1.Request;

namespace WMSWebAPI.Utility.V1
{
    public class PackingMasterUtility
    {

        SqlParameter[] param;
        DBActivity obj;
        public PackingMasterUtility()
        {
            obj = new DBActivity();
        }

        public async Task<JsonElement> PackingMasterList(GetPackingMasterListRequest req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@CurrentPage", Int64.Parse(req.CurrentPage)),
                        new SqlParameter("@RecordLimit", Int64.Parse(req.RecordLimit)),
                        new SqlParameter("@UserId", Int64.Parse(req.UserId)),
                        new SqlParameter("@Type", req.Type),

                    };
            return await obj.ConvertDataSetToJObject(obj.Return_DataSet("sp_PackingMasterList", param));
        }
        public string PackingMasterDetail(SavePackingMasterDetailRequest req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@CompanyId", Convert.ToInt64(req.CompanyId)),
                        new SqlParameter("@UserId", Convert.ToInt64(req.UserId)),
                        new SqlParameter("@Type", req.Type),
                        new SqlParameter("@label", req.label),
                        new SqlParameter("@Number", Convert.ToInt64(req.Number)),
                    };
            return obj.Return_ScalerValue("sp_AddPackingMasterDetails", param);
        }
    }
}
