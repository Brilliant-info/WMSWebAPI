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
    public class ReportUtility
    {
        SqlParameter[] param;
        DBActivity obj;
        public ReportUtility()
        {
            obj = new DBActivity();
        }
        public async Task<JsonElement> GlobalReportList(GetGlobalReportListRequest req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@CurrentPage", Int64.Parse(req.CurrentPage)),
                        new SqlParameter("@RecordLimit", Int64.Parse(req.RecordLimit)),
                        new SqlParameter("@WarehouseId", Int64.Parse(req.WarehouseId)),
                        new SqlParameter("@UserId", Int64.Parse(req.UserId)),
                        new SqlParameter("@CustomerId", Int64.Parse(req.CustomerId)),
                        new SqlParameter("@Filter", req.Filter),
                        new SqlParameter("@ReportID", Int64.Parse(req.ReportID))
                    };
            return await obj.ConvertDataSetToJObject(obj.Return_DataSet("SP_GlobalReportList", param));
        }
        public async Task<JsonElement> ReportCategory(GetReportCategoryRequest req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@UserId", Int64.Parse(req.UserId)),
                    };
            return await obj.ConvertDataSetToJObject(obj.Return_DataSet("Sp_reportCategory", param));
        }
        public async Task<JsonElement> PurchaseorderRecieptdetail(GetPurchaseorderRecieptdetailRequest req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@UserId", Int64.Parse(req.UserId)),
                        new SqlParameter("@ID", Int64.Parse(req.ID)),
                        new SqlParameter("@filterLottable", req.filterLottable),
                    };
            return await obj.ConvertDataSetToJObject(obj.Return_DataSet("Sp_PurchaseorderRecieptdetail", param));
        }
        public async Task<JsonElement> ReportCategoryMenu(GetReportCategoryMenuRequest req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@UserId", Int64.Parse(req.UserId)),
                        new SqlParameter("@CategoryID", Int64.Parse(req.CategoryId)),
                        new SqlParameter("@RoleId", Int64.Parse(req.RoleId)),
                    };
            return await obj.ConvertDataSetToJObject(obj.Return_DataSet("SP_ReportCategoryMenu", param));
        }
        public async Task<JsonElement> Saleorderdetail(GetSalesorderdetailRequest req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@UserId", Int64.Parse(req.UserId)),
                        new SqlParameter("@ID", Int64.Parse(req.ID)),
                        new SqlParameter("@filterLottable", req.filterLottable),
                    };
            return await obj.ConvertDataSetToJObject(obj.Return_DataSet("Sp_SaleOrderdetail", param));
        }
        public async Task<JsonElement> Dispatchorderdetail(GetDispatchorderdetailRequest req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@UserId", Int64.Parse(req.UserId)),
                        new SqlParameter("@ID", Int64.Parse(req.ID)),
                        new SqlParameter("@filterLottable", req.filterLottable),
                    };
            return await obj.ConvertDataSetToJObject(obj.Return_DataSet("Sp_DispatchOrderdetail", param));
        }
        public async Task<JsonElement> Variencedetail(GetVariencedetailRequest req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@UserId", Int64.Parse(req.UserId)),
                        new SqlParameter("@ID", Int64.Parse(req.ID)),
                    };
            return await obj.ConvertDataSetToJObject(obj.Return_DataSet("Sp_VarienceOrderdetail", param));
        }
        public async Task<JsonElement> Recivingdetail(GetRecivingdetailRequest req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@UserId", Int64.Parse(req.UserId)),
                        new SqlParameter("@ID", Int64.Parse(req.ID)),
                        new SqlParameter("@filterLottable", req.filterLottable),
                    };
            return await obj.ConvertDataSetToJObject(obj.Return_DataSet("Sp_Recivingdetail", param));
        }
        public async Task<JsonElement> AllocationGroupDetail(GetAllocationGroupdetailRequest req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@UserId", Int64.Parse(req.UserId)),
                        new SqlParameter("@ID", Int64.Parse(req.ID)),
                        new SqlParameter("@filterLottable", req.filterLottable),
                    };
            return await obj.ConvertDataSetToJObject(obj.Return_DataSet("Sp_AllocationGroupDetail", param));
        }
        public async Task<JsonElement> Pickingdetail(GetPickingdetailRequest req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@UserId", Int64.Parse(req.UserId)),
                        new SqlParameter("@ID", Int64.Parse(req.ID)),
                        new SqlParameter("@filterLottable", req.filterLottable),
                    };
            return await obj.ConvertDataSetToJObject(obj.Return_DataSet("Sp_Pickingdetail", param));
        }
        public async Task<JsonElement> OrderHistorydetail(GetOrderHistorydetailRequest req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@UserId", Int64.Parse(req.UserId)),
                        new SqlParameter("@ID", Int64.Parse(req.ID)),
                    };
            return await obj.ConvertDataSetToJObject(obj.Return_DataSet("Sp_OrderHistorydetail", param));
        }
        public async Task<JsonElement> PackingOrderdetail(GetPackingdetailRequest req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@UserId", Int64.Parse(req.UserId)),
                        new SqlParameter("@ID", Int64.Parse(req.ID)),
                        new SqlParameter("@filterLottable", req.filterLottable),
                    };
            return await obj.ConvertDataSetToJObject(obj.Return_DataSet("Sp_packingdetail", param));
        }
        public async Task<JsonElement> CustomerInventory(GetCustomerInventoryRequest req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@UserId", Int64.Parse(req.UserId)),
                        new SqlParameter("@ID", Int64.Parse(req.ID)),
                    };
            return await obj.ConvertDataSetToJObject(obj.Return_DataSet("Sp_CustomerInventorydetail", param));
        }
        public async Task<JsonElement> CustomerInventoryLoc(GetCustomerInventoryLocRequest req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@UserId", Int64.Parse(req.UserId)),
                        new SqlParameter("@ID", Int64.Parse(req.ID)),
                    };
            return await obj.ConvertDataSetToJObject(obj.Return_DataSet("Sp_CustomerInventoryLocdetail", param));
        }
        //public async Task<JsonElement> GetPutawaydetailRequest(GetPutawaydetailRequest req)
        //{
        //    param = new SqlParameter[]
        //            {
        //                new SqlParameter("@UserId", Int64.Parse(req.UserId)),
        //                new SqlParameter("@ID", Int64.Parse(req.ID)),
        //                new SqlParameter("@filterLottable", req.filterLottable),
        //            };
        //    return obj.ConvertDataSetToJObject(obj.Return_DataSet("Sp_PutwayDetail", param));
        //}
        public async Task<JsonElement> InwardQualityCheckDetail(GetInwardQualityCheckRequest req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@UserId", Int64.Parse(req.UserId)),
                        new SqlParameter("@ID", Int64.Parse(req.ID)),
                        new SqlParameter("@filterLottable", req.filterLottable),
                    };
            return await obj.ConvertDataSetToJObject(obj.Return_DataSet("Sp_InwardQcdetail", param));
        }
        public async Task<JsonElement> GetPutawaydetail(GetPutawaydetailRequest req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@UserId", Int64.Parse(req.UserId)),
                        new SqlParameter("@ID", Int64.Parse(req.ID)),
                        new SqlParameter("@filterLottable", req.filterLottable),
                    };
            return await obj.ConvertDataSetToJObject(obj.Return_DataSet("Sp_PutwayDetail", param));
        }
        public async Task<JsonElement> CycleCountDetail(GetCycleCountRequest req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@UserId", Int64.Parse(req.UserId)),
                        new SqlParameter("@ID", Int64.Parse(req.ID)),
                        new SqlParameter("@filterLottable", req.filterLottable),
                    };
            return await obj.ConvertDataSetToJObject(obj.Return_DataSet("Sp_CycleCount", param));
        }
        public async Task<JsonElement> InternalTransferDetail(GetInternalTransRequest req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@UserId", Int64.Parse(req.UserId)),
                        new SqlParameter("@ID", Int64.Parse(req.ID)),
                        new SqlParameter("@filterLottable", req.filterLottable),
                    };
            return await obj.ConvertDataSetToJObject(obj.Return_DataSet("Sp_InternalTransferdetail", param));
        }
        public async Task<JsonElement> OutwardQualityCheckDetail(GetOutwardQualityCheckRequest req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@UserId", Int64.Parse(req.UserId)),
                        new SqlParameter("@ID", Int64.Parse(req.ID)),
                        new SqlParameter("@filterLottable", req.filterLottable),
                    };
            return await obj.ConvertDataSetToJObject(obj.Return_DataSet("Sp_OutwardQcdetail", param));
        }
        public async Task<JsonElement> Salesreturndetail(GetSalesreturndetailRequest req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@UserId", Int64.Parse(req.UserId)),
                        new SqlParameter("@ID", Int64.Parse(req.ID)),
                        new SqlParameter("@filterLottable", req.filterLottable),
                    };
            return await obj.ConvertDataSetToJObject(obj.Return_DataSet("Sp_Salereturndetail", param));
        }
        public string PickingDetailsExportCsv(PickingDetailsExportCsv req)
        {
            string csv = string.Empty;
            DataSet getdatacsv;

            param = new SqlParameter[]
                    {
                        new SqlParameter("@UserId", req.UserId),
                        new SqlParameter("@ID", req.reportDetailId),
                    };
            getdatacsv = obj.Return_DataSet("Sp_Pickingdetailcsv", param);

            foreach (DataColumn column in getdatacsv.Tables[0].Columns)
            {
                //Add the Header row for CSV file.
                csv += column.ColumnName + ',';
            }

            //Add new line.
            csv += "\r\n";

            foreach (DataRow row in getdatacsv.Tables[0].Rows)
            {
                foreach (DataColumn column in getdatacsv.Tables[0].Columns)
                {
                    //Add the Data rows.
                    csv += row[column.ColumnName].ToString().Replace(",", ";") + ',';
                }

                //Add new line.
                csv += "\r\n";
            }

            ///Prdouct Details
            csv += "\r\n";
            csv += "\r\n";
            csv += "\r\n";
            csv += "\r\n";
            csv += "\r\n";
            foreach (DataColumn column in getdatacsv.Tables[1].Columns)
            {
                //Add the Header row for CSV file.
                csv += column.ColumnName + ',';
            }

            //Add new line.
            csv += "\r\n";

            foreach (DataRow row in getdatacsv.Tables[1].Rows)
            {
                foreach (DataColumn column in getdatacsv.Tables[1].Columns)
                {
                    //Add the Data rows.
                    csv += row[column.ColumnName].ToString().Replace(",", ";") + ',';
                }

                //Add new line.
                csv += "\r\n";
            }
            //JObject json = obj.ConvertDataSetToJObject(getdatacsv);

            return csv;


        }
        public async Task<JsonElement> InvoiceDetailReport(InvoiceDetailReportRequest req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@UserId", req.UserId),
                        new SqlParameter("@ID", Int64.Parse(req.InvoiceId)),
                    };
            return await obj.ConvertDataSetToJObject(obj.Return_DataSet("SP_InvoiceDetails", param));
        }
    }
}
