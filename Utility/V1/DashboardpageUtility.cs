using Newtonsoft.Json.Linq;
using System.Data.SqlClient;
using System.Text.Json;
using WMSWebAPI.Models.V1.Request;

namespace WMSWebAPI.Utility.V1
{
    public class DashboardpageUtility
    {
        SqlParameter[] param;
        DBActivity obj;
        public DashboardpageUtility()
        {
            obj = new DBActivity();
        }
        public async Task<JsonElement> TopInwardOutward(DashboardTopInwardOutwardRequest req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@WarehouseId", req.WarehouseID),
                        new SqlParameter("@UserId", req.UserID),
                        new SqlParameter("@VendorID", req.VendorID),
                        new SqlParameter("@ClientId", req.ClientID),
                        new SqlParameter("@CustomerId", req.CustomerID),
                    };
            return await obj.ConvertDataSetToJObject(obj.Return_DataSet("DashboardtopInwardOtward", param));
        }
        public async Task<JsonElement> TopInventory(DashboardTopInventoryRequest req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@CustomerId", Int64.Parse(req.CustomerId)),
                        new SqlParameter("@CompanyID", Int64.Parse(req.CompanyID)),
                        new SqlParameter("@UserId", Int64.Parse(req.UserId)),
                    };
            return await obj.ConvertDataSetToJObject(obj.Return_DataSet("DashboardtopInventory", param));
        }
        public async Task<JsonElement> CounterDashboard(CounterDashboardRequest req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@CustomerId", Int64.Parse(req.CustomerId)),
                        new SqlParameter("@CompanyID", Int64.Parse(req.CompanyID)),
                        new SqlParameter("@UserId", Int64.Parse(req.UserId)),
                        new SqlParameter("@WarehouseId", Int64.Parse(req.WarehouseID)),
                        new SqlParameter("@ClientId", Int64.Parse(req.ClientID)),

                    };
            return await obj.ConvertDataSetToJObject(obj.Return_DataSet("Sp_CounterDashboard", param));
        }
        public async Task<JsonElement> InwardBarchart(InwardBarchartRequest req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@CustomerId", Int64.Parse(req.CustomerId)),
                        new SqlParameter("@CompanyID", Int64.Parse(req.CompanyID)),
                        new SqlParameter("@UserId", Int64.Parse(req.UserId)),
                        new SqlParameter("@VendorID", Int64.Parse(req.VendorID)),
                        new SqlParameter("@WarehouseId", Int64.Parse(req.WarehouseID)),


                    };
            return await obj.ConvertDataSetToJObject(obj.Return_DataSet("Sp_InwardBarchart", param));
        }
        public async Task<JsonElement> OutwardPieChart(OutwardPieChartRequest req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@CustomerId", Int64.Parse(req.CustomerId)),
                        new SqlParameter("@CompanyID", Int64.Parse(req.CompanyID)),
                        new SqlParameter("@UserId", Int64.Parse(req.UserId)),
                        new SqlParameter("@ClientID", Int64.Parse(req.ClientID)),
                        new SqlParameter("@WarehouseId", Int64.Parse(req.WarehouseID)),
                    };
            return await obj.ConvertDataSetToJObject(obj.Return_DataSet("Sp_OutwardPieChart", param));
        }
        public async Task<JsonElement> DispatchCountLast4Month(DispatchCountLast4MonthRequest req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@CustomerId", Int64.Parse(req.CustomerId)),
                        new SqlParameter("@CompanyID", Int64.Parse(req.CompanyID)),
                        new SqlParameter("@UserId", Int64.Parse(req.UserId)),
                        new SqlParameter("@ClientId", Int64.Parse(req.ClientID)),
                        new SqlParameter("@WarehouseId", Int64.Parse(req.WarehouseID)),

                    };
            return await obj.ConvertDataSetToJObject(obj.Return_DataSet("Sp_DispatchCountLast4Month", param));
        }
    }
}
