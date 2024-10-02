using Newtonsoft.Json.Linq;
using System.Data.SqlClient;
using System.Text.Json;
using WMSWebAPI.Models.V1.Request;

namespace WMSWebAPI.Utility.V1
{
    public class _3PLBillingUtility
    {
        SqlParameter[] param;
        DBActivity obj;
        public _3PLBillingUtility()
        {
            obj = new DBActivity();
        }
        public async Task<JsonElement> BillingGroupList(GetBillingGroupRequest req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@customerid", Int64.Parse(req.CustomerId))
                    };
            return await obj.ConvertDataSetToJObject(obj.Return_DataSet("GetBillingGroup", param));

        }
        public async Task<JsonElement> TransactionList(GetTransactionListRequest req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@CustomerId", Int64.Parse(req.CustomerId)),
                        new SqlParameter("@WarehouseId", Int64.Parse(req.WarehouseId)),
                        new SqlParameter("@Status", Int32.Parse(req.Status)),
                        new SqlParameter("@Group", req.Group),
                        new SqlParameter("@FrmDate", req.FromDate),
                        new SqlParameter("@ToDate", req.ToDate),
                        new SqlParameter("@RateId", Int64.Parse(req.RateId))
                    };
            return await obj.ConvertDataSetToJObject(obj.Return_DataSet("GetTransList", param));

        }
        public async Task<JsonElement> RateCardList(GetRateListRequest req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@CustomerId", Int64.Parse(req.CustomerId))
                    };
            return await obj.ConvertDataSetToJObject(obj.Return_DataSet("GetRateCard", param));
        }
        public async Task<JsonElement> TransactionDetail(GetTransactionDetailRequest req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@CurrentPage", Int32.Parse(req.CurrentPage)),
                        new SqlParameter("@RecordLimit", Int32.Parse(req.RecordLimit)),
                        new SqlParameter("@FrmDate", req.FromDate),
                        new SqlParameter("@ToDate", req.ToDate),
                        new SqlParameter("@RateId", Int64.Parse(req.RateId))
                    };
            return await obj.ConvertDataSetToJObject(obj.Return_DataSet("GetTransDetail", param));

        }
        public string Save3PLData(Save3PLDataRequest req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@RID", req.RateID),
                        new SqlParameter("@uid", long.Parse(req.UserId)),
                        new SqlParameter("@custid", long.Parse(req.CustomerId)),
                        new SqlParameter("@FrmDate", req.FromDate),
                        new SqlParameter("@ToDate", req.ToDate)
                    };
            return obj.Return_ScalerValue("SP_Save3PLAll", param);
        }
        public async Task<JsonElement> PreBillDetail(GetPreBillRequest req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@custid", Int64.Parse(req.CustomerId)),
                        new SqlParameter("@wrid", Int64.Parse(req.WarehouseId)),
                        new SqlParameter("@uid", Int64.Parse(req.UserId))
                    };
            return await obj.ConvertDataSetToJObject(obj.Return_DataSet("getPreBilling", param));

        }
        public string UpdateBill(UpdateBillRequest req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@param", req.Paramater),
                        new SqlParameter("@ID", long.Parse(req.ID)),
                        new SqlParameter("@rate", decimal.Parse(req.Rate)),
                        new SqlParameter("@qty", decimal.Parse(req.Qty)),
                        new SqlParameter("@uid", long.Parse(req.UserId))
                    };
            return obj.Return_ScalerValue("updateBill", param);
        }
        public string SaveInvoice(SaveInvoiceRequest req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@custid", long.Parse(req.CustomerId)),
                        new SqlParameter("@total", decimal.Parse(req.Total)),
                        new SqlParameter("@tax", decimal.Parse(req.Tax)),
                        new SqlParameter("@compid", long.Parse(req.CompanyId)),
                        new SqlParameter("@billaddr", req.BillAddress),
                        new SqlParameter("@shipaddr", req.ShipAddress),
                        new SqlParameter("@uid", long.Parse(req.UserId))
                    };
            return obj.Return_ScalerValue("finalSaveInvoice", param);
        }
        public async Task<JsonElement> InvoiceList(GetInvoiceListRequest req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@currentpg", Int32.Parse(req.CurrentPage)),
                        new SqlParameter("@recordlmt", Int32.Parse(req.RecordLimit)),
                        new SqlParameter("@custid", Int64.Parse(req.CustomerId)),
                        new SqlParameter("@uid", Int64.Parse(req.UserId)),
                        new SqlParameter("@skeycol", req.Filter),
                        new SqlParameter("@skeyval", req.Search)
                    };
            return await obj.ConvertDataSetToJObject(obj.Return_DataSet("getInvoiceList", param));

        }
        public string PaymentBooking(PaymentBookingRequest req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@InvoiceID", long.Parse(req.InvoiceID)),
                        new SqlParameter("@PaymentDate", DateTime.Parse(req.PaymentDate)),
                        new SqlParameter("@PaymentAmount", decimal.Parse(req.PaymentAmount)),
                        new SqlParameter("@DocRefNo", req.DocRefNo),
                        new SqlParameter("@Perticular", req.Perticular),
                        new SqlParameter("@Credit", decimal.Parse(req.Credit)),
                        new SqlParameter("@Debit", decimal.Parse(req.Debit)),
                        new SqlParameter("@UserId", long.Parse(req.UserId)),
                        new SqlParameter("@CustomerID", long.Parse(req.CustomerID)),
                        new SqlParameter("@CompanyID", long.Parse(req.CompanyID)),
                        new SqlParameter("@Transtype", req.Transtype),
                    };
            return obj.Return_ScalerValue("Sp_InsertIntotInvoicePaymentbooking", param);
        }
        public async Task<JsonElement> PaymentDetail(PaymentDetailRequest req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@InvoiceID", Int64.Parse(req.InvoiceID))
                    };
            return await obj.ConvertDataSetToJObject(obj.Return_DataSet("getPaymentDetail", param));

        }

        // 3pl object API//

        public async Task<JsonElement> ValueAddList(ValueAddRequest req)
        {
            param = new SqlParameter[]
                    {
                new SqlParameter("@obj", req.Object),
                new SqlParameter("@oid", Int64.Parse(req.OrderId))
                    };
            return await obj.ConvertDataSetToJObject(obj.Return_DataSet("getValueAdd", param));

        }

        public async Task<JsonElement> ActivityList(GetActivtyTypeRequest3pl req)
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
            return await obj.ConvertDataSetToJObject(obj.Return_DataSet("GetActivityValueAdd", param));

        }
        public string AddRateActivity3plobject(AddRateActivtyRequest3plobject req)
        {
            param = new SqlParameter[]
                    {
                new SqlParameter("@objid", Int64.Parse(req.ObjectID)),
                new SqlParameter("@actname", req.ActivityName),
                new SqlParameter("@remark", req.Remark),
                new SqlParameter("@zoneid", Int64.Parse(req.ZoneId)),
                new SqlParameter("@customerid", Int64.Parse(req.CustomerId)),
                new SqlParameter("@userid", Int64.Parse(req.UserId)),
                new SqlParameter("@companyid",Int64.Parse(req.CompanyId))
                    };
            return obj.Return_ScalerValue("AddActivityValueAdd", param);
        }
        public string AddValueAdd(SaveValueAddRequest req)
        {
            param = new SqlParameter[]
                    {
                new SqlParameter("@Id", Int64.Parse(req.Id)),
                new SqlParameter("@customerid", Int64.Parse(req.CustomerId)),
                new SqlParameter("@activityid", Int64.Parse(req.ActivityId)),
                new SqlParameter("@activityname", req.ActivityName),
                new SqlParameter("@rate", Decimal.Parse(req.Rate)),
                new SqlParameter("@unitid", Int64.Parse(req.UnitId)),
                new SqlParameter("@companyid", Int64.Parse(req.CompanyId)),
                new SqlParameter("@userid",Int64.Parse(req.UserId)),
                new SqlParameter("@obj", req.Object),
                new SqlParameter("@oid", Int64.Parse(req.OrderId)),
                new SqlParameter("@orderno", req.OrderNo),
                new SqlParameter("@qty", Decimal.Parse(req.Quantity)),
                new SqlParameter("@warehouseid", Int64.Parse(req.WarehouseId)),
                new SqlParameter("@remark", req.Remark)
                    };
            return obj.Return_ScalerValue("SaveValueAdd", param);
        }
    }
}
