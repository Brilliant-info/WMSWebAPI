using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text.Json;
using System.Web;
using WMSWebAPI.Models.V1.Request;

namespace WMSWebAPI.Utility.V1
{
    public class TransloadUtility
    {
        SqlParameter[] param;
        DBActivity obj;
        public TransloadUtility()
        {
            obj = new DBActivity();
        }

        public async Task<JsonElement> TransloadListID(ReqTransloadListID ReqPara)
        {
            param = new SqlParameter[]
                    {new SqlParameter("@CompanyId",Convert.ToInt64(ReqPara.CompanyId)),
                    new SqlParameter("@WhId",Convert.ToInt64(ReqPara.WhId)),
                    new SqlParameter("@CustId",Convert.ToInt64(ReqPara.CustId)),
                    new SqlParameter("@UserId",Convert.ToInt64(ReqPara.UserId)),
                    new SqlParameter("@OrderId",Convert.ToInt64(ReqPara.OrderId))
                    };
            return await obj.ConvertDataSetToJObject(obj.Return_DataSet("GetReceivedDetailNew", param));

        }

        public string TranloadSave(ReqTranloadSave ReqPara)
        {

            param = new SqlParameter[]
                    {new SqlParameter("@WarehoueId",ReqPara.WarehouseId),
                    new SqlParameter("@CustomerId",ReqPara.CustomerId),
                    new SqlParameter("@CompanyId",ReqPara.CompanyID),
                    new SqlParameter("@title",ReqPara.Title),
                    new SqlParameter("@Client",ReqPara.ClientCode),
                    new SqlParameter("@Address",ReqPara.Address1),
                    //new SqlParameter("@dtDate",ReqPara.dt),
                    new SqlParameter("@CreatedBy",ReqPara.CreatedBy),
                    new SqlParameter("@custRefNo",ReqPara.CustrefNo)
                    };
            return obj.Return_ScalerValue("IU_TransLoadHead", param);
        }

        public string TranloadSaveDT(ReqTranloadSaveDT ReqPara)
        {
            param = new SqlParameter[]
                    {
                    new SqlParameter("@HeadID",ReqPara.HeadID),
                    new SqlParameter("@ContainerID",ReqPara.ContainerID),
                    new SqlParameter("@UOMID",ReqPara.UOMID),
                    new SqlParameter("@NoOfBoxes",ReqPara.NoOfBoxes),
                    new SqlParameter("@Weight",ReqPara.Weight),
                    new SqlParameter("@CreatedBy",ReqPara.CreatedBy)
                };
            return obj.Return_ScalerValue("IU_TransLoadHeadDT", param);
        }

        public string ChangeOrdertype(ReqChangeOrderType ReqPara)
        {

            param = new SqlParameter[]
                    {new SqlParameter("@CompanyId",ReqPara.CompanyID),
                    new SqlParameter("@WhId",ReqPara.WhId),
                    new SqlParameter("@CustId",ReqPara.CustId),
                    new SqlParameter("@UserId",ReqPara.UserId),
                    new SqlParameter("@OrderId",ReqPara.OrderId),
                    new SqlParameter("@OrderType",ReqPara.OrderType)

                    };
            return obj.Return_ScalerValue("IU_OrderUpdate", param);
        }

        public string TranloadSave_RecDT(ReqTTransload_RecDT ReqPara)
        {

            param = new SqlParameter[]
                    {new SqlParameter("@HeadID",ReqPara.HeadID),
                    new SqlParameter("@StagingId",ReqPara.StagingId),
                    new SqlParameter("@DockId",ReqPara.DockId),
                    new SqlParameter("@PalletId",ReqPara.PalletId),
                    new SqlParameter("@PalletType",ReqPara.PalletType),
                    new SqlParameter("@Noofcarton",ReqPara.Noofcarton),
                    new SqlParameter("@TotWeight",ReqPara.TotWeight),
                    new SqlParameter("@ToWidth",ReqPara.ToWidth),
                    new SqlParameter("@ToHeight",ReqPara.ToHeight),
                    new SqlParameter("@Tolength",ReqPara.Tolength),
                    new SqlParameter("@Remark",ReqPara.Remark),
                    new SqlParameter("@CreatedBy",ReqPara.CreatedBy)

                    };
            return obj.Return_ScalerValue("IU_TTransloadRecDT", param);
        }

