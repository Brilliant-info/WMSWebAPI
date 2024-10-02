using System.ComponentModel.DataAnnotations;

namespace WMSWebAPI.Models.V1.Request
{
    public class GetCycleCountListRequest
    {
        public string CurrentPage { get; set; }
        public string RecordLimit { get; set; }
        public string UserId { get; set; }
        public string CustomerId { get; set; }
        public string WarehouseId { get; set; }
        public string Search { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string Filter { get; set; }
    }
    public class CycleCountEditRequest
    {
        public string UserId { get; set; }
        public string CountHeadID { get; set; }
    }
    public class CycleCountdetailRequest
    {
        public string CurrentPage { get; set; }
        public string RecordLimit { get; set; }
        public string UserId { get; set; }
        public string CountHeadID { get; set; }
        public string Search { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string Filter { get; set; }
    }
    public class CycleCountUpdateRequest
    {
        public string UserId { get; set; }
        public string Active { get; set; }
        public string StatusName { get; set; }
        public string CycleCountId { get; set; }
    }
}
