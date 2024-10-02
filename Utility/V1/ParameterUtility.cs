using Newtonsoft.Json.Linq;
using System.Data.SqlClient;
using System.Text.Json;
using WMSWebAPI.Models.V1.Request;

namespace WMSWebAPI.Utility.V1
{
    public class ParameterUtility
    {
        SqlParameter[] param;
        DBActivity obj;
        public ParameterUtility()
        {
            obj = new DBActivity();
        }
        public async Task<JsonElement> ParameterList(GetParameterListRequest req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@CompanyId", Int64.Parse(req.CompanyId)),
                        new SqlParameter("@UserId", Int64.Parse(req.UserId)),
                        new SqlParameter("@ObjectId", Int64.Parse(req.ObjectId)),
                        new SqlParameter("@ObjectName", req.ObjectName)
                    };
            return await obj.ConvertDataSetToJObject(obj.Return_DataSet("ParameterList", param));
        }
        public string AddParameter(AddParameterRequest req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@CompanyId", Int64.Parse(req.CompanyId)),
                        new SqlParameter("@UserId", Int64.Parse(req.UserId)),
                        new SqlParameter("@CustomerId", Int64.Parse(req.CustomerId)),
                        new SqlParameter("@ObjectId", Int64.Parse(req.ObjectId)),
                        new SqlParameter("@ObjectName", req.ObjectName),
                        new SqlParameter("@ParameterName", req.ParameterName),
                       // new SqlParameter("@ValueType", req.ValueType),
                        new SqlParameter("@Value", req.Value),
                        new SqlParameter("@Id", Int64.Parse(req.Id)),
                        new SqlParameter("@Active", req.Active)
                    };
            return obj.Return_ScalerValue("AddParameter", param);
        }
    }
}