        public string TranloadSave_Receiving(ReqSaveReceving ReqPara)
        {

            param = new SqlParameter[]
                    {new SqlParameter("@HeadID",ReqPara.HeadId),
                    new SqlParameter("@ReceivedDate",ReqPara.ReceivedDate),
                    new SqlParameter("@Statuscode",ReqPara.Statuscode),
                    new SqlParameter("@Remark",ReqPara.Remark),
                    new SqlParameter("@ReceivedBy",ReqPara.ReceivedBy),
                    new SqlParameter("@OrderType",ReqPara.OrderType)

                    };

            return obj.Return_ScalerValue("IU_TransLoadReceving", param);
        }

        public string TranloadRemoveDT(ReqRemoveTransloadDT ReqPara)
        {
            string var;

            param = new SqlParameter[]
                    {new SqlParameter("@WarehouseId",ReqPara.WarehouseId),
                    new SqlParameter("@CustomerId",ReqPara.CustomerId),
                    new SqlParameter("@CompanyID",ReqPara.CompanyID),
                    new SqlParameter("@UserId",ReqPara.UserId),
                    new SqlParameter("@TranloadDTId",ReqPara.TranloadDTId)
                    //new SqlParameter("@CreatedBy",ReqPara.CreatedBy)

                    };
            return obj.Return_ScalerValue("IU_TransLoadRemoveDT", param);
        }

        public string UpdateDockIdStatus(ReqUpdateDockIdStatus ReqPara)
        {
            param = new SqlParameter[]
                    {new SqlParameter("@WarehouseId",ReqPara.WarehouseId),
                    new SqlParameter("@CustomerId",ReqPara.CustomerId),
                    new SqlParameter("@CompanyID",ReqPara.CompanyID),
                    new SqlParameter("@UserId",ReqPara.UserId),
                    new SqlParameter("@TranloadDTId",ReqPara.TranloadDTId),
                    new SqlParameter("@DockId",ReqPara.DockID),
                    new SqlParameter("@PalletId",ReqPara.PalletId),
                    new SqlParameter("@TranloadId",ReqPara.TranloadId)
                    //new SqlParameter("@CreatedBy",ReqPara.CreatedBy)

                    };
            return obj.Return_ScalerValue("IU_TransloadDispatch", param);
        }

        public string RemoveDockIdStatus(ReqRemoveDockIdStatus ReqPara)
        {
            param = new SqlParameter[]
                    {new SqlParameter("@WarehouseId",ReqPara.WarehouseId),
                    new SqlParameter("@CustomerId",ReqPara.CustomerId),
                    new SqlParameter("@CompanyID",ReqPara.CompanyID),
                    new SqlParameter("@UserId",ReqPara.UserId),
                    new SqlParameter("@TranloadDTId",ReqPara.TranloadDTId),
                    new SqlParameter("@DockId",ReqPara.DockID),
                    new SqlParameter("@PalletId",ReqPara.PalletId),
                    new SqlParameter("@TranloadId",ReqPara.TranloadId)
                    //new SqlParameter("@CreatedBy",ReqPara.CreatedBy)

                    };
            return obj.Return_ScalerValue("IU_RemoveDispatch", param);
        }

