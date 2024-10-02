using Newtonsoft.Json.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Text.Json;
using WMSWebAPI.Models.V1.Request;

namespace WMSWebAPI.Utility.V1
{
    public class GRNActivity
    {

        SqlParameter[] param;
        DBActivity obj;
        public GRNActivity()
        {
            obj = new DBActivity();
        }

        public async Task<JsonElement> GetGRNSKUDetail(GetGRNSKUListRequest req)

        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@poid", Convert.ToInt64(req.poid)),
                        new SqlParameter("@grnid", Convert.ToInt64(req.grnid)),
                        new SqlParameter("@status", req.status)
                    };
            return await obj.ConvertDataSetToJObject(obj.Return_DataSet("SP_GetGRNSKUDetail", param));

        }


        public string SaveGRNSKUDetail(SaveGRNSKUListRequest req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@obj", req.obj),
                        new SqlParameter("@oid", Int64.Parse(req.oid)),
                        new SqlParameter("@uid", Int64.Parse(req.uid)),
                        new SqlParameter("@batch", req.batch),
                        new SqlParameter("@prdid", Int64.Parse(req.prodid)),
                        new SqlParameter("@pltid", Int64.Parse(req.pltid)),
                        new SqlParameter("@lot", req.lot),
                        new SqlParameter("@qty", Decimal.Parse(req.qty)),
                        new SqlParameter("@uomid", Int64.Parse(req.uomid)),
                        new SqlParameter("@noofpack", req.noofpack),
                        new SqlParameter("@alloextr", req.allowextra)
                    };
            return obj.Return_ScalerValue("SP_SaveGRNDetail", param);
        }


        public string RemoveGRNSKUDetail(RemoveGRNSKURequest req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@gid", req.gID),
                        new SqlParameter("@recordID", req.recordID),
                        new SqlParameter("@obj",req.obj)
                    };
            return obj.Return_ScalerValue("SP_RemoveGRNSKU", param);
        }
        public string CloseGRNSKUDetail(CloseGRNSKURequest req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@gid", req.gID),
                        new SqlParameter("@poID", req.poID)

                    };
            return obj.Return_ScalerValue("SP_CloseGRNSKU", param);
        }
        public async Task<JsonElement> GetGRNTransportDetail(GetGRNTransportListRequest req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@custid", Convert.ToInt64(req.CustomerId)),
                        new SqlParameter("@wrid", Convert.ToInt64(req.WarehouseId)),
                        new SqlParameter("@oid", Convert.ToInt64(req.OrderId))
                    };
            return await obj.ConvertDataSetToJObject(obj.Return_DataSet("SP_GetGRNTransDockList", param));
        }

        public async Task<JsonElement> SaveGatePassLottable(SaveGatePassLottableRequest req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@GetPassID", Convert.ToInt64(req.GetPassID)),
                        new SqlParameter("@SkuId", Convert.ToInt64(req.SkuId)),
                        new SqlParameter("@Qty", Convert.ToInt64(req.Qty)),
                        new SqlParameter("@GrnId", Convert.ToInt64(req.GrnId)),
                        new SqlParameter("@Lottable1", req.Lottable1),
                        new SqlParameter("@Lottable2", req.Lottable2),
                        new SqlParameter("@Lottable3", req.Lottable3),
                         new SqlParameter("@Lottable4", req.Lottable4),
                        new SqlParameter("@Lottable5", req.Lottable5),
                        new SqlParameter("@Lottable6", req.Lottable6),
                         new SqlParameter("@Lottable7", req.Lottable7),
                        new SqlParameter("@Lottable8", req.Lottable8),
                        new SqlParameter("@Lottable9", req.Lottable9),
                         new SqlParameter("@Lottable10", req.Lottable10),
                        new SqlParameter("@UomId", Convert.ToInt64(req.UomId)),
                        new SqlParameter("@UOM", req.UOM),
                        new SqlParameter("@UserId", Convert.ToInt64(req.UserId)),
                        new SqlParameter("@WarehouseId", Convert.ToInt64(req.WarehouseId)),
                        new SqlParameter("@CustomerId", Convert.ToInt64(req.CustomerId)),
                        new SqlParameter("@InwardOrderNo", Convert.ToInt64(req.InwardOrderNo)),
                    };
            return await obj.ConvertDataSetToJObject(obj.Return_DataSet("SP_SaveGatepassLottables", param));
        }
        /* SAVE GATEPASS LOTTABLE - 15 DEC 2023 */


        public async Task<JsonElement> CreateGatePassSkuSerials(CreateGatePassSkuSerialsRequest req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@SkuId", Convert.ToInt64(req.SkuId)),
                        new SqlParameter("@SkuQty", Convert.ToInt64(req.SkuQty)),
                        new SqlParameter("@ObjectName", req.ObjectName),
                        new SqlParameter("@ObjectId", Convert.ToInt64(req.ObjectId)),
                        new SqlParameter("@SubObjectName", req.SubObjectName),
                        new SqlParameter("@SubObjectId", Convert.ToInt64(req.SubObjectId)),
                        new SqlParameter("@OrderId", Convert.ToInt64(req.OrderId)),
                        new SqlParameter("@UserId", Convert.ToInt64(req.UserId)),
                        new SqlParameter("@CustomerId", Convert.ToInt64(req.CustomerId)),
                        new SqlParameter("@forceToGenerate", req.forceToGenerate)
                    };
            return await obj.ConvertDataSetToJObject(obj.Return_DataSet("sp_CreateSerialLabels", param));
        }
        /* SAVE GATEPASS LOTTABLE - 15 DEC 2023 */
        public string SaveTransportDetail(SaveGRNTransportRequest req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@GrnId", Convert.ToInt64(req.GetPassID)),
                        new SqlParameter("@CustomerId", Convert.ToInt64(req.CustomerId)),
                        new SqlParameter("@WarehouseId", Convert.ToInt64(req.WarehouseId)),
                        new SqlParameter("@UserId", Convert.ToInt64(req.UserId)),
                        new SqlParameter("@OrderId", Convert.ToInt64(req.OrderId)),
                        new SqlParameter("@Object", req.Object),
                        new SqlParameter("@AirwayBill", req.AirwayBill),
                        new SqlParameter("@ShippingType", req.ShippingType),
                        new SqlParameter("@ShippingDate", req.ShippingDate),
                        new SqlParameter("@ExpDeliveryDate", req.ExpDeliveryDate),
                        new SqlParameter("@TransporterName", req.TransporterName),
                        new SqlParameter("@TransporterNameId", Convert.ToInt64(req.TransporterNameId)),
                        new SqlParameter("@TransporterRemark", req.TransporterRemark),
                        new SqlParameter("@DockNo", req.DockNo),
                        new SqlParameter("@DockId", Convert.ToInt64(req.DockId)),
                        new SqlParameter("@TruckNo", req.TruckNo),
                        new SqlParameter("@LRNo", req.LRNo),
                        new SqlParameter("@InTime", req.InTime),
                        new SqlParameter("@OutTime", req.OutTime),
                        new SqlParameter("@ContainerID", req.ContainerID),
                        new SqlParameter("@Trailer", req.Trailer),
                        new SqlParameter("@Seal", req.Seal),
                        new SqlParameter("@Carrier", req.Carrier)
                    };
            return obj.Return_ScalerValue("SP_SaveGRNTransport", param);
        }
        public string savegetPassdetails(SaveGRNTransportRequest req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@GetPassID", Convert.ToInt64(req.GetPassID)),
                        new SqlParameter("@CustomerId", Convert.ToInt64(req.CustomerId)),
                        new SqlParameter("@WarehouseId", Convert.ToInt64(req.WarehouseId)),
                        new SqlParameter("@UserId", Convert.ToInt64(req.UserId)),
                        new SqlParameter("@OrderId",req.OrderId),
                        new SqlParameter("@Object", req.Object),
                        new SqlParameter("@AirwayBill", req.AirwayBill),
                        new SqlParameter("@ShippingType", req.ShippingType),
                        new SqlParameter("@ShippingDate", req.ShippingDate),
                        new SqlParameter("@ExpDeliveryDate", req.ExpDeliveryDate),
                        new SqlParameter("@TransporterName", req.TransporterName),
                        new SqlParameter("@TransporterNameId", Convert.ToInt64(req.TransporterNameId)),
                        new SqlParameter("@TransporterRemark", req.TransporterRemark),
                        new SqlParameter("@DockNo", req.DockNo),
                        new SqlParameter("@DockId", Convert.ToInt64(req.DockId)),
                        new SqlParameter("@TruckNo", req.TruckNo),
                        new SqlParameter("@LRNo", req.LRNo),
                        new SqlParameter("@InTime", req.InTime),
                        new SqlParameter("@OutTime", req.OutTime),
                        new SqlParameter("@ContainerID", req.ContainerID),
                        new SqlParameter("@Trailer", req.Trailer),
                        new SqlParameter("@Seal", req.Seal),
                        new SqlParameter("@Carrier", req.Carrier)
                    };
            return obj.Return_ScalerValue("SP_SaveGatepass", param);
        }

        public async Task<JsonElement> GetGRNTransport(GetGRNTransportDetailtRequest req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@custid", Convert.ToInt64(req.CustomerId)),
                        new SqlParameter("@wrid", Convert.ToInt64(req.WarehouseId)),
                        new SqlParameter("@uid", Convert.ToInt64(req.UserId)),
                        new SqlParameter("@orderid", Convert.ToInt64(req.OrderId)),
                        new SqlParameter("@obj", req.Object)
                    };
            return await obj.ConvertDataSetToJObject(obj.Return_DataSet("SP_GetTransportDetail", param));
        }



        public async Task<JsonElement> GRNHead(GRNHeadRequest req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@custid", Convert.ToInt64(req.CustomerId)),
                        new SqlParameter("@wrid", Convert.ToInt64(req.WarehouseId)),
                        new SqlParameter("@uid", Convert.ToInt64(req.UserId)),
                        new SqlParameter("@orderid", Convert.ToInt64(req.OrderId)),
                        new SqlParameter("@grnID", Convert.ToInt64(req.grnID)),
                        new SqlParameter("@ordertype", req.OrderType)
                    };
            return await obj.ConvertDataSetToJObject(obj.Return_DataSet("SP_GetGRNHead", param));
        }

        public string SaveGRNSKUDetail(SaveGRNDetailRequest req)
        {
            string Lottable1 = "0";
            string Lottable2 = "0";
            string Lottable3 = "0";
            string Lottable4 = "0";
            string Lottable5 = "0";
            string Lottable6 = "0";
            string Lottable7 = "0";
            string Lottable8 = "0";
            string Lottable9 = "0";
            string Lottable10 = "0";

            string Status = "fail";
            int Lott = 0;
            string avalue = "";
            DataTable dtlot = new DataTable();
            dtlot = getLottables(req.prodID);
            if (dtlot.Rows.Count > 0 && req.Lottables != "-")
            {
                foreach (string item in req.Lottables.Split('|'))
                {
                    string[] subs = item.Split(':');
                    DataRow[] dr = dtlot.Select("ID = " + subs[0].ToString());
                    if (dr.Length > 0)
                    {
                        avalue = dr[0]["LottableTitle"].ToString().ToLower();
                        if (avalue == "lottable-1") { Lottable1 = subs[1]; }
                        else if (avalue == "lottable-2") { Lottable2 = subs[1]; }
                        else if (avalue == "lottable-3") { Lottable3 = subs[1]; }
                        else if (avalue == "lottable-4") { Lottable4 = subs[1]; }
                        else if (avalue == "lottable-5") { Lottable5 = subs[1]; }
                        else if (avalue == "lottable-6") { Lottable6 = subs[1]; }
                        else if (avalue == "lottable-7") { Lottable7 = subs[1]; }
                        else if (avalue == "lottable-8") { Lottable8 = subs[1]; }
                        else if (avalue == "lottable-9") { Lottable9 = subs[1]; }
                        else if (avalue == "lottable-10") { Lottable10 = subs[1]; }

                    }
                }
            }

            string getdate = "";
            if (req.type == "ScanGRN")
            {
                getdate = "";
            }
            else
            {
                getdate = req.grnDate;
            }

            param = new SqlParameter[]
                    {
                    new SqlParameter("@poID", Convert.ToInt64(req.poID)),
                    new SqlParameter("@objectname",req.obj),
                    new SqlParameter("@grndate", getdate),
                    new SqlParameter("@companyID", Convert.ToInt64(req.companyID)),
                    new SqlParameter("@customerID", Convert.ToInt64(req.CustomerId)),
                    new SqlParameter("@createdby", req.UserId),
                    new SqlParameter("@grnID", req.grnID),
                    new SqlParameter("@prdid", req.prodID),
                    new SqlParameter("@palletID", req.palletID),
                    new SqlParameter("@uomid", req.UOMId),
                    new SqlParameter("@orderqty",req.RequestedQty),
                    new SqlParameter("@grnqty", req.GRNQty),
                    new SqlParameter("@lot1", Lottable1),
                    new SqlParameter("@lot2",Lottable2),
                    new SqlParameter("@lot3",Lottable3),
                    new SqlParameter("@lot4", Lottable4),
                    new SqlParameter("@lot5",Lottable5),
                    new SqlParameter("@lot6",Lottable6),
                    new SqlParameter("@lot7", Lottable7),
                    new SqlParameter("@lot8",Lottable8),
                    new SqlParameter("@lot9",Lottable9),
                    new SqlParameter("@lot10", Lottable10),
                    new SqlParameter("@type",req.type),
                    new SqlParameter("@isDerectodr",req.directpickup),
                    new SqlParameter("@GetPassId",req.GetPassId),
                    new SqlParameter("@PODTId",req.PODTId)


                    };
            Status = obj.Return_ScalerValue("SP_SaveGRNSKUDetail", param);
            return Status;
        }
        public DataTable getLottables(long prodid)
        {
            DataTable dt = new DataTable();
            try
            {
                param = new SqlParameter[]
                   {
                        new SqlParameter("@ProdID", prodid)

                   };
                return obj.exeSP_DT_adapter("sp_lottables", param);

            }
            catch (Exception ex) { }
            finally { }
            return dt;


        }
        public string Updategrn(UpdatGrnStatus req)
        {

            param = new SqlParameter[]
                    {
                        new SqlParameter("@OrderID", Convert.ToInt64(req.poID)),
                        new SqlParameter("@grnId", req.grnid)

                    };
            return obj.Return_ScalerValue("sp_UpdateGRN", param);

        }
        public async Task<JsonElement> GRNDetails(GRNDetailRequest req)
        {

            param = new SqlParameter[]
                  {
                        new SqlParameter("@custid", Convert.ToInt64(req.CustomerId)),
                        new SqlParameter("@wrid", Convert.ToInt64(req.WarehouseId)),
                        new SqlParameter("@uid", Convert.ToInt64(req.UserId)),
                        new SqlParameter("@orderid", Convert.ToInt64(req.OrderId)),
                        new SqlParameter("@ordertype", req.ordertype)
                  };
            return await obj.ConvertDataSetToJObject(obj.Return_DataSet("SP_GetGRNDetails", param));

        }
        public async Task<JsonElement> getGrnID(poidreq req)
        {

            param = new SqlParameter[]
                  {
                        new SqlParameter("@POID", req.poid)

                  };
            return await obj.ConvertDataSetToJObject(obj.Return_DataSet("getGrnbyPO", param));

        }
        public async Task<JsonElement> getPass(poidreq req)
        {

            param = new SqlParameter[]
                  {
                        new SqlParameter("@POID", req.poid)

                  };
            return await obj.ConvertDataSetToJObject(obj.Return_DataSet("getPassbyPO", param));

        }

        public async Task<JsonElement> getPassDetails(GatePassDetailRequest req)
        {

            param = new SqlParameter[]
                 {
                        new SqlParameter("@custid", Convert.ToInt64(req.CustomerId)),
                        new SqlParameter("@wrid", Convert.ToInt64(req.WarehouseId)),
                        new SqlParameter("@uid", Convert.ToInt64(req.UserId)),
                        new SqlParameter("@orderid", req.OrderId),
                        new SqlParameter("@grnID", Convert.ToInt64(req.grnID)),
                        new SqlParameter("@GatePassId", Convert.ToInt64(req.GatePassId))
                 };
            return await obj.ConvertDataSetToJObject(obj.Return_DataSet("SP_GetPassDetails", param));
        }

        public async Task<JsonElement> sp_getVendorListRecord(viewGetPass req)
        {
            param = new SqlParameter[]
            {
                new SqlParameter("@getPassID",Convert.ToInt32(req.getPassId)),
                new SqlParameter("@CustomerId",Convert.ToInt32(req.CustomerId)),
                new SqlParameter("@WarehouseId",Convert.ToInt32(req.WarehouseId)),
                new SqlParameter("@UserId",Convert.ToInt32(req.UserId)),
                new SqlParameter("@OrderId",Convert.ToInt32(req.OrderId))
            };
            return await obj.ConvertDataSetToJObject(obj.Return_DataSet("sp_viewGetPassDetails", param));
        }

        public async Task<JsonElement> getPassIDList(getPassListById req)
        {
            param = new SqlParameter[]
            {
                   new SqlParameter("@CustomerId",Convert.ToInt32(req.CustomerId)),
                   new SqlParameter("@WarehouseId",Convert.ToInt32(req.WarehouseId)),
                   new SqlParameter("@UserId",Convert.ToInt32(req.UserId)),
                   new SqlParameter("@OrderId",Convert.ToInt32(req.OrderId))
            };
            return await obj.ConvertDataSetToJObject(obj.Return_DataSet("sp_getPassIdList", param));
        }

        /* GET BARCODE TO PRINT AS PER PATTERN - 04 DEC 2023 */

        public async Task<JsonElement> getBarcodeAsPerConfig(getBarcodeAsPerConfig req)
        {
            param = new SqlParameter[]
            {
                   new SqlParameter("@SkuId",Convert.ToInt32(req.SkuId)),
                   new SqlParameter("@OrderId",Convert.ToInt32(req.OrderId))
            };
            return await obj.ConvertDataSetToJObject(obj.Return_DataSet("sp_GetBarcodePrintableString", param));
        }


        public async Task<JsonElement> getBarcodePrintData(getBarcodePrintData req)
        {
            var param = new SqlParameter[]
            {
        new SqlParameter("@SkuId", req.SkuId),
        new SqlParameter("@OrderId", req.OrderId),
        new SqlParameter("@ObjectType", req.objectType),
        new SqlParameter("@ObjectId", req.objectId),
        new SqlParameter("@DTID", req.DTID)
            };

            return await obj.ConvertDataSetToJObject(obj.Return_DataSet("sp_GetBarcodeGetPassDetails", param));
        }

        public async Task<JsonElement> ShowGeneratedSerialList(ShowGeneratedSerialList req)
        {
            var param = new SqlParameter[]
            {
        new SqlParameter("@SkuId", req.SkuId),
        new SqlParameter("@OrderId", req.OrderId),
        new SqlParameter("@ObjectType", req.ObjectType),
        new SqlParameter("@ObjectTypeId", Convert.ToInt32(req.ObjectTypeId))
            };

            return await obj.ConvertDataSetToJObject( obj.Return_DataSet("sp_GetBarcodePrintableSerialList", param));
        }
        /* GET BARCODE TO PRINT AS PER PATTERN - 19 DEC 2023 */

        /* GRN PRINT LABLE STYLE -  03 JUNE 2024 */

        public async Task<JsonElement> GetGrnPrintLabelStyle(GetGrnPrintLabelStyle req)
        {
            param = new SqlParameter[]
            {
                   new SqlParameter("@UserId",Convert.ToInt32(req.UserId)),
                   new SqlParameter("@CustomerId",Convert.ToInt32(req.CustomerId)),
                   new SqlParameter("@ObjectType",req.ObjectType)
            };
            return await obj.ConvertDataSetToJObject(obj.Return_DataSet("sp_GetGrnPrintLabelStyle", param));
        }

        public async Task<JsonElement> SaveGrnPrintLabelStyle(SaveGrnPrintLabelStyle req)
        {
            param = new SqlParameter[]
            {
                  new SqlParameter("@UserId",Convert.ToInt32(req.UserId)),
                   new SqlParameter("@CustomerId",Convert.ToInt32(req.CustomerId)),
                   new SqlParameter("@TemplateId",Convert.ToInt32(req.TemplateId)),
                   new SqlParameter("@ObjectType",req.ObjectType)
            };
            return await obj.ConvertDataSetToJObject(obj.Return_DataSet("sp_SaveGrnPrintLabelStyle", param));
        }
    }
}
