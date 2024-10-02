namespace WMSWebAPI.Models.V1.Request
{
    public class BillofLanding
    {
        public Int64 CustomerOrderNo { get; set; }
        public string ShipFromName { get; set; }
        public string ShipFromAddress { get; set; }
        public string ShipFromCityStateZip { get; set; }
        public string ShipFromSid { get; set; }
        public string FOB { get; set; }
        public string ShipToName { get; set; }
        public string ShipToAddress { get; set; }
        public string ShipToCityStateZip { get; set; }
        public string ShipToSid { get; set; }
        public string ShipToFob { get; set; }
        public string ThirdPartyName { get; set; }
        public string ThirdPartyAddress { get; set; }
        public string ThirdPartyCityStateZip { get; set; }
        public string ThirdPartySpecialInstuction { get; set; }
        public string BillOfLadingNo { get; set; }
        // public string Carrier { get; set; }
        public string TrailerNumber { get; set; }
        public string SealNumbers { get; set; }
        public string SCAC { get; set; }
        public string ProNumber { get; set; }
        public string FreightChargeTerms { get; set; }
        public string Prepaid { get; set; }
        public string Collect { get; set; }
        public string ThrdParty { get; set; }
        public string MasterBillofLading { get; set; }
        public string CODCollect { get; set; }
        public string CODPrepaid { get; set; }
        public string CODCustAccept { get; set; }
        public string TrailerByShipper { get; set; }
        public string TrailerByDriver { get; set; }
        public string FreightByShipper { get; set; }
        public string FreightByDriver { get; set; }
        public string FreightByPieces { get; set; }
        public Int64 UserId { get; set; }
        public Int64 WarehouseId { get; set; }
        public Int64 CustomerId { get; set; }
        public Int64 CompanyID { get; set; }
        public string TransporterName { get; set; }
        public Int64 TransportId { get; set; }
        public Int64 PackingId { get; set; }


    }
    public class BillOfLandingGetData
    {
        public Int64 BillORDER_ID { get; set; }
    }
    public class BillOfLandingGetDataInfo
    {
        public Int64 BillORDER_ID { get; set; }
    }

    public class reqMasterBOL
    {
        public Int64 orderNo { get; set; }
        public Int64 EntryType { get; set; }
        public Int64 customerId { get; set; }
    }
}