        public string TranloadRemove_RecDT(ReqRemoveTL_RecDT ReqPara)
        {

            param = new SqlParameter[]
                    {new SqlParameter("@WarehouseId",ReqPara.WarehouseId),
                    new SqlParameter("@CustomerId",ReqPara.CustomerId),
                    new SqlParameter("@CompanyID",ReqPara.CompanyID),
                    new SqlParameter("@UserId",ReqPara.UserId),
                    new SqlParameter("@TranloadDTId",ReqPara.TranloadDTId)
                    //new SqlParameter("@CreatedBy",ReqPara.CreatedBy)

                    };

            return obj.Return_ScalerValue("IU_TransLoadRemove_RecDT", param);
        }

        public async Task<JsonElement> TransloadListGetAll(ReqTransloadList ReqPara)
        {

            param = new SqlParameter[]
                    {new SqlParameter("@recordlimit",Convert.ToInt64(ReqPara.recordlimit)),
                     new SqlParameter("@CurrentPage",Convert.ToInt64(ReqPara.CurrentPage)),
                    new SqlParameter("@CompId",Convert.ToInt64(ReqPara.CompanyId)),
                    new SqlParameter("@whId",Convert.ToInt64(ReqPara.WhId)),
                    new SqlParameter("@CustId",Convert.ToInt64(ReqPara.CustId)),
                    new SqlParameter("@UserId",Convert.ToInt64(ReqPara.UserId)),
                    new SqlParameter("@ActiveTab",ReqPara.ActiveTab),
                    new SqlParameter("@SerchPara",ReqPara.SerchPara),
                    new SqlParameter("@SerchVal",ReqPara.SerchVal)
                    };
            return await obj.ConvertDataSetToJObject(obj.Return_DataSet("Get_transloadList", param));
        }

        public async Task<JsonElement> TransloadListReceving(ReqTransloadListReceving ReqPara)
        {

            param = new SqlParameter[]
                    {new SqlParameter("@CompanyId",Convert.ToInt64(ReqPara.CompanyId)),
                        new SqlParameter("@WhId",Convert.ToInt64(ReqPara.WhId)),
                        new SqlParameter("@CustId",Convert.ToInt64(ReqPara.CustId)),
                        new SqlParameter("@UserId",Convert.ToInt64(ReqPara.UserId)),
                        new SqlParameter("@OrderId",Convert.ToInt64(ReqPara.OrderId))
                    };
            return await obj.ConvertDataSetToJObject(obj.Return_DataSet("GetRecDetail2", param));

        }

        public async Task<JsonElement> GetDispatchDetails(ReqGetDispatchDetails ReqPara)
        {


            param = new SqlParameter[]
                    {new SqlParameter("@CompanyId", ReqPara.CompanyId),
                        new SqlParameter("@WhId", ReqPara.WhId),
                        new SqlParameter("@CustId", ReqPara.CustId),
                        new SqlParameter("@UserId", ReqPara.UserId),
                        new SqlParameter("@OrderId", ReqPara.OrderId),
                        new SqlParameter("@OrderDTId",ReqPara.OrderDTId)
                    };
            return await obj.ConvertDataSetToJObject(obj.Return_DataSet("GetDispatchDetails", param));
        }

        public string SaveDispatchHead(ReqSaveDispatchHead ReqPara)
        {

            param = new SqlParameter[]
                    {new SqlParameter("@WarehouseId",ReqPara.WarehouseId),
                    new SqlParameter("@CustomerId",ReqPara.CustomerId),
                    new SqlParameter("@CompanyID",ReqPara.CompanyID),
                    new SqlParameter("@UserId",ReqPara.UserId),
                    new SqlParameter("@TranloadDTId",ReqPara.TranloadDTId),
                    new SqlParameter("@DockId",ReqPara.DockId),
                    new SqlParameter("@PalletId",ReqPara.PalletId),
                    new SqlParameter("@TranloadId",ReqPara.TranloadId)
                    };
            return obj.Return_ScalerValue("IU_TransloadDispatchHead", param);
        }

