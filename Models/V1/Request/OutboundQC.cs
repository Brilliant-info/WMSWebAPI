using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WMSWebAPI.Models.V1.Request
{
    public class GetQCListRequest
    {
        public string CurrentPage { get; set; }
        public string recordLimit { get; set; }
        public string CustomerId { get; set; }
        public string WarehouseId { get; set; }
        public string UserId { get; set; }
        public string Object { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string whereFilterCondtion { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string SearchValue { get; set; }
        public string ClientId { get; set; }
    }
    public class GetBatchQCListRequest
    {
        public string CustomerId { get; set; }
        public string WarehouseId { get; set; }
        public string UserId { get; set; }
        public string BatchID { get; set; }
        public string OrderId { get; set; }

    }
    public class GetReasonCodeRequest
    {
        public string CustomerId { get; set; }
        public string WarehouseId { get; set; }
        public string UserId { get; set; }

    }
    public class GetQCDetailRequest
    {
        public string CustomerId { get; set; }
        public string WarehouseId { get; set; }
        public string UserId { get; set; }
        public string PickUpNo { get; set; }
        public string BatchID { get; set; }
        public string SOID { get; set; }
        public string QCIDPara { get; set; }


    }
    public class RemoveQCSKURequestOut
    {
        public string gID { get; set; }
        public string recordID { get; set; }
        public string obj { get; set; }
    }
    public class GetQCSKURequest
    {
        public string CustomerId { get; set; }
        public string WarehouseId { get; set; }
        public string UserId { get; set; }
        public string PickUpNo { get; set; }
        public string BatchID { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string skey { get; set; }
        public string SOID { get; set; }

    }
    public class GetQCSKUDetailRequest
    {
        public string CustomerId { get; set; }
        public string WarehouseId { get; set; }
        public string UserId { get; set; }
        public string PickUpNo { get; set; }
        public string BatchID { get; set; }
        public string SKUID { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string Lot { get; set; }
        public string SOID { get; set; }

    }
    public class SaveQCSKUDetailRequest
    {
        public string CustomerId { get; set; }
        public string WarehouseId { get; set; }
        public string UserId { get; set; }
        public string PickUpNo { get; set; }
        public string Object { get; set; }
        public string BatchID { get; set; }
        public string Remark { get; set; }
        public string ProdId { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string Lot1 { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string Lot2 { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string Lot3 { get; set; }
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string Lot4 { get; set; }
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string Lot5 { get; set; }
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string Lot6 { get; set; }
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string Lot7 { get; set; }
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string Lot8 { get; set; }
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string Lot9 { get; set; }
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string Lot10 { get; set; }
        public string Qty { get; set; }
        public string RejectQty { get; set; }
        public string ReasonID { get; set; }
        public string SOID { get; set; }
        public string qcidPara { get; set; }

    }
    public class FinalSaveQCSKUDetailRequest
    {
        public string CustomerId { get; set; }
        public string WarehouseId { get; set; }
        public string UserId { get; set; }
        public string PickUpNo { get; set; }
        public string Object { get; set; }
        public string BatchID { get; set; }
        public string SOID { get; set; }
    }

}