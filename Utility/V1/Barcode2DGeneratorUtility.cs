using Newtonsoft.Json.Linq;
using System.Data.SqlClient;
using System.Text.Json;
using WMSWebAPI.Models.V1.Request;

namespace WMSWebAPI.Utility.V1
{
    public class Barcode2DGeneratorUtility
    {
        
        SqlParameter[] param;
        DBActivity obj;
        public  async Task<JsonElement> Barcode2DGenerator(Barcode2DGeneratorRequest req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@CompanyID", Convert.ToInt64(req.CompanyID)),
                        new SqlParameter("@CustomerID", Convert.ToInt64(req.CustomerID)),
                        new SqlParameter("@WarehouseID", Convert.ToInt64(req.WarehouseID)),
                        new SqlParameter("@BarcodeText", req.BarcodeText)
                    };
            return await obj.ConvertDataSetToJObject(obj.Return_DataSet("Barcode2DGeneratorRequest", param));
        }
    }
}