        public async Task<JsonElement> clientList(ReqClientList reqPara)
        {
            param = new SqlParameter[]
                   {
                    new SqlParameter("@companyId",Convert.ToInt64(reqPara.CompanyId)),
                    new SqlParameter("@userId",Convert.ToInt64(reqPara.userId)),
                    new SqlParameter("@whId",Convert.ToInt64(reqPara.whId)),
                    new SqlParameter("@custId",Convert.ToInt64(reqPara.custId)),
                    new SqlParameter("@ClientName", reqPara.ClientName)
                    };
            return await obj.ConvertDataSetToJObject(obj.Return_DataSet("Get_ClientList", param));
        }

        // New Method
        public async Task<JsonElement> UOMList(ReqUOMList ReqPara)
        {

            param = new SqlParameter[]
                    {new SqlParameter("@companyId",Convert.ToInt64(ReqPara.CompanyId)),
                    new SqlParameter("@userId",Convert.ToInt64(ReqPara.userId)),
                    new SqlParameter("@whId",Convert.ToInt64(ReqPara.whId)),
                    new SqlParameter("@custId",Convert.ToInt64(ReqPara.custId))
                    };

            return await obj.ConvertDataSetToJObject(obj.Return_DataSet("Get_UOM", param));
        }
        public async Task<JsonElement> OrderTypeList(ReqOrderTypeList ReqPara)
        {

            param = new SqlParameter[]
                    {new SqlParameter("@companyId",Convert.ToInt64(ReqPara.CompanyId)),
                    new SqlParameter("@userId",Convert.ToInt64(ReqPara.userId)),
                    new SqlParameter("@whId",Convert.ToInt64(ReqPara.whId)),
                    new SqlParameter("@custId",Convert.ToInt64(ReqPara.custId)),
                    new SqlParameter("@OrderType", ReqPara.OrderType)
                    };
            return await obj.ConvertDataSetToJObject(obj.Return_DataSet("Get_OrderTypeList", param));
        }
        public async Task<JsonElement> UOMSugg(ReqUOMSugg reqPara)
        {
            param = new SqlParameter[]
                    {new SqlParameter("@companyId",Convert.ToInt64(reqPara.CompanyId)),
                    new SqlParameter("@userId",Convert.ToInt64(reqPara.userId)),
                    new SqlParameter("@whId",Convert.ToInt64(reqPara.whId)),
                    new SqlParameter("@custId",Convert.ToInt64(reqPara.custId)),
                    new SqlParameter("@UnitName",reqPara.UnitName)
                    };
            return await obj.ConvertDataSetToJObject(obj.Return_DataSet("Get_UOM_Sugg", param));
        }
        public async Task<JsonElement> PallettypeList(ReqPallettypeList reqPara)
        {
            param = new SqlParameter[]
                    {new SqlParameter("@companyId", reqPara.CompanyId),
                    new SqlParameter("@userId", reqPara.userId),
                    new SqlParameter("@whId", reqPara.whId),
                    new SqlParameter("@custId", reqPara.custId),
                    new SqlParameter("@PalletType",reqPara.PalletType)
                    };
            return await obj.ConvertDataSetToJObject(obj.Return_DataSet("Get_PalletType_List", param));
        }
        public async Task<JsonElement> RateActivitylist(ReqRateActivitylist reqPara)
        {
            param = new SqlParameter[]
                    {new SqlParameter("@CompanyID",Convert.ToInt64(reqPara.CompanyId)),
                    new SqlParameter("@CustId",Convert.ToInt64(reqPara.custId)),
                    new SqlParameter("@whId",Convert.ToInt64(reqPara.whId)),
                    new SqlParameter("@UserId",Convert.ToInt64(reqPara.userId)),
                    new SqlParameter("@OrderId",Convert.ToInt64(reqPara.OrderID)),
                    new SqlParameter("@ObjName",reqPara.ObjName),
                    new SqlParameter("@ActivityName",reqPara.ActivityName)
                    };
            return await obj.ConvertDataSetToJObject(obj.Return_DataSet("Get_ActivityList", param));


        }
        public async Task<JsonElement> StagingSugg(ReqStagingSugg reqPara)
        {
            param = new SqlParameter[]
                     {new SqlParameter("@companyId",Convert.ToInt64(reqPara.CompanyId)),
                    new SqlParameter("@userId",Convert.ToInt64(reqPara.userId)),
                    new SqlParameter("@whId",Convert.ToInt64(reqPara.whId)),
                    new SqlParameter("@custId",Convert.ToInt64(reqPara.custId)),
                    new SqlParameter("@StagingName",reqPara.StagingName)
                     };
            return await obj.ConvertDataSetToJObject(obj.Return_DataSet("Get_StagingSugg", param));
        }
        public async Task<JsonElement> TLHeadDetail(ReqTLHeadDetail reqPara)
        {
            param = new SqlParameter[]
                    {new SqlParameter("@compId",Convert.ToInt64(reqPara.CompanyId)),
                    new SqlParameter("@custid",Convert.ToInt64(reqPara.custId)),
                    new SqlParameter("@whId",Convert.ToInt64(reqPara.whId)),
                    new SqlParameter("@UserId",Convert.ToInt64(reqPara.userId)),
                    new SqlParameter("@OrderId",reqPara.OrderId)
                    };
            return await obj.ConvertDataSetToJObject(obj.Return_DataSet("Get_headDetail", param));
        }

