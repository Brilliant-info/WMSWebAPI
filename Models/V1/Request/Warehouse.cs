using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WMSWebAPI.Models.V1.Request
{
    public class GetwarehouseListRequest
    {
        public string CurrentPage { get; set; }
        public string RecordLimit { get; set; }
        public string CompanyId { get; set; }
        public string UserId { get; set; }
        public string CustomerId { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string Filter { get; set; }
        public string Search { get; set; }
    }
    public class SaveWarehouseRequest
    {
        public string CompanyId { get; set; }
        public string CustomerId { get; set; }
        public string WarehouseId { get; set; }
        public string UserId { get; set; }
        public string WarehouseCode { get; set; }
        public string WarehouseName { get; set; }
        public string Type { get; set; }
        public string Remark { get; set; }
        public string Active { get; set; }
        public string ID { get; set; }
        public string LocalRate { get; set; }
        public string OutstationRate { get; set; }
    }
    public class GetWarehouseLocationListRequest
    {
        public string CurrentPage { get; set; }
        public string RecordLimit { get; set; }
        public string CompanyId { get; set; }
        public string UserId { get; set; }
        public string CustomerId { get; set; }
        public string WarehouseId { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string Filter { get; set; }
        public string Search { get; set; }
    }
    public class SaveWarehouseLocationListRequest
    {
        public string LocationCode { get; set; }
        public string ID { get; set; }
        public string CompanyID { get; set; }
        public string UserID { get; set; }
        public string WarehouseID { get; set; }
        public string LocationType { get; set; }
        public string ZoneLocation { get; set; }
        public string SortCode { get; set; }
        public string ZoneCode { get; set; }
        public string Shelf { get; set; }
        public string Section { get; set; }
        public string Pathway { get; set; }
        public string Floor { get; set; }
        public string Building { get; set; }
        public string CapacityIn { get; set; }
        public string Number { get; set; }
        public string Length { get; set; }
        public string Height { get; set; }
        public string Width { get; set; }
        public string CustomerID { get; set; }
        public string Active { get; set; }

    }
    public class editWarehouseList
    {
        public string Id { get; set; }
    }
    public class ddlWarehouseLocationTypeList
    {
        public string userId { get; set; }
    }

    public class CreateCyclelocationRequest
    {
        public string Object { get; set; }
        public string UserId { get; set; }
        public string CustomerId { get; set; }
        public string WarehouseId { get; set; }
        public string locationids { get; set; }
        public string PlanTitle { get; set; }
        public string PlanID { get; set; }
    }
}
