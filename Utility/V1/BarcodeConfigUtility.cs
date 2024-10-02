using Newtonsoft.Json.Linq;
using System.Data.SqlClient;
using System.Text.Json;
using WMSWebAPI.Models.V1.Request;

namespace WMSWebAPI.Utility.V1
{
    public class BarcodeConfigUtility
    {
        SqlParameter[] param;
        DBActivity obj;
        public BarcodeConfigUtility()
        {
            obj = new DBActivity();
        }
        public async Task<JsonElement> BarcodeObjectList(BarcodeObjectListRequest req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@CompanyID", Int32.Parse(req.CompanyID)),
                        new SqlParameter("@CustomerID", Int64.Parse(req.CustomerID)),
                        new SqlParameter("@WarehouseID", Int64.Parse(req.WarehouseID)),

                    };
            return await obj.ConvertDataSetToJObject(obj.Return_DataSet("sp_BarcodeList", param));
        }
        public async Task<JsonElement> TemplateList(TemplateListRequest req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@ObjectID", Int32.Parse(req.ObjectID)),
                        new SqlParameter("@CompanyID", Int32.Parse(req.CompanyID)),
                        new SqlParameter("@CustomerID", Int32.Parse(req.CustomerID)),
                        new SqlParameter("@WarehouseID", Int32.Parse(req.WarehouseID)),
                    };
            return await obj.ConvertDataSetToJObject(obj.Return_DataSet("sp_BarcodeDetailList", param));
        }
        public string SaveBarcodeConfig(SaveBarcodeConfigRequest req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@CompanyID", Int32.Parse(req.CompanyID)),
                        new SqlParameter("@CustomerID", Int32.Parse(req.CompanyID)),
                        new SqlParameter("@LabelSize", req.LabelSize),
                        new SqlParameter("@Prefix", req.Prefix),
                        new SqlParameter("@ObjectID", Int32.Parse(req.ObjectId)),
                        new SqlParameter("@TemplateID", Int32.Parse(req.TemplateID)),
                        new SqlParameter("@WarehouseID", Int32.Parse(req.WarehouseID)),
                        new SqlParameter("@ID", Int32.Parse(req.ID)),

                    };
            return obj.Return_ScalerValue("sp_SaveBarcodeConfig", param);
        }
        public async Task<JsonElement> ViewBarcodeConfig(ViewBarcodeConfigRequest req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@ObjectID", Int32.Parse(req.ObjectID)),
                        new SqlParameter("@CompanyID", Int32.Parse(req.CompanyID)),
                        new SqlParameter("@CustomerID", Int32.Parse(req.CustomerID)),
                        new SqlParameter("@WarehouseID", Int32.Parse(req.WarehouseID)),
                    };
            return await obj.ConvertDataSetToJObject(obj.Return_DataSet("sp_ViewBarcodeConfigdetail", param));
        }
    }
}