        public async Task<JsonElement> Get_AddressList(ReqAddressList reqPara)
        {
            param = new SqlParameter[]
                    {new SqlParameter("@companyId",Convert.ToInt64(reqPara.CompanyId)),
                    new SqlParameter("@userId",Convert.ToInt64(reqPara.userId)),
                    new SqlParameter("@whId",Convert.ToInt64(reqPara.whId)),
                    new SqlParameter("@custId",Convert.ToInt64(reqPara.custId)),
                    new SqlParameter("@AddresstName", reqPara.AddresstName)
                    };
            return await obj.ConvertDataSetToJObject(obj.Return_DataSet("Get_AddressList", param));
        }
        public async Task<JsonElement> Get_DockList(ReqDockList reqPara)
        {
            param = new SqlParameter[]
                     {new SqlParameter("@companyId",Convert.ToInt64(reqPara.CompanyId)),
                    new SqlParameter("@userId",Convert.ToInt64(reqPara.userId)),
                    new SqlParameter("@whId",Convert.ToInt64(reqPara.whId)),
                    new SqlParameter("@custId",Convert.ToInt64(reqPara.custId)),
                    new SqlParameter("@DockName", reqPara.DockName)
                     };
            return await obj.ConvertDataSetToJObject(obj.Return_DataSet("Get_DockList", param));
        }

        //public async Task<JsonElement> Mob_ScanData(ReqMob_ScanData reqPara)
        //{
        //    param = new SqlParameter[]
        //            {new SqlParameter("@companyId",Convert.ToInt64(reqPara.CompanyId)),
        //            new SqlParameter("@userId",Convert.ToInt64(reqPara.userId)),
        //            new SqlParameter("@whId",Convert.ToInt64(reqPara.whId)),
        //            new SqlParameter("@custId",Convert.ToInt64(reqPara.custId)),
        //            new SqlParameter("@LocationId",Convert.ToInt64(reqPara.LocationId)),
        //            new SqlParameter("@PalletId",Convert.ToInt64(reqPara.PalletId)),
        //            new SqlParameter("@ScanData", reqPara.ScanData),
        //            new SqlParameter("@OrderType", reqPara.OrderType)

