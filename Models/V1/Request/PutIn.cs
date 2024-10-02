using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;


namespace WMSWebAPI.Models.V1.Request
{
    public class GetPutInSKUListRequest
    {
        public string OrderID { get; set; }
        public string userID { get; set; }
        public string customerID { get; set; }
        public string WarehouseId { get; set; }
    }

    public class GetPutRequest
    {
        public string OrderID { get; set; }

        public string PutID { get; set; }

        public string userID { get; set; }
        public string CustomerID { get; set; }
        public string objectname { get; set; }
        public string WarehousrID { get; set; }

    }
    public class SavePutInSKUListRequest
    {
        public string grnID { get; set; }
        public string qcID { get; set; }
        public string customerID { get; set; }

        public string uid { get; set; }
        public string palletID { get; set; }
        public string locationID { get; set; }
        public string type { get; set; }

        public string warehouseID { get; set; }
    }

    public class PutinHeadRequest
    {
        public string CustomerId { get; set; }
        public string WarehouseId { get; set; }
        public string UserId { get; set; }
        public string qcID { get; set; }
        public string PutinID { get; set; }
        public string OrderType { get; set; }
        public string pageObj { get; set; }
    }
    public class updatePutin
    {

        public string qcid { get; set; }
        public string obj { get; set; }
    }

    public class getLocation
    {
        public string warehouseID { get; set; }
        public string skey { get; set; }
        public string tempputidetailid { get; set; }
        public string lastSeqno { get; set; }
    }
    public class updateLocation
    {
        public string orderID { get; set; }
        public string locationID { get; set; }
        public string locationcode { get; set; }
        public string PutQty { get; set; }
        public Int64 SKUGRNID { get; set; }
        public Int64 QCId { get; set; }
        public string orgQty { get; set; }
        public string OrgLoctionId { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string ErrorValid { get; set; }


    }
}
