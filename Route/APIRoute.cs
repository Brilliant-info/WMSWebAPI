
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace WMSWebAPI.Route
{
    public class APIRoute
    {

        public const string Root = "api";
        public const string Environment = "staging";
        public const string Version = "v1";
        public const string Base = Root + "/" + Environment + "/" + Version;


        public static class _3PLBilling
        {
            public const string GetBillingGroupList = Base + "/3PLBilling/getBillingGroupList";
            public const string GetTransactionList = Base + "/3PLBilling/getTransactionList";
            public const string GetRateCardList = Base + "/3PLBilling/getRateCardList";
            public const string GetTransactionDetail = Base + "/3PLBilling/getTransactionDetail";
            public const string Save3PLData = Base + "/3PLBilling/save3PLData";
            public const string GetPreBillDetail = Base + "/3PLBilling/getPreBillDetail";
            public const string UpdateBill = Base + "/3PLBilling/updateBill";
            public const string SaveInvoice = Base + "/3PLBilling/saveInvoice";
            public const string GetInvoiceList = Base + "/3PLBilling/getInvoiceList";
            public const string PaymentBooking = Base + "/3PLBilling/paymentBooking";
            public const string PaymentDetail = Base + "/3PLBilling/paymentDetail";

            // 3pl object API//
            public const string GetValueAdd = Base + "/3PLBilling/getValueAdd";
            public const string GetActivityList = Base + "/3PLBilling/getActivityList";
            public const string AddActivityValueAdd = Base + "/3PLBilling/addActivityValueAdd";
            public const string AddValueAdd = Base + "/3PLBilling/AddValueAdd";
        }
        public static class AllocationPlan
        {
            public const string BatchList = Base + "/AllocationPlan/batchlist";
            public const string saveplandirect = Base + "/AllocationPlan/saveplandirect";
            public const string getallocationplansumry = Base + "/AllocationPlan/getallocationplansummary";
            public const string Getalcplndtl = Base + "/AllocationPlan/Getallocationplandetail";
            public const string getSearchalcplndtls = Base + "/AllocationPlan/getSearchallocationplandetails";
            public const string updateallocationplanQty = Base + "/AllocationPlan/updateallocationplanQty";
            public const string updateallocationplanintransitQty = Base + "/AllocationPlan/updateallocationplanintransitQty";
            public const string CreateCustomBatch = Base + "/AllocationPlan/CreateCustomBatch";
            public const string CancelBatch = Base + "/AllocationPlan/cancelbatch";
            public const string GetManualAllocationofSku = Base + "/AllocationPlan/GetManualAllocationofSku";
            public const string ManualallocationSearch = Base + "/AllocationPlan/ManualallocationSearch";
            public const string UpdateQtyManualallocation = Base + "/AllocationPlan/UpdateQtyManualallocation";
            public const string DeAllocate = Base + "/AllocationPlan/deAllocatePlan";
            public const string TotalShrotQty = Base + "/AllocationPlan/TotalShrotQty";
        }
        public static class APITP
        {
            public const string GetAPITPList = Base + "/APITP/GetAPITPList";

            public const string APITPSave = Base + "/APITP/APITPSave";
            public const string APITPActiveList = Base + "/APITP/APITPActiveList";
            public const string APITPLogList = Base + "/APITP/APITPLogList";
            public const string APITPKEY = Base + "/APITP/APITPKEY";
            public const string APITPReqReadJSON = Base + "/APITP/APITPReqReadJSON";
            public const string APITPRespReadJSON = Base + "/APITP/APITPRespReadJSON";
            public const string getAPITPParameterlist = Base + "/APITP/getAPITPParameterlist";
            public const string APITPTESTReadJSON = Base + "/APITP/APITPTESTReadJSON";
        }
        public static class ApprovalMaster
        {
            public const string GetApplication = Base + "/ApprovalMaster/GetApplication";
            public const string GetApproObject = Base + "/ApprovalMaster/GetApproObject";
            public const string GetApproEvent = Base + "/ApprovalMaster/GetApproEvent";
            public const string GetApproverList = Base + "/ApprovalMaster/GetApproverList";
            public const string SaveApprovalHead = Base + "/ApprovalMaster/SaveApprovalHead";
            public const string SaveApprovalDetail = Base + "/ApprovalMaster/SaveApprovalDetail";
            public const string GetMApprovalhead = Base + "/ApprovalMaster/GetMApprovalhead";
            public const string GetMApprovalDetail = Base + "/ApprovalMaster/GetMApprovalDetail";
            public const string RemoveApprovalUser = Base + "/ApprovalMaster/RemoveApprovalUser";

            public const string SaveapprovalTrans = Base + "/ApprovalMaster/SaveapprovalTrans";
            public const string GetApprovalTrans = Base + "/ApprovalMaster/GetApprovalTrans";
            public const string UpdateApprovalTrans = Base + "/ApprovalMaster/UpdateApprovalTrans";
            public const string SaveRemoveApprovalRec = Base + "/ApprovalMaster/SaveRemoveApprovalRec";
            public const string InsertApprovalTrans = Base + "/ApprovalMaster/InsertApprovalTrans";

        }
        public static class Barcode2DGenerator
        {
            public const string Get2DBarcode = Base + "/Barcode2DGenerator/Get2DBarcode";
        }

        public static class Barcode
        {
            public const string BarcodeList = Base + "/Barcode/BarcodeList";
            public const string BarcodeEditView = Base + "/Barcode/BarcodeEditView";
            public const string BarcodeSaveEdit = Base + "/Barcode/BarcodeSaveEdit";
            public const string ActiveTemplate = Base + "/Barcode/ActiveTemplate";
            public const string SaveTemplate = Base + "/Barcode/SaveTemplate";
            public const string BarcodeObjectList = Base + "/Barcode/BarcodeObjectList";
            public const string TemplateList = Base + "/Barcode/TemplateList";
            public const string SaveBarcodeConfig = Base + "/Barcode/SaveBarcodeConfig";
            public const string ViewBarcodeConfig = Base + "/Barcode/ViewBarcodeConfig";
        }
        public static class BillofLanding
        {
            public const string GetData = Base + "/BillofLanding/GetData";
            public const string UpdateData = Base + "/BillofLanding/UpdateData";
            public const string MasterBOL = Base + "/BillofLanding/MasterBOL";
        }
        public static class BusinessRule
        {
            public const string GetBusinessRuleList = Base + "/BusinessRule/GetBusinessRuleList";

            public const string SaveBusinessRule = Base + "/BusinessRule/SaveBusinessRule";
        }
        public static class Client
        {
            public const string GetClientList = Base + "/Client/GetClientList";
            public const string AddEditClient = Base + "/Client/AddEditClient";
            public const string EditClientDEtail = Base + "/EditClientDEtail";
            public const string GetObjectParameter = Base + "/Client/GetObjectParameter";
            public const string GetDdlObjParamValue = Base + "/Client/GetDdlObjParamValue";
            public const string SaveEditParameter = Base + "/Client/SaveEditParameter";

            public const string BindClientCategory = Base + "/Client/BindClientCategory";
            public const string GetBankDetails = Base + "/Client/GetBankDetails";
            public const string SaveBankDetails = Base + "/Client/SaveBankDetails";
            public const string EditBankDetails = Base + "/Client/EditBankDetails";
        }
        public static class CommFunAPI
        {
            public const string PalletList = Base + "/CommFunAPI/PalletList";
            public const string getLottablevalues = Base + "/CommFunAPI/getLottablevalues";
            public const string GetSKUUOM = Base + "/CommFunAPI/GetSKUUOM";
            public const string GetSKUSuggest = Base + "/CommFunAPI/GetSKUSuggest";
            public const string GetScanSuggest = Base + "/CommFunAPI/GetScanSuggest";
            public const string ScanInbound = Base + "/CommFunAPI/ScanInbound";
            public const string AssingUserlist = Base + "/CommFunAPI/AssingUserlist";
            public const string saveAssingment = Base + "/CommFunAPI/saveAssingment";
            public const string GetSKUSuggestInQC = Base + "/CommFunAPI/GetSKUSuggestInQC";
            public const string GetPOSKUSuggest = Base + "/CommFunAPI/GetPOSKUSuggest";
        }
        public static class GRN
        {
            public const string GetSKUList = Base + "/GRN/GetSKUList";
            public const string SaveSKUDetails = Base + "/GRN/SaveSKUDetails";
            public const string RemoveSKU = Base + "/GRN/RemoveSKU";
            public const string GetTransportList = Base + "/GRN/GetTransportList";
            public const string SaveGRNTransport = Base + "/GRN/SaveGRNTransport";
            public const string GetGRNTransportDetail = Base + "/GRN/GetGRNTransportDetail";
            public const string GetGRNHead = Base + "/GRN/GetGRNHead";
            public const string GetGRNDetail = Base + "/GRN/GetGRNDetail";
            public const string getGRNID = Base + "/GRN/getGRNID";
            public const string getPass = Base + "/GRN/getPass";
            public const string SaveGRNSKUDetail = Base + "/GRN/SaveGRNSKUDetail";
            public const string UpdateGrnStatus = Base + "/GRN/UpdateGrnStatus";
            public const string GetGatePassDetail = Base + "/GRN/GetGatePassDetail";
            public const string SaveGatePass = Base + "/GRN/SaveGatePass";
            /* SAVE GATEPASS LOTTABLE - 13 DEC 2023 */
            public const string SaveGatePassLottable = Base + "/GRN/SaveGatePassLottable";
            public const string CreateGatePassSkuSerials = Base + "/GRN/CreateGatePassSkuSerials";
            /* SAVE GATEPASS LOTTABLE - 13 DEC 2023 */
            /* GET BARCODE TO PRINT AS PER PATTERN - 04 DEC 2023 */
            public const string Closegrnpopup = Base + "/GRN/Closegrnpopup";
            public const string viewGetPass = Base + "/GRN/viewGetPass";
            public const string getPassIdListByID = Base + "/GRN/getPassIdListByID";
            /* GET BARCODE TO PRINT AS PER PATTERN - 04 DEC 2023 */
            public const string getBarcodeAsPerConfig = Base + "/GRN/GetBarcodeAsPerConfig";
            public const string getBarcodePrintData = Base + "/GRN/GetBarcodePrintData";
            /* GET BARCODE TO PRINT AS PER PATTERN - 04 DEC 2023 */
            /* GET BARCODE TO PRINT AS PER PATTERN - 19 DEC 2023 */
            public const string ShowGeneratedSerialList = Base + "/GRN/ShowGeneratedSerialList";
            /* GET BARCODE TO PRINT AS PER PATTERN - 19 DEC 2023 */
            /* GRN PRINT LABLE STYLE - 03 JUNE 2024 */
            public const string GetGrnPrintLabelStyle = Base + "/GRN/GetGrnPrintLabelStyle";
            public const string SaveGrnPrintLabelStyle = Base + "/GRN/SaveGrnPrintLabelStyle";
            /*  GRN PRINT LABLE STYLE - 03 JUNE 2024 */
        }
        public static class PO
        {
            public const string SavePOHead = Base + "/PO/SavePOHead";
            public const string SavePOSKUDetail = Base + "/PO/SavePOSKUDetail";
            public const string RemovePOSKU = Base + "/PO/RemovePOSKU";
            public const string GetInboundList = Base + "/PO/GetInboundList";
            public const string getLottablevalues = Base + "/PO/getLottablevalues";
            public const string GetPOSearchSKU = Base + "/PO/GetPOSearchSKU";
            public const string GetPODetail = Base + "/PO/GetPODetail";
            public const string DispPODetail = Base + "/PO/DispPODetail";
            public const string GetPOHead = Base + "/PO/GetPOHead";
            public const string getQualityvalues = Base + "/PO/getQualityvalues";
            public const string UpdatePOStatus = Base + "/PO/UpdatePOStatus";
            public const string closePOPopUP = Base + "/PO/closePOPopUP";
            public const string GetVendorList = Base + "/PO/vendorList";
            public const string cancelPO = Base + "/PO/cancelPO";
            public const string completeReceving = Base + "/PO/completeReceving";

            public const string GetTaskComplete = Base + "/PO/GetTaskComplete";
            public const string GetTaskCompleteSKULst = Base + "/PO/GetTaskCompleteSKULst";
        }
        public static class Communication
        {
            public const string GetCommunicationList = Base + "/Communication/GetCommunicationList";
            public const string SaveCommunication = Base + "/Communication/SaveCommunication";
            public const string RemoveCommunication = Base + "/Communication/RemoveCommunication";
        }
        public static class Company
        {
            public const string GetCompanyList = Base + "/Company/GetCompanyList";
            public const string AddCompany = Base + "/Company/AddCompany";
            public const string Editcompany = Base + "/Company/Editcompany";
            public const string EmailConfigSave = Base + "/Company/EmailConfigSave";
            public const string EmailConfigList = Base + "/Company/EmailConfigList";
            public const string GetholidayList = Base + "/Company/GetholidayList";
            public const string Saveholidaylist = Base + "/Company/Saveholidaylist";
            public const string SaveTaxlist = Base + "/Company/SaveTaxlist";
            public const string GetTaxList = Base + "/Company/GetTaxList";
            public const string EditTax = Base + "/Company/EditTax";
        }
        public static class Product
        {
            public const string GetProductList = Base + "/Product/GetProductList";
            public const string AddProduct = Base + "/Product/AddProduct";
            public const string GetCategoryList = Base + "/Product/GetCategoryList";
            public const string AddCategory = Base + "/Product/AddCategory";
            public const string GetSubCategoryList = Base + "/Product/GetSubCategoryList";
            public const string AddSubCategory = Base + "/Product/AddSubCategory";
            public const string ImageList = Base + "/Product/ImageList";
            public const string AddImage = Base + "/Product/AddImage";
            public const string RemoveImage = Base + "/Product/RemoveImage";
            public const string UploadImage = Base + "/Product/UploadImage";
            public const string UomList = Base + "/Product/UomList";
            public const string AddUom = Base + "/Product/AddUom";
            public const string LottableList = Base + "/Product/LottableList";
            public const string AddLottable = Base + "/Product/AddLottable";
            public const string RemoveLottable = Base + "/Product/RemoveLottable";
            public const string RemoveUom = Base + "/Product/RemoveUom";
            public const string packingfamilyddl = Base + "/Product/packingfamilyddl";
            public const string Uomddl = Base + "/Product/Uomddl";
            public const string Lottableddl = Base + "/Product/Lottableddl";
            public const string EditProduct = Base + "/Product/EditProduct";
            public const string ProductInventoryAssignList = Base + "/Product/ProductInventoryAssignList";
            public const string ProductLocationList = Base + "/Product/ProductLocationList";
            public const string AssighnSKULocation = Base + "/Product/AssighnSKULocation";
            public const string RemoveSKULocation = Base + "/Product/RemoveSKULocation";
            public const string LotableDataTypeddl = Base + "/Product/LotableDataTypeddl";

            public const string SaveBarcodePrdConfig = Base + "/Product/SaveBarcodePrdConfig";
            public const string GetLottableSave = Base + "/Product/GetLottableSave";
            public const string GetLottableRemove = Base + "/Product/GetLottableRemove";
            public const string GetLottableDropdown = Base + "/Product/GetLottableDropdown";
            public const string GetLottablebarcode = Base + "/Product/GetLottablebarcode";
            public const string GetPrdBarcodeConfig = Base + "/Product/GetPrdBarcodeConfig";


            public const string BindCategory = Base + "/Product/BindCategory";
            public const string GetPriceList = Base + "/Product/GetPriceList";
            public const string SavePrice = Base + "/Product/SavePrice";
            public const string GetGSTList = Base + "/Product/GetGSTList";
            public const string SaveGST = Base + "/Product/SaveGST";



            public const string Getskucodelist = Base + "/Product/Getskucodelist";
            public const string Getskusave = Base + "/Product/Getskusave";
            public const string Getskubind = Base + "/Product/Getskubind";
            public const string DispSkuConvDetail = Base + "/Product/DispSkuConvDetail";
            public const string RemoveskuConv = Base + "/Product/RemoveskuConv";
            public const string GetUOMDropdown = Base + "/Product/GetUOMDropdown";


            public const string GetattributeSave = Base + "/Product/GetattributeSave";
            public const string Getattributebind = Base + "/Product/Getattributebind";
            // public const string GetUOMDropdown = Base + "/Product/GetUOMDropdown";
            public const string EditGST = Base + "/Product/EditGST";
            public const string ddlGetGST = Base + "/Product/ddlGetGST";

        }
        public static class Contact
        {
            public const string ContactList = Base + "/Contact/ContactList";
            public const string SaveContact = Base + "/Contact/SaveContact";
        }
        public static class ConversionSKU
        {
            public const string GetConversionSKUList = Base + "/ConversionSKU/GetConversionSKUList";
            public const string GetConvSKUSuggestion = Base + "/ConversionSKU/GetConvSKUSuggestion";
            public const string GetSkuConversionSave = Base + "/ConversionSKU/GetSkuConversionSave";
            public const string SaveDTConverstion = Base + "/ConversionSKU/SaveDTConverstion";
            public const string GetconvDetail = Base + "/ConversionSKU/GetconvDetail";

            public const string GetconvHead = Base + "/ConversionSKU/GetconvHead";
        }
        public static class SO
        {
            public const string GetOutboundList = Base + "/SO/GetOutboundList";
            public const string GetOutboundListDP = Base + "/SO/GetOrderList";
            public const string SaveSOHead = Base + "/SO/SaveSOHead";
            public const string SaveSOSKUDetail = Base + "/SO/SaveSOSKUDetail";
            public const string RemoveSOSKU = Base + "/SO/RemoveSOSKU";
            public const string CancelSO = Base + "/SO/CancelSO";
            public const string GetSOSKUSuggest = Base + "/SO/GetSOSKUSuggest";
            public const string GetSOSKUUOM = Base + "/SO/GetSOSKUUOM";
            public const string GetSOSearchSKU = Base + "/SO/GetSOSearchSKU";
            public const string GetSODetail = Base + "/SO/GetSODetail";
            public const string GetStagingDetail = Base + "/SO/GetStagingDetail";
            public const string SaveStagingDetail = Base + "/SO/SaveStagingDetail";
            public const string GetSuggestedClient = Base + "/SO/getSuggestedClient";
            public const string GetSuggestedClientAddress = Base + "/SO/getSuggestedClientAddress";
            public const string SaveSkuKeyWard = Base + "/SO/saveSkuKeyWord";
            public const string RemoveSkuKeyWard = Base + "/SO/removeSkuKeyWord";
            public const string DeAllocateOrder = Base + "/SO/deAllocateOrder";
            public const string EditSOSKU = Base + "/SO/EditSOSKU";
        }
        public static class Customer
        {
            public const string GetCustomerList = Base + "/Customer/GetCustomerList";
            public const string AddCustomer = Base + "/Customer/AddCustomer";
            public const string ShowWarehouse = Base + "/Customer/ShowWarehouse";
            public const string SelectWarehouse = Base + "/Customer/SelectWarehouse";
            public const string RemoveWarehouse = Base + "/Customer/RemoveWarehouse";
            public const string EditCustomer = Base + "/Customer/EditCustomer";
            public const string UploadDocument = Base + "/Customer/UploadDocument";
            public const string AssginCustomerWarehouse = Base + "/Customer/AssginCustomerWarehouse";
            public const string UploadLogo = Base + "/Customer/UploadLogo";
            public const string GetCompanyList = Base + "/Customer/GetCompanyList";
            //Rahul API
            public const string sendOTPToCustomer = Base + "/Customer/sendOTPToCustomer";
            public const string validateOtp = Base + "/Customer/validateOtp";
            public const string sendActivationLink = Base + "/Customer/sendActivationLink";
            public const string demandObjectList = Base + "/Customer/demandObjectList";
            public const string saveDemandObject = Base + "/Customer/saveDemandObject";
            public const string objectList = Base + "/Customer/objectList";
            public const string removeObjectPoint = Base + "/Customer/removeObjectPoint";
            public const string GetDispDemandActivationLink = Base + "/Customer/DispDemandActivationLink";
            public const string GetLottableCutomer = Base + "/Customer/GetLottableCutomer";
            public const string GetLottableSave = Base + "/Customer/GetLottableSave";
            public const string GetLottableCustomerList = Base + "/Customer/GetLottableCustomerList";
            public const string GetLottablesavelist = Base + "/Customer/GetLottablesavelist";

        }
        public static class CycleCount
        {
            public const string CycleCountList = Base + "/CycleCount/CycleCountList";
            public const string CycleCountEdit = Base + "/CycleCount/CycleCountEdit";
            public const string CycleCountdetail = Base + "/CycleCount/CycleCountdetail";
            public const string CycleCountUpdate = Base + "/CycleCount/CycleCountUpdate";
        }
        public static class Dashboard
        {
            public const string GetDropdownList = Base + "/Dashboard/GetDropdownList";
            public const string getddlWarehouseList = Base + "/Dashboard/warehouselist";
        }
        public static class Dashboardpage
        {
            public const string GetInwardList = Base + "/DashboradPage/GetInwardList";
            public const string GetOutwardList = Base + "/DashboradPage/GetOutwardList";
            public const string GetTopInventoryList = Base + "/DashboradPage/GetTopInventoryList";
            public const string GetInwardOutwardList = Base + "/DashboradPage/GetInwardOutwardList";
            public const string CounterDashboardList = Base + "/DashboradPage/CounterDashboardList";
            public const string InwardBarchartList = Base + "/DashboradPage/InwardBarchartList";
            public const string OutwardPieChart = Base + "/DashboradPage/OutwardPieChart";
            public const string DispatchCountLast4Month = Base + "/DashboradPage/DispatchCountLast4Month";
        }
        public static class DemandPortal
        {
            public const string getOTP = Base + "/DemandPortal/getOTP";
            public const string UserRegister = Base + "/DemandPortal/UserRegister";
            public const string otpvalidate = Base + "/DemandPortal/otpvalidate";
            public const string UserLogin = Base + "/DemandPortal/UserLogin";
            public const string UserApprovalList = Base + "/DemandPortal/UserApprovalList";
            public const string userApprove = Base + "/DemandPortal/userApprove";
            public const string validateUser = Base + "/DemandPortal/validateUser";
            public const string OrderTemplateList = Base + "/DemandPortal/OrderTemplateList";
            public const string saveTemplate = Base + "/DemandPortal/saveTemplate";
            public const string ViewWmsOrder = Base + "/DemandPortal/ViewWmsOrder";
            public const string approveOrder = Base + "/DemandPortal/approveOrder";
            public const string ViewDispatchOrder = Base + "/DemandPortal/ViewDispatchOrder";
            public const string removeTemplate = Base + "/DemandPortal/removeTemplate";
            public const string saveTemplateOrder = Base + "/DemandPortal/saveTemplateOrder";
            public const string ReasonList = Base + "/DemandPortal/ReasonList";
            public const string RejectOrderList = Base + "/DemandPortal/RejectOrderList";
            public const string ResetPassword = Base + "/DemandPortal/ResetPassword";
            public const string validateResetPassword = Base + "/DemandPortal/validateResetPassword";
            public const string setupNewPass = Base + "/DemandPortal/setupNewPass";
            public const string SalesOrderReq = Base + "/DemandPortal/SalesOrderReq";
            public const string TemplateViewOrder = Base + "/DemandPortal/TemplateView";
            public const string GetRegiClientList = Base + "/DemandPortal/GetRegiClientList";
            public const string ViewDashboardOrder = Base + "/DemandPortal/ViewDashboardOrder";
            public const string DashboardDropdown = Base + "/DemandPortal/DashboardDropdown";
            public const string deleteOrder = Base + "/DemandPortal/deleteOrder";
            public const string UserReport = Base + "/DemandPortal/UserReport";
        }
        //public static class loginpage
        //{
        //    public const string GetLogin = Base + "/loginpage/GetLogin";
        //    public const string Logout = Base + "/loginpage/Logout";
        //    public const string ResetPassword = Base + "/loginpage/ResetPassword";
        //    public const string ForgetPassword = Base + "/loginpage/ForgetPassword";
        //    public const string sendOTP = Base + "/loginpage/sendOTP";
        //    public const string validateOTP = Base + "/loginpage/validateOTP";
        //    public const string UpdatePassword = Base + "/loginpage/UpdatePassword";
        //    public const string validateUserName = Base + "/loginpage/validateUserName";
        //    /* API to lock and unlock user sessions - 06 Dec 2023 */
        //    public const string CloseUserSessions = Base + "/loginpage/CloseUserSessions";
        //    /* API to lock and unlock user sessions - 06 Dec 2023 */
        //   }


            //public static class Dispatch
            //{
            //    public const string BatchDispatchList = Base + "/Dispatch/BatchDispatchList";

            //}

            //public static class PO
            //{
            //    public const string SavePOHead = Base + "/PO/SavePOHead";
            //    public const string SavePOSKUDetail = Base + "/PO/SavePOSKUDetail";
            //    public const string RemovePOSKU = Base + "/PO/RemovePOSKU";
            //    public const string GetInboundList = Base + "/PO/GetInboundList";
            //    public const string getLottablevalues = Base + "/PO/getLottablevalues";
            //    public const string GetPOSearchSKU = Base + "/PO/GetPOSearchSKU";
            //    public const string GetPODetail = Base + "/PO/GetPODetail";
            //    public const string DispPODetail = Base + "/PO/DispPODetail";
            //    public const string GetPOHead = Base + "/PO/GetPOHead";
            //    public const string getQualityvalues = Base + "/PO/getQualityvalues";
            //    public const string UpdatePOStatus = Base + "/PO/UpdatePOStatus";
            //    public const string closePOPopUP = Base + "/PO/closePOPopUP";
            //    public const string GetVendorList = Base + "/PO/vendorList";
            //    public const string cancelPO = Base + "/PO/cancelPO";
            //    public const string completeReceving = Base + "/PO/completeReceving";

            //    public const string GetTaskComplete = Base + "/PO/GetTaskComplete";
            //    public const string GetTaskCompleteSKULst = Base + "/PO/GetTaskCompleteSKULst";
            //}

   

            public static class Production
            {
                public const string GetProductionlist = Base + "/Production/GetProductionlist";
                public const string ProdHead = Base + "/Production/ProdHead";
                public const string SaverequestHead = Base + "/Production/SaverequestHead";
                public const string GetSaverequestdetail = Base + "/Production/GetSaverequestdetail";
                public const string GetDispSaverequestdetail = Base + "/Production/GetDispSaverequestdetail";
                public const string RemoveProdSKU = Base + "/Production/RemoveProdSKU";
            }

            public static class PutIn
            {
                public const string Putinlist = Base + "/PutIn/Putinlist";
                public const string GetPutinHead = Base + "/PutIn/GetPutinHead";
                public const string getPutinskulist = Base + "/PutIn/getPutinskulist";
                public const string SavePutinDetails = Base + "/PutIn/SavePutinDetails";
                public const string RemoveSKU = Base + "/PutIn/RemoveSKU";
                public const string UpdatePutin = Base + "/PutIn/UpdatePutin";
                public const string getlocationlist = Base + "/PutIn/getlocationlist";
                public const string updatelocatoin = Base + "/PutIn/updatelocatoin";
            }

            public static class QueryBuilder
            {
                public const string QueryBuilderList = Base + "/QueryBuilder/List";
                public const string QueryBuilderExec = Base + "/QueryBuilder/Exec";
                public const string QueryBuilderObject = Base + "/QueryBuilder/Object";
                public const string QueryBuilderAddUpdateDetail = Base + "/QueryBuilder/AddUpdateDetail";
                public const string QueryBuilderAddUpdateNotifications = Base + "/QueryBuilder/AddUpdateNotifications";
                public const string QueryBuilderNotificationSave = Base + "/QueryBuilder/NotificationSave";
                public const string QueryBuilderRemoveNotification = Base + "/QueryBuilder/RemoveNotification";
                public const string QueryExecButton = Base + "/QueryBuilder/ExecButton";
                public const string QueryBuilderObjectCol = Base + "/QueryBuilder/ObjectCol";
                public const string QueryBuilderQuerySave = Base + "/QueryBuilder/QuerySave";
                public const string QueryBuilderQueryFlag = Base + "/QueryBuilder/QueryFlag";
            }

            public static class RateCard
            {
                public const string GetRateCardList = Base + "/RateCard/getRateCardList";
                public const string GetUnitType = Base + "/RateCard/getUnitType";
                public const string GetAccName = Base + "/RateCard/getAccountName";
                public const string GetActivityType = Base + "/RateCard/getActivityType";
                public const string GetObjectZone = Base + "/RateCard/getObjectZone";
                public const string GetZone = Base + "/RateCard/getZone";
                public const string AddZone = Base + "/RateCard/addZone";
                public const string AddRateCard = Base + "/RateCard/addRateCard";
                public const string GetRateDetailById = Base + "/RateCard/getRateDetailById";
                public const string UpdateRateGroup = Base + "/RateCard/updateRateGroup";
                public const string RemoveRateGroup = Base + "/RateCard/removeRateGroup";
                public const string UpdateRateActive = Base + "/RateCard/updateRateActive";
                public const string GetRateParameterList = Base + "/RateCard/getRateParameterList";
                public const string GetRateParameter = Base + "/RateCard/getRateParameter";
                public const string AddRateParameter = Base + "/RateCard/addRateParameter";
                public const string GetRateParameterById = Base + "/RateCard/getRateParameterById";
                public const string GetRateHistory = Base + "/RateCard/getRateHistory";
                public const string UpdateActivityActive = Base + "/RateCard/updateActivityActive";
                public const string AddRateActivity = Base + "/RateCard/addRateActivity";
            }

            public static class Report
            {
                public const string GetGlobalReportList = Base + "/Report/GetGlobalReportList";
                public const string GetReportCategory = Base + "/Report/GetReportCategory";
                public const string GetPurchaseorderRecieptdetail = Base + "/Report/GetPurchaseorderRecieptdetail";
                public const string GetReportCategoryMenu = Base + "/Report/GetReportCategoryMenu";
                public const string GetSaleorderdetail = Base + "/Report/GetSaleorderdetail";
                public const string GetDispatchorderdetail = Base + "/Report/GetDispatchorderdetail";
                public const string GetVariencedetail = Base + "/Report/GetVariencedetail";
                public const string GetRecivingdetail = Base + "/Report/GetRecivingdetail";
                public const string GetAllocationGroupdetail = Base + "/Report/GetAllocationGroupdetail";
                public const string GetPickingdetail = Base + "/Report/GetPickingdetail";
                public const string GetOrderHistorydetail = Base + "/Report/GetOrderHistorydetail";
                public const string PackingOrderdetail = Base + "/Report/PackingOrderdetail";
                public const string CustomerInventoryLoc = Base + "/Report/CustomerInventoryLoc";
                public const string CustomerInventory = Base + "/Report/CustomerInventory";
                public const string InwardQualityCheckDetail = Base + "/Report/InwardQualityCheckDetail";
                public const string GetPutawaydetail = Base + "/Report/GetPutawaydetail";
                public const string CycleCountDetail = Base + "/Report/CycleCountDetail";
                public const string InternalTransferDetail = Base + "/Report/InternalTransferDetail";
                public const string OutwardQualityCheckDetail = Base + "/Report/OutwardQualityCheckDetail";
                public const string GetSalesreturndetail = Base + "/Report/GetSalesreturndetail";
                public const string PickingDetailsExportCsv = Base + "/Report/PickingDetailsExportCsv";
                public const string InvoiceDetail = Base + "/Report/InvoiceDetail";
            }

            public static class ReportStatic
            {
                public const string PurchaseOrderReport = Base + "/ReportStatic/PurchaseOrderReport";
                public const string GRNListReport = Base + "/ReportStatic/GRNListReport";
                public const string QCReport = Base + "/ReportStatic/QCReport";
                public const string PutInReport = Base + "/ReportStatic/PutInReport";
                public const string AllocationReport = Base + "/ReportStatic/AllocationReport";
                public const string PickUpReport = Base + "/ReportStatic/PickUpReport";
                public const string QCOutReport = Base + "/ReportStatic/QCOutReport";
                public const string PackingReport = Base + "/ReportStatic/PackingReport";
                public const string DispatchReport = Base + "/ReportStatic/DispatchReport";
                public const string InternalTransferReport = Base + "/ReportStatic/InternalTransferReport";
                public const string CycleCountReport = Base + "/ReportStatic/CycleCountReport";
                public const string SoReport = Base + "/ReportStatic/SoReport";
                public const string AllocatonShrotage = Base + "/ReportStatic/AllocatonShrotage";
                public const string NearexpairyReport = Base + "/ReportStatic/NearexpairyReport";
                public const string ABCAnalysisReport = Base + "/ReportStatic/ABCAnalysisReport";
                public const string SalesReturnReport = Base + "/ReportStatic/SalesReturnReport";
                public const string ProductlistReport = Base + "/ReportStatic/ProductlistReport";
                public const string locationlistReport = Base + "/ReportStatic/locationlistReport";
                public const string EmptylocationlistReport = Base + "/ReportStatic/EmptylocationlistReport";
                public const string DailyStockReport = Base + "/ReportStatic/DailyStockReport";
                public const string StockSummaryReport = Base + "/ReportStatic/StockSummaryReport";
                public const string DatewiseEmailReport = Base + "/ReportStatic/DatewiseEmailReport";
                public const string MovementReport = Base + "/ReportStatic/MovementReport";
                public const string ClientReport = Base + "/ReportStatic/ClientReport";
                public const string VendorReport = Base + "/ReportStatic/VendorReport";
                public const string CurrentStockReport = Base + "/ReportStatic/CurrentStockReport";
                public const string OccupencyDropDown = Base + "/ReportStatic/OccupencyDropDown";
                public const string getWHOccupancy = Base + "/ReportStatic/getWHOccupancy";
                public const string getSelfLifeAgingReport = Base + "/ReportStatic/getSelfLifeAgingReport";
                public const string getInventoryAgingReport = Base + "/ReportStatic/getInventoryAgingReport";
                public const string getInventoryDropdown = Base + "/ReportStatic/getInventoryDropdown";
                public const string getOrderwiseSummaryReport = Base + "/ReportStatic/getOrderwiseSummaryReport";
                public const string getStockledgerReport = Base + "/ReportStatic/getStockledgerReport";
                public const string getFSNReport = Base + "/ReportStatic/getFSNReport";
                public const string getLocationlTypeList = Base + "/ReportStatic/getLocationlTypeList";
                public const string getStockledgerSkuDropdown = Base + "/ReportStatic/getStockledgerSkuDropdown";
                public const string getCustomerSummary = Base + "/ReportStatic/getCustomerSummary";

                public const string InwardDetailList = Base + "/ReportStatic/InwardDetailList";
                public const string OutwardDetailList = Base + "/ReportStatic/OutwardDetailList";
                public const string AssetReportlist = Base + "/ReportStatic/AssetReportlist";
                public const string AssetReportDropdown = Base + "/ReportStatic/AssetReportDropdown";
            }

            public static class RFID
            {
                public const string GetRfidList = Base + "/RFID/GetRfidList";
                public const string SaveRfid = Base + "/RFID/SaveRfid";
                public const string GetRfidTagging = Base + "/RFID/GetRfidTagging";
                public const string UpdateRfid = Base + "/RFID/UpdateRfid";
                public const string MultipleRfidUnassign = Base + "/RFID/MultipleRfidUnassign";
                public const string InsertRfid = Base + "/RFID/InsertRfid";
            }

            //public static class SO
            //{
            //    public const string GetOutboundList = Base + "/SO/GetOutboundList";
            //    public const string GetOutboundListDP = Base + "/SO/GetOrderList";
            //    public const string SaveSOHead = Base + "/SO/SaveSOHead";
            //    public const string SaveSOSKUDetail = Base + "/SO/SaveSOSKUDetail";
            //    public const string RemoveSOSKU = Base + "/SO/RemoveSOSKU";
            //    public const string CancelSO = Base + "/SO/CancelSO";
            //    public const string GetSOSKUSuggest = Base + "/SO/GetSOSKUSuggest";
            //    public const string GetSOSKUUOM = Base + "/SO/GetSOSKUUOM";
            //    public const string GetSOSearchSKU = Base + "/SO/GetSOSearchSKU";
            //    public const string GetSODetail = Base + "/SO/GetSODetail";
            //    public const string GetStagingDetail = Base + "/SO/GetStagingDetail";
            //    public const string SaveStagingDetail = Base + "/SO/SaveStagingDetail";
            //    public const string GetSuggestedClient = Base + "/SO/getSuggestedClient";
            //    public const string GetSuggestedClientAddress = Base + "/SO/getSuggestedClientAddress";
            //    public const string SaveSkuKeyWard = Base + "/SO/saveSkuKeyWord";
            //    public const string RemoveSkuKeyWard = Base + "/SO/removeSkuKeyWord";
            //    public const string DeAllocateOrder = Base + "/SO/deAllocateOrder";
            //    public const string EditSOSKU = Base + "/SO/EditSOSKU";
            //}

            public static class Subscription
            {
                public const string UpdateTransaction = Base + "/Subscription/UpdateTransaction";
                public const string Checklimit = Base + "/Subscription/Checklimit";
                public const string DemoRegistration = Base + "/Subscription/DemoRegistration";
                public const string Checkusername = Base + "/Subscription/Checkusername";
                public const string GetSubscriptiondetail = Base + "/Subscription/GetSubscriptiondetail";
                public const string GetSubscriptionPlans = Base + "/Subscription/GetSubscriptionPlans";
                public const string GetInvoiceRpt = Base + "/Subscription/GetInvoiceRpt";
                public const string GetInvoiceDetails = Base + "/Subscription/GetInvoiceDetails";
                public const string CheckDummyData = Base + "/Subscription/CheckDummyData";
                public const string InsertDummyData = Base + "/Subscription/InsertDummyData";
                public const string SaveSubscribeplan = Base + "/Subscription/SaveSubscribeplan";
                public const string RemoveDummyData = Base + "/Subscription/RemoveDummyData";
                public const string ContactUsForm = Base + "/Subscription/ContactUsForm";
                public const string CheckSubScription = Base + "/Subscription/CheckSubScription";
                public const string getWarehouseIDandName = Base + "/Subscription/getWarehouseIDandName";

                // const string for Web Subscription
                public const string SaveCustSubscription = Base + "/Subscription/SaveCustSubscription";
                public const string SaveSubscriptionPaymentDetails = Base + "/Subscription/SaveSubscriptionPayment";
                public const string UpdateCustSubscriptionHead = Base + "/Subscription/UpdateCustSubscriptionHead";
                public const string UpdatePaymentDetails = Base + "/Subscription/UpdatePaymentDetails";
                public const string GetCouponID = Base + "/Subscription/GetCouponID";
                public const string CustomerDetailList = Base + "/Subscription/CustomerDetailList";
                public const string SendEmailOtp = Base + "/Subscription/SendEmailOtp";
                public const string SendSMSOtp = Base + "/Subscription/SendSMSOtp";
                public const string EmailOtpVerification = Base + "/Subscription/EmailOtpVerification";
                public const string MobileOtpVerification = Base + "/Subscription/MobileOtpVerification";
                public const string CheckUserNameAvailability = Base + "/Subscription/CheckUserNameAvailability";
                public const string RazorPayClientCreateOrder = Base + "/Subscription/RazorPayClientCreateOrder";

                // Customer WMS Subscriptions API
                public const string GetSubscriptionPaymentList = Base + "/Subscription/GetSubscriptionPaymentList";
                public const string GetSubscriptionTaxList = Base + "/Subscription/GetSubscriptionTaxList";
            }
            public static class TaskAssignment
            {
                public const string TaskList = Base + "/TaskAssignment/TaskList";
                public const string CreteNewTask = Base + "/TaskAssignment/CreteNewTask";
                public const string GetAssingmentList = Base + "/TaskAssignment/GetAssingmentList";
                public const string getAssingmentUserlist = Base + "/TaskAssignment/getAssingmentUserlist";
                public const string getAssingGrouplist = Base + "/TaskAssignment/getAssingGrouplist";
                public const string getuserSuggestlist = Base + "/TaskAssignment/getuserSuggestlist";
                public const string getOrdervalidation = Base + "/TaskAssignment/getOrdervalidation";
                public const string ReassignTask = Base + "/TaskAssignment/ReassignTask";
                public const string RemoveAssignmentTask = Base + "/TaskAssignment/RemoveAssignmentTask";
                public const string checkTaskAssignment = Base + "/TaskAssignment/checkTaskAssignment";
                public const string GetTaskAssignmentPOHead = Base + "/TaskAssignment/GetTaskAssignmentPOHead";
            }

            public static class Transfer
            {
                public const string GetTransferList = Base + "/Transfer/GetTransferList";
                public const string GetLocation = Base + "/Transfer/GetLocation";
                public const string GetPallet = Base + "/Transfer/GetPallet";
                public const string GetSkuList = Base + "/Transfer/GetSkuList";
                public const string GetLottableList = Base + "/Transfer/GetLottableList";
                public const string SaveHeadInternalTrans = Base + "/Transfer/SaveHeadInternalTrans";
                public const string getTransferDetails = Base + "/Transfer/getTransferDetails";
                public const string getTransferSkuList = Base + "/Transfer/getTransferSkuList";
                public const string saveDetailList = Base + "/Transfer/saveDetailList";
                public const string getHeadList = Base + "/Transfer/getHeadList";
                public const string viewTransferList = Base + "/Transfer/viewTransferList";
                public const string checkTransfBusinessRule = Base + "/Transfer/checkTransfBusinessRule";
                public const string GetToLocation = Base + "/Transfer/GetToLocation";
                public const string ddlTransferLocationList = Base + "/Transfer/ddlTransferLocationList";
                public const string getTRIDTO = Base + "/Transfer/getTRIDTO";
            }

            public static class Transload
            {
                public const string GetAll = Base + "/Transload/GetAll";
                public const string TransloadListID = Base + "/Transload/TransloadListID";
                public const string TranloadSave = Base + "/Transload/TranloadSave";
                public const string TranloadSaveDT = Base + "/Transload/TranloadSaveDT";
                public const string TranloadRemoveDT = Base + "/Transload/TranloadRemoveDT";
                public const string TransloadListReceving = Base + "/Transload/TransloadListReceving";
                public const string TranloadSaveReceiving = Base + "/Transload/TranloadSaveReceiving";
                public const string ChangeOrdertype = Base + "/Transload/ChangeOrdertype";
                public const string TranloadSaveRecDT = Base + "/Transload/TranloadSaveRecDT";
                public const string TranloadRemoveRecDT = Base + "/Transload/TranloadRemoveRecDT";
                public const string UpdateDockIdStatus = Base + "/Transload/UpdateDockIdStatus";
                public const string RemoveDockIdStatus = Base + "/Transload/RemoveDockIdStatus";
                public const string GetDispatchDetails = Base + "/Transload/GetDispatchDetails";
                public const string SaveDispatchHead = Base + "/Transload/SaveDispatchHead";
                public const string clientSugg = Base + "/Transload/clientSugg";
                public const string clientList = Base + "/Transload/clientList";
                public const string UOMList = Base + "/Transload/UOMList";
                public const string UOMSugg = Base + "/Transload/UOMSugg";
                public const string PallettypeList = Base + "/Transload/PallettypeList";
                public const string RateActivitylist = Base + "/Transload/RateActivitylist";
                public const string StagingList = Base + "/Transload/StagingList";
                public const string StagingSugg = Base + "/Transload/StagingSugg";
                public const string OrderTypeList = Base + "/Transload/OrderTypeList";
                public const string AddList = Base + "/Transload/AddList";
                public const string AddSugg = Base + "/Transload/AddSugg";
                public const string DockList = Base + "/Transload/DockList";
                public const string DockSugg = Base + "/Transload/DockSugg";
                public const string TransportList = Base + "/Transload/TransportList";
                public const string TransportSugg = Base + "/Transload/TransportSugg";
                public const string PalletList = Base + "/Transload/PalletList";
                public const string PalletSugg = Base + "/Transload/PalletSugg";
                public const string TLHeadDetail = Base + "/Transload/TLHeadDetail";

                //Order Adjustment
                public const string GetOrderAdjList = Base + "/GetOrderAdjList";
                public const string OrderAdjRemove = Base + "/OrderAdjRemove";
                public const string OrderAdjSave = Base + "/OrderAdjSave";
                public const string AddPalletList = Base + "/AddPalletList";

                //Staging

                //public const string UpdateStagingTraDetail = Base + "/StagingTraDetail";
                public const string UpdateStagingTraDetail = Base + "/UpdateStagingTraDetail";
                public const string GetStagingTraDetail = Base + "/GetStagingTraDetail";

                //Transport Detail
                public const string UpdateTransportDetail = Base + "/TransportDetail";
                public const string GetTransportDetailList = Base + "/GetTransportDetail";

                //StagingTraDetail


            }


            public static class User
            {
                public const string GetUserTypeList = Base + "/User/GetUserTypeList";
                public const string GetUserlist = Base + "/User/GetUserlist";
                public const string SaveUser = Base + "/User/SaveUser";
                public const string NewUserPass = Base + "/User/NewUserPass";
                public const string WarehouseList = Base + "/User/WarehouseList";
                public const string CustomerList = Base + "/User/CustomerList";
                public const string AssginUserWarehouse = Base + "/User/AssginUserWarehouse";
                public const string RemoveUserWarehouse = Base + "/User/RemoveUserWarehouse";
                public const string AssginUserCustomer = Base + "/User/AssginUserCustomer";
                public const string RemoveUserCustomer = Base + "/User/RemoveUserCustomer";
                public const string LockUnlockUser = Base + "/User/LockUnlockUser";
                public const string ClientList = Base + "/User/ClientList";
                public const string ClientAssignList = Base + "/User/ClientAssignList";
                public const string AssginUserClient = Base + "/User/AssginUserClient";
                public const string RemoveUserClient = Base + "/User/RemoveUserClient";
                public const string GetmRoleList = Base + "/User/GetmRoleList";
                public const string GetmRoleDetailList = Base + "/User/GetmRoleDetailList";
                public const string SaveUserRoleDetails = Base + "/User/SaveUserRoleDetails";
                public const string CheckuserPreRole = Base + "/User/CheckuserPreRole";
                public const string SaveRemSelectAllRole = Base + "/User/SaveRemSelectAllRole";

                public const string GetUserReportingToList = Base + "/User/GetUserReportingToList";
            }

            public static class Vendor
            {
                public const string GetVendorList = Base + "/Vendor/GetVendorList";
                public const string AddEditVendor = Base + "/Vendor/AddEditVendor";
                public const string vendorType = Base + "/Vendor/vendorType";
            }

            public static class Warehouse
            {
                public const string GetWarehouseList = Base + "/Warehouse/GetWarehouseList";
                public const string SaveWarehouse = Base + "/Warehouse/SaveWarehouse";
                public const string LocationList = Base + "/Warehouse/LocationList";
                public const string AddLocation = Base + "/Warehouse/AddLocation";
                public const string EditWarehouseList = Base + "/Warehouse/EditWarehouseList";
                public const string LocationType = Base + "/Warehouse/LocationType";
                public const string CycleCountLocation = Base + "/Warehouse/CycleCountLocation";
            }

            public static class _Winapp
            {
                public const string InboundOrderNo = Base + "/Winapp/InboundOrderNo";
                public const string InboundDetails = Base + "/Winapp/InboundDetails";
                public const string ProdOrderNo = Base + "/Winapp/ProdOrderNo";
                public const string ProdDetails = Base + "/Winapp/ProdDetails";

                public const string GetLabelfileName = Base + "/Winapp/GetLabelfileName";
                public const string GetInboundPrintBarcode = Base + "/Winapp/GetInboundPrintBarcode";
                public const string SaveGatePassLotWinapp = Base + "/Winapp/SaveGatePassLotWinapp";
                public const string SaveBarcodeHistory = Base + "/Winapp/SaveBarcodeHistory";
                public const string GetBarcodeWthlottable = Base + "/Winapp/GetBarcodeWthlottable";
                public const string GetBOMDDL = Base + "/Winapp/GetBOMDDL";
                public const string GetBOMDetails = Base + "/Winapp/GetBOMDetails";
                public const string GetFGDDL = Base + "/Winapp/GetFGDDL";
                public const string GetFGDetails = Base + "/Winapp/GetFGDetails";
                public const string GetBOMLIST = Base + "/Winapp/GetBOMLIST";
                public const string GetBOMSkuList = Base + "/Winapp/GetBOMSkuList";
                public const string GetBOMDetailsEdit = Base + "/Winapp/GetBOMDetailsEdit";
            }
            public static class Dispatch
            {
                public const string GetDispatchList = Base + "/Dispatch/GetDispatchList";
                public const string BatchDispatchList = Base + "/Dispatch/BatchDispatchList";
                public const string GetBatchDispatchDetail = Base + "/Dispatch/GetBatchDispatchDetail";

                public const string GetBatchDispatchEdit = Base + "/Dispatch/GetBatchDispatchEdit";
                public const string GetBatchDispatchDetailNEW = Base + "/Dispatch/GetBatchDispatchDetailNEW";
                public const string saveDispatchbyso = Base + "/Dispatch/saveDispatchbyso";
                public const string EditDispatchbyso = Base + "/Dispatch/EditDispatchbyso";
                public const string CarrierList = Base + "/Dispatch/getCarrierList";
                public const string TrackingDetail = Base + "/Dispatch/getTrackingDetail";
                public const string SaveTrackingDetail = Base + "/Dispatch/saveTrackingDetail";
                public const string TestMail = Base + "/Dispatch/testMail";
                public const string TestNotify = Base + "/Dispatch/testNotify";
                public const string SaveReturn = Base + "/Dispatch/markReturn";
                public const string UpdateQty = Base + "/Dispatch/updateQuantity";

                public const string getDispatchDriverList = Base + "/Dispatch/getDemandDriverList";
                public const string saveDispatchDriver = Base + "/Dispatch/saveDriver";
                public const string GetdriverTransportdetail = Base + "/Dispatch/GetdriverTransportdetail";

                public const string CheckDriverAssignInvoice = Base + "/Dispatch/CheckDriverAssignInvoice";

            }

            public static class Document
            {
                public const string GetDocumentList = Base + "/Document/GetDocumentList";
                public const string UploadDocument = Base + "/Document/UploadDocument";
                public const string Savedocument = Base + "/Document/Savedocument";
                public const string RemoveDocument = Base + "/Document/RemoveDocument";
                public const string DownloadDocument = Base + "/Document/DownloadDocument";
            }

            public static class DPDashboard
            {
                public const string CounterDPDashboardList = Base + "/DPDashboard/CounterDPDashboardList";
                public const string DispatchCountLast4MonthDP = Base + "/DPDashboard/DispatchCountLast4MonthDP";
            }
            public static class EmailSmSNotification
            {

                public const string EmailSmSList = Base + "/EmailSmSNotification/EmailSmSList";
                public const string EmailSmsActive = Base + "/EmailSmSNotification/EmailSmsActive";
                public const string EmailSMSTemplate = Base + "/EmailSmSNotification/EmailSMSTemplate";
                public const string SaveEmailSMS = Base + "/EmailSmSNotification/SaveEmailSMS";
                public const string RemoveEmailSMS = Base + "/EmailSmSNotification/RemoveEmailSMS";
                public const string GetroleSaveEmailSMS = Base + "/EmailSmSNotification/GetroleSaveEmailSMS";
                public const string RemoveRoleEmailSMS = Base + "/EmailSmSNotification/RemoveRoleEmailSMS";
            }


            public static class ImportDesigner
            {
                public const string ImportDesignerList = Base + "/ImportDesigner/ImportDesignerList";
                public const string ImportDesignerObjectList = Base + "/ImportDesignerObjectList/CompanyActive";
                public const string ImpDesignTableColoumlist = Base + "/ImportDesigner/ImpDesignTableColoumlist";
                public const string ImpDesignTblColoumDataType = Base + "/ImportDesigner/ImpDesignTblColoumDataType";
                public const string ImportDesignerSave = Base + "/ImportDesigner/ImportDesignerSave";
                public const string ImportDesignerViewList = Base + "/ImportDesigner/ImportDesignerViewList";
                public const string CustomImportDetailSavedata = Base + "/ImportDesigner/CustomImportDetailSavedata";
            }

            public static class InboundQC
            {
                public const string QCList = Base + "/InboundQC/QCList";
                public const string GetQCHead = Base + "/InboundQC/GetQCHead";
                public const string getQCID = Base + "/InboundQC/getQCID";
                public const string GetQCDetail = Base + "/InboundQC/GetQCDetail";
                public const string SaveQCDetail = Base + "/InboundQC/SaveQCDetail";
                public const string GetReasoncode = Base + "/InboundQC/GetReasoncode";
                public const string UpdateQCStatus = Base + "/InboundQC/UpdateQCStatus";
                public const string RemoveQCSKU = Base + "/InboundQC/RemoveQCSKU";
            }

            public static class Inventory
            {
                public const string GetInventoryList = Base + "/Inventory/GetInventoryList";
                public const string GetInventoryExport = Base + "/Inventory/GetInventoryExport";
                public const string GetAvailInventoryList = Base + "/Inventory/GetAvailInventoryList";
                public const string GetHoldInventoryList = Base + "/Inventory/GetHoldInventoryList";
                public const string GetAllocateInventoryList = Base + "/Inventory/GetAllocateInventoryList";
                public const string GetRejectedInventoryList = Base + "/Inventory/GetRejectedInventoryList";
                public const string CreateCyclePlan = Base + "/Inventory/CreateCyclePlan";
                public const string HoldInventory = Base + "/Inventory/HoldInventory";
                public const string GetAllocateInventoryExport = Base + "/Inventory/GetAllocateInventoryExport";
                public const string DeallocateInventory = Base + "/Inventory/DeallocateInventory";
                public const string GetHoldInventoryExport = Base + "/Inventory/GetHoldInventoryExport";
                public const string ReleaseInventory = Base + "/Inventory/ReleaseInventory";
                public const string GetRejectedInventoryExport = Base + "/Inventory/GetRejectedInventoryExport";
                public const string AdjustInventory = Base + "/Inventory/AdjustInventory";
                public const string InvLocationByWare = Base + "/Inventory/InvLocationByWare";
                public const string GetInvBusinessrule = Base + "/Inventory/GetInvBusinessrule";

                public const string GetPallet = Base + "/Inventory/GetPallet";
                public const string SaveTransfer = Base + "/Inventory/SaveTransfer";
            }

            public static class IOTConfig
            {
                public const string IOTConfigList = Base + "/IOTConfig/IOTConfigList";
                public const string SaveIOTConfig = Base + "/IOTConfig/SaveIOTConfig";
                public const string LocationTypeIOTConfig = Base + "/IOTConfig/LocationTypeIOTConfig";
                public const string deviceTypeIOTConfig = Base + "/IOTConfig/deviceTypeIOTConfig";
                public const string IOTConfigTemp = Base + "/IOTConfig/IOTConfigTemp";
                public const string IOTConfigReport = Base + "/IOTConfig/IOTConfigReport";
                public const string IOTLocbind = Base + "/IOTConfig/IOTLocbind";
                public const string IOTdeviceIDbind = Base + "/IOTConfig/IOTdeviceIDbind";
            }

            public static class Labour
            {
                public const string GetAll = Base + "/Labour/GetAll";
                public const string InsertUpdateLabour = Base + "/Labour/InsertUpdateLabour";
                public const string getShfitList = Base + "/Labour/getShfitList";
                public const string addNewShift = Base + "/Labour/addNewShift";
                public const string getLabourVendorList = Base + "/Labour/getLabourVendorList";
                public const string getLabourActivityList = Base + "/Labour/getLabourActivityList";
                public const string InsertLabourDetails = Base + "/Labour/InsertLabourDetails";
                public const string getDetailLabourList = Base + "/Labour/getDetailLabourList";
                public const string TimeTrackingReport = Base + "/Labour/TimeTrackingReport";
                public const string removeLabour = Base + "/Labour/removeLabour";
            }


            public static class loginpage
            {
                public const string GetLogin = Base + "/loginpage/GetLogin";
                public const string Logout = Base + "/loginpage/Logout";
                public const string ResetPassword = Base + "/loginpage/ResetPassword";
                public const string ForgetPassword = Base + "/loginpage/ForgetPassword";
                public const string sendOTP = Base + "/loginpage/sendOTP";
                public const string validateOTP = Base + "/loginpage/validateOTP";
                public const string UpdatePassword = Base + "/loginpage/UpdatePassword";
                public const string validateUserName = Base + "/loginpage/validateUserName";
                /* API to lock and unlock user sessions - 06 Dec 2023 */
                public const string CloseUserSessions = Base + "/loginpage/CloseUserSessions";
                /* API to lock and unlock user sessions - 06 Dec 2023 */
            }

            public static class Menupage
            {
                public const string GetMenu = Base + "/Menupage/GetMenu";
            }

            public static class OutboundQC
            {
                public const string GetQCList = Base + "/OutboundQC/GetQCList";
                public const string GetBatchQCList = Base + "/OutboundQC/GetBatchQCList";
                public const string GetReasonCode = Base + "/OutboundQC/GetReasonCode";
                public const string GetQCDetail = Base + "/OutboundQC/GetQCDetail";
                public const string GetQCSuggestSKU = Base + "/OutboundQC/GetQCSuggestSKU";
                public const string GetQCSKUDetail = Base + "/OutboundQC/GetQCSKUDetail";
                public const string SaveQCSKUDetail = Base + "/OutboundQC/SaveQCSKUDetail";
                public const string FinalSaveQCDetail = Base + "/OutboundQC/FinalSaveQCDetail";
                public const string QCRemoveSKU = Base + "/OutboundQC/QCRemoveSKU";
            }

            public static class Packing
            {
                public const string GetStagingList = Base + "/Packing/GetStagingList";
                public const string GetStagingSOList = Base + "/Packing/GetStagingSOList";
                public const string GetStagingSODetail = Base + "/Packing/GetStagingSODetail";
                public const string ShippingPallet = Base + "/Packing/ShippingPallet";
                public const string StagingSKUList = Base + "/Packing/StagingSKUList";
                public const string StagingSKUDetail = Base + "/Packing/StagingSKUDetail";
                public const string SaveStagingSKUDetail = Base + "/Packing/SaveStagingSKUDetail";
                public const string RemoveSKUDetail = Base + "/Packing/removeSKUDetail";
                public const string FinalSavePacking = Base + "/Packing/finalSavePacking";
                public const string getTransportList = Base + "/Packing/getTransportList";
                public const string UpdateTranspoter = Base + "/Packing/UpdateTranspoter";
                public const string PackingLocation = Base + "/Packing/packingLocation";
                public const string DirectPackingOrders = Base + "/Packing/DirectPackingOrders";
            }

            public static class PackingMaster
            {
                public const string GetPackingMasterList = Base + "/GetPackingMasterList";
                public const string SavePackingMaster = Base + "/SavePackingMaster";

            }

            public static class Parameter
            {
                public const string GetParameterList = Base + "/Parameter/GetParameterList";
                public const string AddParameter = Base + "/Parameter/AddParameter";
            }

            public static class PickUp
            {
                public const string GetPickUpList = Base + "/PickUp/GetPickUpList";
                public const string GetPickUpDetail = Base + "/PickUp/GetPickUpDetail";
                public const string FinalSavePickUp = Base + "/PickUp/FinalSavePickUp";
                public const string CancelPickUp = Base + "/PickUp/cancelPickUp";
                public const string MarkPacked = Base + "/PickUp/MarkPacked";
                public const string UpdatePickUp = Base + "/PickUp/updatePickup";
                public const string EditPickUpQty = Base + "/PickUp/EditPickUpQty";
                public const string RevertPickUpQty = Base + "/PickUp/RevertPickUpQty";
                public const string ChkOrderAssignToUser = Base + "/PickUp/ChkOrderAssignToUser";
            }
        }
    }