        //            };
        //    return obj.ConvertDataSetToJObject(obj.Return_DataSet("Get_Comm_scanAPI", param));
        //}
        //public string ScanDataAPI(ReqScanDataAPI reqPara)
        //{
        //    param = new SqlParameter[]
        //            {new SqlParameter("@companyId",Convert.ToInt64(reqPara.CompanyId)),
        //            new SqlParameter("@userId",Convert.ToInt64(reqPara.userId)),
        //            new SqlParameter("@whId",Convert.ToInt64(reqPara.whId)),
        //            new SqlParameter("@custId",Convert.ToInt64(reqPara.custId)),
        //            new SqlParameter("@ScanType", reqPara.ScanType),
        //            new SqlParameter("@InputScan", reqPara.InputScan),

        //            };

        //    dt = _df.exeSP_DT_adapter("Get_TL_scanAPI", _param);
        //    var json1 = DataTableToJSONWithJSONNet(dt);
        //    return json1;
        //}
        public async Task<JsonElement> Get_vendorList(ReqvendorList reqPara)
        {
            param = new SqlParameter[]
                    {new SqlParameter("@companyId",Convert.ToInt64(reqPara.CompanyId)),
                    new SqlParameter("@userId",Convert.ToInt64(reqPara.userId)),
                    new SqlParameter("@whId",Convert.ToInt64(reqPara.whId)),
                    new SqlParameter("@custId",Convert.ToInt64(reqPara.custId)),
                    new SqlParameter("@vendorName", reqPara.vendorName)
                    };
            return await obj.ConvertDataSetToJObject(obj.Return_DataSet("Get_vendorList", param));
        }
        public async Task<JsonElement> Get_PalletList(ReqTransPalletList reqPara)
        {
            param = new SqlParameter[]
                    {
                    new SqlParameter("@companyId",Convert.ToInt64(reqPara.CompanyId)),
                    new SqlParameter("@userId",Convert.ToInt64(reqPara.userId)),
                    new SqlParameter("@whId",Convert.ToInt64(reqPara.whId)),
                    new SqlParameter("@custId",Convert.ToInt64(reqPara.custId)),
                    new SqlParameter("@PalletName",reqPara.PalletName)
                    };
            return await obj.ConvertDataSetToJObject(obj.Return_DataSet("GetTranload_PalletList", param));
        }

        //public string UOMSugg()
        //{
        //    return "";
        //}
        //public string DataTableToJSONWithJSONNet(DataTable table)
        //{
        //    string JSONString = string.Empty;
        //    JSONString = JsonConvert.SerializeObject(table);
        //    return JSONString;
        //}

