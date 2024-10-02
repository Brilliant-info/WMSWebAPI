using Newtonsoft.Json.Linq;
using System.Data.SqlClient;
using System.Text.Json;
using WMSWebAPI.Models.V1.Request;

namespace WMSWebAPI.Utility.V1
{
    public class MenupageUtility
    {
        SqlParameter[] param;
        DBActivity obj;
        public MenupageUtility()
        {
            obj = new DBActivity();
        }
        public async Task<JsonElement> GetMenu(MenupageRequest req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@UserId", Int64.Parse(req.UserID)),
                        new SqlParameter("@UserType", req.UserType),
                        new SqlParameter("@ParentId", Int64.Parse(req.ParentId)),
                    };
            return await obj.ConvertDataSetToJObject(obj.Return_DataSet("MenuPage", param));
        }
    }
}
