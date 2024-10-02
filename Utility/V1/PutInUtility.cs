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
    public class PutInUtility
    {
        SqlParameter[] param;
        DBActivity obj;
        public PutInUtility()
        {
            obj = new DBActivity();
        }
        public async Task<JsonElement> GetPutInlist(GetPutInSKUListRequest req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@OrderID", req.OrderID),
                        new SqlParameter("@customerID", req.customerID),
                        new SqlParameter("@wrid", req.WarehouseId),
                         new SqlParameter("@userID", req.userID)
                    };
            return await obj.ConvertDataSetToJObject(obj.Return_DataSet("sp_Putinlist", param));
        }
        public async Task<JsonElement> PutInHead(PutinHeadRequest req)
        {

            param = new SqlParameter[]
                   {
                        new SqlParameter("@custid", Convert.ToInt64(req.CustomerId)),
                        new SqlParameter("@wrid", Convert.ToInt64(req.WarehouseId)),
                        new SqlParameter("@uid", req.UserId),
                        new SqlParameter("@QCID", Convert.ToInt64(req.qcID)),
                        new SqlParameter("@PutID", Convert.ToInt64(req.PutinID)),
                        new SqlParameter("@ordertype", req.OrderType),
                        new SqlParameter("@obj", req.pageObj)
                   };
            return await obj.ConvertDataSetToJObject(obj.Return_DataSet("SP_GetPutInHead", param));

        }
        public async Task<JsonElement> GetPutInSKUDetail(GetPutRequest req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@orderID", req.OrderID),
                        new SqlParameter("@usrID", req.userID),
                        new SqlParameter("@ptid", req.PutID),
                        new SqlParameter("@customerID", req.CustomerID),
                        new SqlParameter("@obj",req.objectname),
                        new SqlParameter("@wrid",req.WarehousrID)
                    };
            // return obj.ConvertDataSetToJObject(obj.Return_DataSet("SP_GetPutInList", param));

            return await obj.ConvertDataSetToJObject(obj.Return_DataSet("SP_GetPutInListTest", param));
        }
        public string SavePutinetails(SavePutInSKUListRequest req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@grnID", Int64.Parse(req.grnID)),
                        new SqlParameter("@QcID", Int64.Parse(req.qcID)),
                        new SqlParameter("@userID", Int64.Parse(req.uid)),
                        new SqlParameter("@customerID", Int64.Parse(req.customerID)),
                        new SqlParameter("@palletID", Int64.Parse(req.palletID)),
                        new SqlParameter("@locID", Int64.Parse(req.locationID)),
                        new SqlParameter("@type",req.type),
                        new SqlParameter("@warehouseID",Convert.ToInt64(req.warehouseID)),

                    };
            // return obj.Return_ScalerValue("SP_getGrnPutinlistbyGrnID", param);
            return obj.Return_ScalerValue("SP_SavePutinDetails", param);

        }
        public string Updateputin(updatePutin req)
        {

            param = new SqlParameter[]
                    {
                        new SqlParameter("@OrderID", Convert.ToInt64(req.qcid)),
                        new SqlParameter("@obj",Convert.ToInt64(req.obj))
                    };
            return obj.Return_ScalerValue("sp_UpdatecheckPutin", param);

        }
        public async Task<JsonElement> GetLocationlist(getLocation req)
        {
            param = new SqlParameter[]
                    {

                       new SqlParameter("@warehouseID", req.warehouseID),
                       new SqlParameter("@skey",req.skey),
                       new SqlParameter("@tempputidetailid",Convert.ToInt64(req.tempputidetailid)),
                       new SqlParameter("@lastSeqno",Convert.ToInt64(req.lastSeqno))
                    };
            return await obj.ConvertDataSetToJObject(obj.Return_DataSet("sp_getlocationlist", param));
        }
        public string updateLoction(updateLocation req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@orderID", Convert.ToInt64(req.orderID)),
                        new SqlParameter("@locationID", Convert.ToInt64(req.locationID)),
                        new SqlParameter("@locationcode",req.locationcode),
                        new SqlParameter("@PutQty",req.PutQty),
                        new SqlParameter("@SKUGRNID",req.SKUGRNID),
                        new SqlParameter("@QCID",req.QCId),
                        new SqlParameter("@orgQty",req.orgQty),
                        new SqlParameter("@OrgLoctionId",req.OrgLoctionId),
                        new SqlParameter("@ErrorValid",req.ErrorValid),
                    };
            return obj.Return_ScalerValue("sp_getUpdatelocation", param);
        }
    }
}