        //Order Adjustment
        public async Task<JsonElement> GetOrderAdjList(ReqOrderAdjList ReqPara)
        {

            param = new SqlParameter[]
                    {new SqlParameter("@companyId",Convert.ToInt64(ReqPara.CompanyId)),
                    new SqlParameter("@userId",Convert.ToInt64(ReqPara.UserId)),
                    new SqlParameter("@whId",Convert.ToInt64(ReqPara.WarehouseId)),
                    new SqlParameter("@custId",Convert.ToInt64(ReqPara.CustomerId)),
                    new SqlParameter("@OrderId",Convert.ToInt64(ReqPara.OrderId))
                    };
            return await obj.ConvertDataSetToJObject(obj.Return_DataSet("GetOrderAdjList", param));
        }
        public async Task<JsonElement> AddPalletList(ReqOrderPalletList ReqPara)
        {
            param = new SqlParameter[]
                    {new SqlParameter("@companyId",Convert.ToInt64(ReqPara.CompanyId)),
                    new SqlParameter("@userId",Convert.ToInt64(ReqPara.UserId)),
                    new SqlParameter("@whId",Convert.ToInt64(ReqPara.WarehouseId)),
                    new SqlParameter("@custId",Convert.ToInt64(ReqPara.CustomerId)),
                    new SqlParameter("@SerchPara", ReqPara.SerchPara),
                    new SqlParameter("@TransloadId", ReqPara.TransloadId),
                    };
            return await obj.ConvertDataSetToJObject(obj.Return_DataSet("GetOrderPalletList", param));

        }
        public string OrderAdjSave(ReqOrderAdjSave ReqPara)
        {
            param = new SqlParameter[]
                    {new SqlParameter("@CustomerID",ReqPara.CustomerId),
                    new SqlParameter("@WarehouseId", ReqPara.WarehouseId),
                    new SqlParameter("@CompanyId",ReqPara.CompanyId),
                    new SqlParameter("@UserId",ReqPara.UserId),
                    new SqlParameter("@TransloadId",ReqPara.TransloadId),
                    new SqlParameter("@TransloadDTId",ReqPara.TransloadDTId)

                    };

            return obj.Return_ScalerValue("IU_OrderAdjSave", param);

        }
        public string OrderAdjRemove(ReqOrderAdjRemove ReqPara)
        {
            param = new SqlParameter[]
                    {new SqlParameter("@CustomerID",ReqPara.CustomerId),
                    new SqlParameter("@WarehouseId", ReqPara.WarehouseId),
                    new SqlParameter("@CompanyId",ReqPara.CompanyId),
                    new SqlParameter("@UserId",ReqPara.UserId),
                    new SqlParameter("@TransloadId",ReqPara.TransloadId),
                    new SqlParameter("@TransloadDTId",ReqPara.TransloadDTId)

                    };
            return obj.Return_ScalerValue("Del_OrderAdj", param);
        }
        public string UpdateStagingTraDetail(ReqStagingTraDetail ReqPara)
        {

            param = new SqlParameter[]
                    {new SqlParameter("@Id",Convert.ToInt64(ReqPara.Id)),
                    new SqlParameter("@ClientCode",ReqPara.ClientCode),
                    new SqlParameter("@Address1",ReqPara.Address1),
                    new SqlParameter("@Address2",ReqPara.Address2),
                    new SqlParameter("@Country",ReqPara.Country),
                    new SqlParameter("@State",ReqPara.State),
                    new SqlParameter("@City",ReqPara.City),
                    new SqlParameter("@ZipCode",ReqPara.ZipCode),
                    new SqlParameter("@EmailId",ReqPara.EmailId),
                    new SqlParameter("@PhoneNo",ReqPara.PhoneNo),
                    new SqlParameter("@appointmentdetail",ReqPara.appointmentdetail),
                    new SqlParameter("@appointmentdate",ReqPara.appointmentdate),
                    new SqlParameter("@trailerDT",ReqPara.trailerDT),
                    new SqlParameter("@transporternameDT",ReqPara.transporternameDT),
                    new SqlParameter("@transremarkDT",ReqPara.transremarkDT),
                    new SqlParameter("@docknoDT",ReqPara.docknoDT),
                    new SqlParameter("@airwaybillDT",ReqPara.airwaybillDT),
                    new SqlParameter("@shippingtypeDT",ReqPara.shippingtypeDT),
                    new SqlParameter("@shippingdateDT",ReqPara.shippingdateDT),
                    new SqlParameter("@expdeldateDT",ReqPara.expdeldateDT),
                    new SqlParameter("@LrnoDT",ReqPara.LrnoDT),
                    new SqlParameter("@intimeDT",ReqPara.intimeDT),
                    new SqlParameter("@outtimeDT",ReqPara.outtimeDT),
                    new SqlParameter("@drivername",ReqPara.drivername),
                    new SqlParameter("@sealnoDT",ReqPara.sealnoDT),
                    new SqlParameter("@billofladingno",ReqPara.billofladingno),
                    new SqlParameter("@pronumber",ReqPara.pronumber),
                    new SqlParameter("@freightchaarges",ReqPara.freightchaarges),
                    new SqlParameter("@masterbilloflading",ReqPara.masterbilloflading),
                    new SqlParameter("@codamount",Convert.ToInt32(ReqPara.codamount)),
                    new SqlParameter("@feeterm",ReqPara.feeterm),
                    new SqlParameter("@trailerloadedby",ReqPara.trailerloadedby),
                    new SqlParameter("@freightcounteby",ReqPara.freightcounteby),
                    new SqlParameter("@countedtype",ReqPara.countedtype),
                    new SqlParameter("@DispatchPlan",ReqPara.DispatchPlan),
                    new SqlParameter("@ShipmentTrackingNo",ReqPara.ShipmentTrackingNo),
                    /*new SqlParameter("@WarehouseId",ReqPara.WarehouseId),
                    new SqlParameter("@CustomerId",ReqPara.CustomerId),
                    new SqlParameter("@CompanyID",ReqPara.CompanyID),*/
                    new SqlParameter("@UserId",ReqPara.UserId)
                    };
            return obj.Return_ScalerValue("IU_StagingTraDetail", param);
        }
        public async Task<JsonElement> StagingTraDetailGetAll(ReqGetStagingTraDetail ReqPara)
        {
            param = new SqlParameter[]
                     {new SqlParameter("@OrderId",Convert.ToInt64(ReqPara.OrderId)),
                    new SqlParameter("@UserId",Convert.ToInt64(ReqPara.UserId)),
                    new SqlParameter("@CompanyId",Convert.ToInt64(ReqPara.CompanyId)),
                    new SqlParameter("@whID",Convert.ToInt64(ReqPara.WhId)),
                    new SqlParameter("@CustId",Convert.ToInt64(ReqPara.CustId))
                     };
            return await obj.ConvertDataSetToJObject(obj.Return_DataSet("IU_GetStagingTraDetail", param));
        }


