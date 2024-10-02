using Newtonsoft.Json.Linq;
using System.Data.SqlClient;
using System.Text.Json;
using WMSWebAPI.Models.V1.Request;

namespace WMSWebAPI.Utility.V1
{
    public class LabourUtility
    {



        SqlParameter[] param;
        DBActivity obj;
        public LabourUtility()
        {
            obj = new DBActivity();
        }

        public async Task<JsonElement> LabourList(LabourGetALL req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@CurrentPage", Int64.Parse(req.CurrentPage)),
                        new SqlParameter("@RecordLimit", Int64.Parse(req.RecordLimit)),
                        new SqlParameter("@CustomerId", Int64.Parse(req.CustomerId)),
                        new SqlParameter("@UserId", Int64.Parse(req.UserId)),
                        new SqlParameter("@Search", req.Search),
                        new SqlParameter("@Filter", req.Filter)
                    };
            return await obj.ConvertDataSetToJObject(obj.Return_DataSet("sp_labourList", param));
        }
        public string addUpdateLabour(reqLbourInsertUpdate req)
        {
            param = new SqlParameter[]
                    {

                        new SqlParameter("@LabourId", req.LabourId),
                        new SqlParameter("@UserId", Int64.Parse(req.UserId)),
                        new SqlParameter("@customerId", Int32.Parse(req.customerId)),
                        new SqlParameter("@companyId", Int32.Parse(req.companyId)),
                        new SqlParameter("@WarehouseId", Int32.Parse(req.WarehouseId)),
                        new SqlParameter("@LabourName", req.LabourName),
                        new SqlParameter("@ChargeRate", req.ChargeRate),
                        new SqlParameter("@BilableRate", req.BilableRate),
                        new SqlParameter("@VendorId", Int32.Parse(req.VendorId)),
                        new SqlParameter("@LedgerCode", req.LedgerCode),
                        new SqlParameter("@ShiftId", Int32.Parse(req.ShiftId)),
                        new SqlParameter("@StartDate", req.StartDate),
                        new SqlParameter("@EndDate", req.EndDate),
                    };
            return obj.Return_ScalerValue("LabourInsertUpdate", param);
        }
        public async Task<JsonElement> LabourShfitList(reqShiftList req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@UserId", Int64.Parse(req.UserId)),
                        new SqlParameter("@CustomerId", Int64.Parse(req.CustomerId)),
                        new SqlParameter("@WarehouseId", Int64.Parse(req.WarehouseId))
                    };
            return await obj.ConvertDataSetToJObject(obj.Return_DataSet("sp_getShiftList", param));
        }
        public string addNewShift(reqaddShift req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@UserId", Int64.Parse(req.UserId)),
                        new SqlParameter("@customerId", req.CustomerId),
                        new SqlParameter("@companyId", req.CompanyId),
                        new SqlParameter("@WarehouseId", req.WarehouseId),
                        new SqlParameter("@ShiftName", req.ShiftName),
                        new SqlParameter("@Starttime", req.Starttime),
                        new SqlParameter("@EndTime", req.EndTime),
                        new SqlParameter("@Active", req.Active)
                    };
            return obj.Return_ScalerValue("sp_addNewShift", param);
        }

        public async Task<JsonElement> GetVendorList(reqtVendorRequest req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@UserId", req.UserId),
                        new SqlParameter("@CustomerId", req.CustomerId),
                        new SqlParameter("@Warehouse",req.WarehouseId),

                    };
            return await obj.ConvertDataSetToJObject(obj.Return_DataSet("getVendorListLabour", param));
        }

        public async Task<JsonElement> ActivityLabourList(reqGetActivityList req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@UserId", Int64.Parse(req.UserId)),
                        new SqlParameter("@CustomerId", Int64.Parse(req.CustomerId)),
                         new SqlParameter("@WarehouseId", Int64.Parse(req.WarehouseId))

                    };
            return await obj.ConvertDataSetToJObject(obj.Return_DataSet("sp_getActivityList", param));
        }
        public string insertLabourDetailsList(reqLabourDetailsInsert req)
        {
            {
                param = new SqlParameter[]
                        {
                        new SqlParameter("@TimeTrackerId ", Int64.Parse(req.TimeTrackerId)),
                        new SqlParameter("@labourId", Int64.Parse(req.labourId)),
                        new SqlParameter("@ZoneId", Int64.Parse(req.ZoneId)),
                         new SqlParameter("@OrderId", Int64.Parse(req.OrderId)),
                        new SqlParameter("@OrderGroupName",req.OrderGroupName),
                        new SqlParameter("@WarehouseId", req.WarehouseId),
                        new SqlParameter("@UserId", Int64.Parse(req.UserId)),
                        new SqlParameter("@ActivityId", Int64.Parse(req.ActivityId)),
                        new SqlParameter("@ActivityStartTime", req.ActivityStartTime),
                        new SqlParameter("@ActivityEndTime", req.ActivityEndTime),
                        new SqlParameter("@CompanyId", Int64.Parse(req.CompanyId)),
                        new SqlParameter("@customerId", Int64.Parse(req.CustomerId)),
                        new SqlParameter("@CreationDate", req.CreationDate),
                        new SqlParameter("@Quantity", req.Quantity),
                        new SqlParameter("@Elapsed", req.Elapsed),
                        };
                return obj.Return_ScalerValue("sp_insertTimeTracking", param);
            }
        }

        public async Task<JsonElement> LabourDetailsTTList(ReqLabourDetailsGetALL req)
        {
            param = new SqlParameter[]
                    {
                        //new SqlParameter("@CurrentPage", Int64.Parse(req.CurrentPage)),
                        //new SqlParameter("@RecordLimit", Int64.Parse(req.RecordLimit)),
                        new SqlParameter("@CustomerId", Int64.Parse(req.CustomerId)),
                        new SqlParameter("@UserId", Int64.Parse(req.UserId))
                        //new SqlParameter("@Search", req.Search),
                        //new SqlParameter("@Filter", req.Filter)
                    };
            return await obj.ConvertDataSetToJObject(obj.Return_DataSet("sp_getLabourDetailList", param));
        }

        public async Task<JsonElement> TimeTrackingReport(reqTimeTrackingReport req)
        {
            param = new SqlParameter[]
            {
                new SqlParameter("@UserId",Int64.Parse(req.UserId)),
                new SqlParameter("@CustomerId",Int64.Parse(req.CustomerId)),
                new SqlParameter("@WarehouseId",Int64.Parse(req.WarehouseId)),
                new SqlParameter("@ZoneId",Int64.Parse(req.ZoneId)),
                new SqlParameter("@ActivityId",Int64.Parse(req.ActivityId)),
                new SqlParameter("@OrderId",Int64.Parse(req.OrderId)),
                new SqlParameter("@searchFromDate",req.searchFromDate),
                new SqlParameter("@searchToDate",req.searchToDate)
            };
            return await obj.ConvertDataSetToJObject(obj.Return_DataSet("sp_LabourTimeTrackingReport", param));
        }

        public string removeLabourRecord(reqRemoveLabour req)
        {
            {
                param = new SqlParameter[]
                        {
                        new SqlParameter("@UserId", Int64.Parse(req.UserId)),
                        new SqlParameter("@customerId", Int64.Parse(req.CustomerId)),
                        new SqlParameter("@WarehouseId", req.WarehouseId),
                        new SqlParameter("@LabourId", Int64.Parse(req.LabourId)),
                        };
                return obj.Return_ScalerValue("labourRemove", param);
            }
        }
    }
}
