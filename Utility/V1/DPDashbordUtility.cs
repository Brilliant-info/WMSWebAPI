using Newtonsoft.Json.Linq;
using System.Data.SqlClient;
using System.Text.Json;
using WMSWebAPI.Models.V1.Request;

namespace WMSWebAPI.Utility.V1
{
    public class DPDashbordUtility
    {

        SqlParameter[] param;
        DBActivity obj;

        public DPDashbordUtility()
        {
            obj = new DBActivity();
        }

        public async Task<JsonElement> CounterDPDashboard(CounterDPDashboardRequest req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@CustomerId", Int64.Parse(req.CustomerId)),
                        new SqlParameter("@CompanyID", Int64.Parse(req.CompanyID)),
                        new SqlParameter("@UserId", Int64.Parse(req.UserId)),
                        new SqlParameter("@WarehouseId", Int64.Parse(req.WarehouseID)),
                        new SqlParameter("@ClientId", Int64.Parse(req.ClientID)),

                    };
            return await obj.ConvertDataSetToJObject(obj.Return_DataSet("Sp_CounterDPDashboard", param));
        }

        public async Task<JsonElement> DispatchCountLast4MonthDP(DispatchCountLast4MonthDPRequest req)

        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@CustomerId", Int64.Parse(req.CustomerId)),
                        new SqlParameter("@CompanyID", Int64.Parse(req.CompanyID)),
                        new SqlParameter("@UserId", Int64.Parse(req.UserId)),
                        new SqlParameter("@ClientId", Int64.Parse(req.ClientID)),
                        new SqlParameter("@WarehouseId", Int64.Parse(req.WarehouseID)),

                    };
            return await obj.ConvertDataSetToJObject(obj.Return_DataSet("Sp_DispatchCountLast4MonthDP", param));

        }
    }
}