        //Transpoter Detail
        public string UpdateTransportDetail(ReqTransportDetail ReqPara)
        {
            param = new SqlParameter[]
                     {new SqlParameter("@Id",Convert.ToInt64(ReqPara.Id)),
                    new SqlParameter("@AirwaybillRT",ReqPara.AirwaybillRT),
                    new SqlParameter("@shippingtypeRT",ReqPara.shippingtypeRT),
                    new SqlParameter("@shippingdateRT",ReqPara.shippingdateRT),
                    new SqlParameter("@expdeldateRT",ReqPara.expdeldateRT),
                    new SqlParameter("@TransporterNameRT",ReqPara.TransporterNameRT),
                    new SqlParameter("@TransporterRemarkRT",ReqPara.TransporterRemarkRT),
                    new SqlParameter("@OutTimeRT",ReqPara.OutTimeRT),
                    new SqlParameter("@ContainerID",ReqPara.ContainerID),
                    new SqlParameter("@DockNoRT",ReqPara.DockNoRT),
                    new SqlParameter("@TruckNo",ReqPara.TruckNo),
                    new SqlParameter("@LRNoRT",ReqPara.LRNoRT),
                    new SqlParameter("@InTimeRT",ReqPara.InTimeRT),
                    new SqlParameter("@Trailer",ReqPara.Trailer),
                    new SqlParameter("@Seal",ReqPara.Seal),
                    new SqlParameter("@Carrier",ReqPara.Carrier),
                    new SqlParameter("@OrderType",ReqPara.OrderType),
                    new SqlParameter("@UserId",Convert.ToInt64(ReqPara.UserId))
                     };
            return obj.Return_ScalerValue("IU_TransportDetail", param);
        }

        public async Task<JsonElement> GetAllTransportDetailList(ReqGetTransportDetail ReqPara)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@OrderId",Convert.ToInt64(ReqPara.OrderId)),
                    new SqlParameter("@UserId",Convert.ToInt64(ReqPara.OrderId)),
                    new SqlParameter("@WhId",Convert.ToInt64(ReqPara.WhId)),
                    new SqlParameter("@CustId",Convert.ToInt64(ReqPara.CustId)),
                    new SqlParameter("@CompId ",Convert.ToInt64(ReqPara.CompanyId))
                    };

            return await obj.ConvertDataSetToJObject(obj.Return_DataSet("IU_GetTransportDetail", param));
        }
        // Staging Details Code
    }
}
