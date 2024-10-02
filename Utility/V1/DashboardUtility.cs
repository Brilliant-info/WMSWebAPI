using Newtonsoft.Json.Linq;
using System.Data.SqlClient;
using System.Text.Json;
using WMSWebAPI.Models.V1.Request;

namespace WMSWebAPI.Utility.V1
{
    public class DashboardUtility
    {
        SqlParameter[] param;
        DBActivity obj;
        public DashboardUtility()
        {
            obj = new DBActivity();
        }
        public async Task<JsonElement> DropdownList(GetDropdownListRequest req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@uid", req.UserId)
                    };
            return await obj.ConvertDataSetToJObject(obj.Return_DataSet("GetCustWareList", param));
        }
        public async Task<JsonElement> WarehouseList(reqWarehouseList req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@UserId", req.UserId),
                        new SqlParameter("@CustomerId", req.CustomerId)

                    };
            return await obj.ConvertDataSetToJObject(obj.Return_DataSet("sp_WarehouseCustomerWiseList", param));
        }
    }
}
