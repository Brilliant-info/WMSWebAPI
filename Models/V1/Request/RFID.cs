using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WMSWebAPI.Models.V1.Request
{
    public class GetRfidTaggingRequest
    {
        public String CurrentPage { get; set; }
        public String RecordLimit { get; set; }
        public String CustomerId { get; set; }
        public String WarehouseId { get; set; }
        public String UserId { get; set; }
        public String SearchKey { get; set; }
        public String ListType { get; set; }
        public String ActiveTab { get; set; }
    }

    // UPDATE RFID - ASSIGN DEASSIGN
    public class UpdateRfidRequest
    {
        public String RfidLabel { get; set; }
        public String RecordId { get; set; }
        public String Code { get; set; }
        public String CodeId { get; set; }
        public String UserId { get; set; }
    }

    // MULTIPLE RFID UNASSIGN
    public class MultipleRfidUnassignRequest
    {
        public string RecordId { get; set; }
        public String UserId { get; set; }
    }

    // INSERT RFID RECORD
    public class InsertRfidRequest
    {
        public String RfidLabel { get; set; }
        public String RfidType { get; set; }
        public String Code { get; set; }
        public String CodeId { get; set; }
        public String Description { get; set; }
        public String UserId { get; set; }
    }
}
