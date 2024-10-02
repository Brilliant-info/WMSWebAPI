using Newtonsoft.Json.Linq;
using System.Data.SqlClient;
using System.Data;
using System.Text.RegularExpressions;
using WMSWebAPI.Models.V1.Request;
using System.Text.Json;

namespace WMSWebAPI.Utility.V1
{
    public class BillOfLandingUtility
    {
        SqlParameter[] param;
        DBActivity obj;
        public BillOfLandingUtility()
        {
            obj = new DBActivity();
        }
        private double getCoTotalPkgs = 0.00;
        private double getCoTotalWeight = 0.00;
        private double getCrTotalHandlingUnitQty = 0.00;
        private double getCrTotalPackageQty = 0.00;
        private double getCrTotalWeight = 0.00;
        private double getCrTotalPCS = 0.00;

        public async Task<JsonElement> GetData(BillOfLandingGetData req)
        {
            DataSet ds1 = new DataSet();

            param = new SqlParameter[]
                    {
                        new SqlParameter("@ORDER_ID",req.BillORDER_ID)
                    };

            //ds1 = obj.Return_DataSet("GetBillOFLanding", param);
            return await obj.ConvertDataSetToJObject(obj.Return_DataSet("GetBillOFLanding", param));
            // int OrderId = Convert.ToInt32(req.BillORDER_ID);

            //string jsonData = "var jsonObject = {";
            // try
            // {
            //     int getRowCount = ds1.Tables[0].Rows.Count;
            //     if (ds1.Tables[0].Rows.Count > 0)
            //     {
            //         for (int rc = 0; rc <= (getRowCount - 1); rc++)
            //         {

            //             string BarcodeImage = ds1.Tables[0].Rows[rc]["BillofladingNo"].ToString();
            //             string ProBarcodeImage =  ds1.Tables[0].Rows[rc]["ProNumber"].ToString();


            //             string getShipFromName = ds1.Tables[0].Rows[rc]["ShipFromName"].ToString();
            //             string getShipFromAddress = ds1.Tables[0].Rows[rc]["ShipFromAdd"].ToString();
            //             string filterShipFromAddress = Regex.Replace(getShipFromAddress, @"\t|\n|\r", "");
            //             string getShipFromCityStateZip = ds1.Tables[0].Rows[rc]["ShipFromDetails"].ToString();
            //             string filterShipFromCityStateZip = Regex.Replace(getShipFromCityStateZip, @"\t|\n|\r", "");
            //             string getShipFromSid = ds1.Tables[0].Rows[rc]["ShipFromSID"].ToString();
            //             string getShipFromFob = ds1.Tables[0].Rows[rc]["ShipFromFOB"].ToString();
            //             string getShipToName = ds1.Tables[0].Rows[rc]["ShipToName"].ToString();
            //             string getShipToAddress = ds1.Tables[0].Rows[rc]["ShipToAdd"].ToString();
            //             string filterShipToAddress = Regex.Replace(getShipToAddress, @"\t|\n|\r", "");
            //             string getShipToCityStateZip = ds1.Tables[0].Rows[rc]["ShipToDetails"].ToString();
            //             string filterShipToCityStateZip = Regex.Replace(getShipToCityStateZip, @"\t|\n|\r", "");
            //             string getShipToSid = ds1.Tables[0].Rows[rc]["ShipToSid"].ToString();
            //             string getShipToFob = ds1.Tables[0].Rows[rc]["ShipToFob"].ToString();
            //             string getThirdPartyName = ds1.Tables[0].Rows[rc]["ThirdPartyName"].ToString();
            //             string getThirdPartyAddress = ds1.Tables[0].Rows[rc]["ThirdPartyAddress"].ToString();
            //             string filterThirdPartyAddress = Regex.Replace(getThirdPartyAddress, @"\t|\n|\r", "");
            //             string getThirdPartyCityStateZip = ds1.Tables[0].Rows[rc]["ThirdPartyCityStateZip"].ToString();
            //             string filterThirdPartyCityStateZip = Regex.Replace(getThirdPartyCityStateZip, @"\t|\n|\r", "");
            //             string getSPInstruction = ds1.Tables[0].Rows[rc]["ThirdPartySpecialInstuction"].ToString();
            //             string getFreightChargeTerm = ds1.Tables[0].Rows[rc]["FreightChargeTerms"].ToString();
            //             string getBillOfLadingNo = ds1.Tables[0].Rows[rc]["BillofladingNo"].ToString();
            //             string getCarrier = ds1.Tables[0].Rows[rc]["Carrier"].ToString();
            //             string getTrailerNumber = ds1.Tables[0].Rows[rc]["TrailerNumber"].ToString();
            //             string getSealNumbers = ds1.Tables[0].Rows[rc]["SealNumber"].ToString();
            //             string getSCAC = ds1.Tables[0].Rows[rc]["SCAC"].ToString();
            //             string getProNumber = ds1.Tables[0].Rows[rc]["ProNumber"].ToString();
            //             string getPrePaid = ds1.Tables[0].Rows[rc]["PrePaid"].ToString();
            //             string getCollect = ds1.Tables[0].Rows[rc]["Collect"].ToString();
            //             string getThirdParty = ds1.Tables[0].Rows[rc]["ThirdParty"].ToString();
            //             string getMasterBillLanding = ds1.Tables[0].Rows[rc]["MasterBillLanding"].ToString();
            //             string getTrailerByShipper = ds1.Tables[0].Rows[rc]["TrailerByShipper"].ToString();
            //             string getTrailerByDriver = ds1.Tables[0].Rows[rc]["TrailerByDriver"].ToString();
            //             string getFreightByShipper = ds1.Tables[0].Rows[rc]["FreightByShipper"].ToString();
            //             string getFreightByDriver = ds1.Tables[0].Rows[rc]["FreightByDriver"].ToString();
            //             string getFreightByPieces = ds1.Tables[0].Rows[rc]["FreightByPieces"].ToString();
            //             string getCODAmount = ds1.Tables[0].Rows[rc]["CODAmount"].ToString();
            //             string getCODFeeTermsCollect = ds1.Tables[0].Rows[rc]["CODFeeTermsCollect"].ToString();
            //             string getCODFeeTermsPrepaid = ds1.Tables[0].Rows[rc]["CODFeeTermsPrepaid"].ToString();
            //             string getCODFeeTermsCustChAccept = ds1.Tables[0].Rows[rc]["CODFeeTermsCustChAccept"].ToString();

            //             string hdnCompanyId = ds1.Tables[0].Rows[rc]["CompanyID"].ToString();
            //             string hdnUserId = ds1.Tables[0].Rows[rc]["UserId"].ToString();
            //             string hdnWarehouseId = ds1.Tables[0].Rows[rc]["WarehouseId"].ToString();
            //             string hdnCustomerId = ds1.Tables[0].Rows[rc]["CustomerId"].ToString();
            //             string getCurrentDate = DateTime.Now.ToString("MM/dd/yyyy");

            //             jsonData += "CurrentDate: '" + getCurrentDate + "',";
            //             jsonData += "ShipFromName: '" + getShipFromName + "',";
            //             jsonData += "ShipFromAddress: '" + filterShipFromAddress + "',";
            //             jsonData += "ShipFromCityStateZip: '" + filterShipFromCityStateZip + "',";
            //             jsonData += "ShipFromSid: '" + getShipFromSid + "',";
            //             jsonData += "ShipFromFob: '" + getShipFromFob + "',";
            //             jsonData += "ShipToName: '" + getShipToName + "',";
            //             jsonData += "ShipToAddress: '" + filterShipToAddress + "',";
            //             jsonData += "ShipToCityStateZip: '" + filterShipToCityStateZip + "',";
            //             jsonData += "ShipToSid: '" + getShipToSid + "',";
            //             jsonData += "ShipToFob: '" + getShipToFob + "',";
            //             jsonData += "ThirdPartyName:  '" + getThirdPartyName + "',";
            //             jsonData += "ThirdPartyAddress:  '" + filterThirdPartyAddress + "',";
            //             jsonData += "ThirdPartyCityStateZip: '" + filterThirdPartyCityStateZip + "',";
            //             jsonData += "ThirdPartySpecialInstuction: '" + getSPInstruction + "',";
            //             jsonData += "FreightChargesTerms: '" + getFreightChargeTerm + "',";
            //             jsonData += "BillOfLadingNo: '" + getBillOfLadingNo + "',";
            //             jsonData += "Carrier: '" + getCarrier + "',";
            //             jsonData += "TrailerNumber: '" + getTrailerNumber + "',";
            //             jsonData += "SealNumbers: '" + getSealNumbers + "',";
            //             jsonData += "SCAC: '" + getSCAC + "',";
            //             jsonData += "ProNumber: '" + getProNumber + "',";
            //             jsonData += "PrePaid: '" + getPrePaid + "',";
            //             jsonData += "Collect: '" + getCollect + "',";
            //             jsonData += "ThirdParty: '" + getThirdParty + "',";
            //             jsonData += "MasterBillLanding: '" + getMasterBillLanding + "',";
            //             jsonData += "TrailerByShipper: '" + getTrailerByShipper + "',";
            //             jsonData += "TrailerByDriver: '" + getTrailerByDriver + "',";
            //             jsonData += "FreightByShipper: '" + getFreightByShipper + "',";
            //             jsonData += "FreightByDriver: '" + getFreightByDriver + "',";
            //             jsonData += "FreightByPieces: '" + getFreightByPieces + "',";
            //             if (getCODAmount == "0")
            //             {
            //                 jsonData += "CODAmount: '',";

            //             }
            //             else
            //             {
            //                 jsonData += "CODAmount: '" + getCODAmount + "',";

            //             }
            //             jsonData += "CODFeeTermsCollect: '" + getCODFeeTermsCollect + "',";
            //             jsonData += "CODFeeTermsPrepaid: '" + getCODFeeTermsPrepaid + "',";
            //             jsonData += "CODFeeTermsCustChAccept: '" + getCODFeeTermsCustChAccept + "',";
            //             jsonData += "CustomerOrderInfo: " + getCustomerOrderDetails(OrderId) + "',";
            //             jsonData += "CarrierInfo: " + getCarrierDetails(OrderId) + "',";
            //             jsonData += "TotalPkgs: '" + convertToDoubleString(getCoTotalPkgs.ToString()) + "',";
            //             jsonData += "TotalWeight: '" + convertToDoubleString(getCoTotalWeight.ToString()) + "',";
            //             jsonData += "TotalHandlingUnitQty: '" + convertToDoubleString(getCrTotalHandlingUnitQty.ToString()) + "',";
            //             jsonData += "TotalPackageQty: '" + convertToDoubleString(getCrTotalPackageQty.ToString()) + "',";
            //             jsonData += "CrTotalWeight: '" + convertToDoubleString(getCrTotalWeight.ToString()) + "',";
            //             jsonData += "TotalPCS: '" + convertToDoubleString(getCrTotalPCS.ToString()) + "',";

            //             jsonData += "hdnCompanyId: '" + hdnCompanyId + "',";
            //             jsonData += "hdnUserId: '" + hdnUserId + "',";
            //             jsonData += "hdnWarehouseId: '" + hdnWarehouseId + "',";
            //             jsonData += "hdnCustomerId: '" + hdnCustomerId + "',";
            //             if (BarcodeImage == "-" || BarcodeImage == "")
            //             {
            //                 jsonData += "BarcodeImage: '',";
            //             }
            //             else
            //             {
            //                 jsonData += "BarcodeImage: '" + BarcodeImage + "',";
            //             }

            //             if (getProNumber == "-" || getProNumber == "")
            //             {
            //                 jsonData += "ProBarcodeImage: ''";

            //             }
            //             else
            //             {
            //                 jsonData += "ProBarcodeImage: '" + ProBarcodeImage + "'";

            //             }

            //         }
            //     }



            //     jsonData += "}";
            // }
            // catch (Exception ex) { }
            // return JObject.Parse(jsonData);
        }
        public string getCustomerOrderDetails(int getID)
        {
            DataSet ds1 = new DataSet();
            ds1.Reset();

            param = new SqlParameter[]
                    {
                        new SqlParameter("@ORDER_ID", getID)
                    };

            ds1 = obj.Return_DataSet("GetBillOFLandingCustOrderINFO", param);

            int getRowCount = ds1.Tables[0].Rows.Count;
            string custOrderDetails = "";
            if (getRowCount > 0)
            {
                custOrderDetails += "[";
                for (int rc = 0; rc <= (getRowCount - 1); rc++)
                {
                    custOrderDetails += "{";

                    string getCustomerOrderNo = ds1.Tables[0].Rows[rc]["ORDER_ID"].ToString();
                    string getCustomerOrderNoRef = ds1.Tables[0].Rows[rc]["OrderRefNo"].ToString();
                    string getPkgs = ds1.Tables[0].Rows[rc]["PKGS"].ToString();
                    string getPCS = ds1.Tables[0].Rows[rc]["PCS"].ToString();
                    string getWeight = ds1.Tables[0].Rows[rc]["WEIGHT"].ToString();
                    string getPallet = ds1.Tables[0].Rows[rc]["PALLET"].ToString();
                    string getSlip = ds1.Tables[0].Rows[rc]["SLIP"].ToString();
                    string getAdditionalShipperInfo = ds1.Tables[0].Rows[rc]["ADDITIONAL_SHIPPER_INFO"].ToString();

                    custOrderDetails += "CustomerOrderNo: '" + getCustomerOrderNo + "', ";
                    custOrderDetails += "CustomerOrderNoRef: '" + getCustomerOrderNoRef + "', ";

                    custOrderDetails += "Pkgs: '" + getPkgs + "', ";
                    custOrderDetails += "PCS: '" + getPCS + "', ";
                    custOrderDetails += "Weight: '" + getWeight + "', ";
                    custOrderDetails += "Pallet: '" + getPallet + "', ";
                    custOrderDetails += "Slip: '" + getSlip + "', ";
                    string filterAdditionalShipperInfo = Regex.Replace(getAdditionalShipperInfo, @"\t|\n|\r", "");
                    custOrderDetails += "AdditionalShipperInfo: '" + filterAdditionalShipperInfo + "' ";

                    if (rc == (getRowCount - 1))
                    {
                        custOrderDetails += "}";
                    }
                    else
                    {
                        custOrderDetails += "},";
                    }

                    // Calculate... 
                    string currentPackage = getPkgs;
                    string currentWeight = getWeight;
                    string currentPCS = getPCS;

                    if (currentPackage.IndexOf(".") <= -1)
                    {
                        currentPackage = currentPackage + ".00";
                    }
                    if (currentWeight == "")
                    {
                        currentWeight = "0.00";
                    }
                    else if (currentWeight.IndexOf(".") <= -1)
                    {
                        currentWeight = currentWeight + ".00";
                    }

                    if (currentPCS == "")
                    {
                        currentPCS = "0.00";
                    }
                    else if (currentPCS.IndexOf(".") <= -1)
                    {
                        currentPCS = currentPCS + ".00";
                    }


                    getCoTotalPkgs = getCoTotalPkgs + double.Parse(currentPackage);
                    getCoTotalWeight = getCoTotalWeight + double.Parse(currentWeight);
                    getCrTotalPCS = getCrTotalPCS + double.Parse(currentPCS);
                }
                custOrderDetails += "]";
            }
            return custOrderDetails;
        }
        public string getCarrierDetails(int OId)
        {
            DataSet ds1 = new DataSet();
            ds1.Reset();

            param = new SqlParameter[]
                    {
                        new SqlParameter("@ORDER_ID", OId)
                    };

            ds1 = obj.Return_DataSet("GetBillOFLandingCarrierINFO", param);

            int getRowCount = ds1.Tables[0].Rows.Count;
            string custOrderDetails = "";
            if (getRowCount > 0)
            {
                custOrderDetails += "[";
                for (int rc = 0; rc <= (getRowCount - 1); rc++)
                {
                    custOrderDetails += "{";

                    string getHandlingUnitQty = ds1.Tables[0].Rows[rc]["HANDLING_QTY"].ToString();
                    string getHandlingUnitType = ds1.Tables[0].Rows[rc]["HANDLING_TYPE"].ToString();
                    string getPackageQty = ds1.Tables[0].Rows[rc]["PAKAGE_QTY"].ToString();
                    string getPackageType = ds1.Tables[0].Rows[rc]["PAKAGE_TYPE"].ToString();
                    string getWeight = ds1.Tables[0].Rows[rc]["WEIGHT"].ToString();
                    string getHM = ds1.Tables[0].Rows[rc]["H_M"].ToString();
                    //string getCommodityDescription = ds1.Tables[0].Rows[rc]["AdditionalShipperInfo"].ToString();
                    string getCommodityDescription = "";
                    string getLtlNmfc = ds1.Tables[0].Rows[rc]["NMFC"].ToString();
                    string getLtlClass = ds1.Tables[0].Rows[rc]["CLASS"].ToString();

                    custOrderDetails += "HandlingUnitQty: '" + getHandlingUnitQty + "', ";
                    custOrderDetails += "HandlingUnitType: '" + getHandlingUnitType + "', ";
                    custOrderDetails += "PackageQty: '" + getPackageQty + "', ";
                    custOrderDetails += "PackageType: '" + getPackageType + "', ";
                    custOrderDetails += "Weight: '" + getWeight + "', ";
                    custOrderDetails += "HM: '" + getHM + "', ";
                    custOrderDetails += "CommodityDescription: '" + getCommodityDescription + "', ";
                    custOrderDetails += "LtlNmfc: '" + getLtlNmfc + "', ";
                    custOrderDetails += "LtlClass: '" + getLtlClass + "' ";

                    if (rc == (getRowCount - 1))
                    {
                        custOrderDetails += "}";
                    }
                    else
                    {
                        custOrderDetails += "},";
                    }
                    string currentHandlingUnitQty = getHandlingUnitQty;
                    string currentPackage = getPackageQty;
                    string currentWeight = getWeight;
                    //string currentPCS = getPCS;

                    if (currentHandlingUnitQty == "")
                    {
                        currentHandlingUnitQty = "0.00";
                    }
                    else if (currentHandlingUnitQty.IndexOf(".") <= -1)
                    {
                        currentHandlingUnitQty = currentHandlingUnitQty + ".00";
                    }


                    if (currentPackage == "")
                    {
                        currentPackage = "0.00";
                    }
                    else if (currentPackage.IndexOf(".") <= -1)
                    {
                        currentPackage = currentPackage + ".00";
                    }

                    if (currentWeight == "")
                    {
                        currentWeight = "0.00";
                    }
                    else if (currentWeight.IndexOf(".") <= -1)
                    {
                        currentWeight = currentWeight + ".00";
                    }
                    getCrTotalHandlingUnitQty = getCrTotalHandlingUnitQty + double.Parse(currentHandlingUnitQty);
                    getCrTotalPackageQty = getCrTotalPackageQty + double.Parse(currentPackage);
                    getCrTotalWeight = getCrTotalWeight + double.Parse(currentWeight);
                }
                custOrderDetails += "]";
            }
            return custOrderDetails;
        }
        private string convertToDoubleString(string dblVal)
        {
            string returnDblVal = "0.00";
            try
            {
                if (dblVal.Trim() == "" || dblVal.Trim() == "0")
                {
                    dblVal = "0.00";
                }
                else if (dblVal.IndexOf(".") <= -1)
                {
                    dblVal = dblVal + ".00";
                }

                bool checkIfNan = double.IsNaN(double.Parse(dblVal));
                if (!checkIfNan)
                {
                    returnDblVal = dblVal;
                }
            }
            catch (Exception ex)
            {

            }

            return returnDblVal;
        }
        public async Task<JsonElement> UpdateData(BillofLanding req)
        {
            param = new SqlParameter[]
                    {
                       new SqlParameter("@CustomerOrderNo", req.CustomerOrderNo),
                        new SqlParameter("@ShipFromName", req.ShipFromName),
                        new SqlParameter("@ShipFromAddress", req.ShipFromAddress),
                        new SqlParameter("@ShipFromCityStateZip", req.ShipFromCityStateZip),
                        new SqlParameter("@ShipFromSid", req.ShipFromSid),
                        new SqlParameter("@FOB", req.FOB),
                        new SqlParameter("@ShipToName", req.ShipToName),
                        new SqlParameter("@ShipToAddress", req.ShipToAddress),
                        new SqlParameter("@ShipToCityStateZip", req.ShipToCityStateZip),
                        new SqlParameter("@ShipToSid", req.ShipToSid),
                        new SqlParameter("@ShipToFob", req.ShipToFob),
                        new SqlParameter("@ThirdPartyName", req.ThirdPartyName),
                        new SqlParameter("@ThirdPartyAddress", req.ThirdPartyAddress),
                        new SqlParameter("@ThirdPartyCityStateZip", req.ThirdPartyCityStateZip),
                        new SqlParameter("@ThirdPartySpecialInstuction", req.ThirdPartySpecialInstuction),
                        new SqlParameter("@BillOfLadingNo", req.BillOfLadingNo),
                       // new SqlParameter("@Carrier", req.Carrier),
                        new SqlParameter("@TrailerNumber", req.TrailerNumber),
                        new SqlParameter("@SealNumbers", req.SealNumbers),
                        new SqlParameter("@SCAC", req.SCAC),
                        new SqlParameter("@ProNumber", req.ProNumber),
                        new SqlParameter("@FreightChargeTerm", req.FreightChargeTerms),
                        new SqlParameter("@Prepaid", req.Prepaid),
                        new SqlParameter("@Collect", req.Collect),
                        new SqlParameter("@ThrdParty", req.ThrdParty),
                        new SqlParameter("@MasterBillofLading", req.MasterBillofLading),
                        new SqlParameter("@CODCollect", req.CODCollect),
                        new SqlParameter("@CODPrepaid", req.CODPrepaid),
                        new SqlParameter("@CODCustAccept", req.CODCustAccept),
                        new SqlParameter("@TrailerByShipper", req.TrailerByShipper),
                        new SqlParameter("@TrailerByDriver", req.TrailerByDriver),
                        new SqlParameter("@FreightByShipper", req.FreightByShipper),
                        new SqlParameter("@FreightByDriver", req.FreightByDriver),
                        new SqlParameter("@FreightByPieces", req.FreightByPieces),
                        new SqlParameter("@CompanyId", req.CompanyID),
                        new SqlParameter("@UserId", req.UserId),
                        new SqlParameter("@WarehouseId", req.WarehouseId),
                        new SqlParameter("@CustomerId", req.CustomerId),
                        new SqlParameter("@TransporterName", req.TransporterName),
                        new SqlParameter("@TransportId", req.TransportId),
                        new SqlParameter("@PackingId", req.PackingId),

                    };
            return await obj.ConvertDataSetToJObject(obj.Return_DataSet("sp_UpdateBOLDetails", param));
        }
        public async Task<JsonElement> MasterBOL(reqMasterBOL req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@orderNo", req.orderNo),
                        new SqlParameter("@EntryType", req.EntryType),
                        new SqlParameter("@customerId", req.customerId),

                    };
            return await obj.ConvertDataSetToJObject(obj.Return_DataSet("GenerateMasterBOL", param));
        }
    }
}
