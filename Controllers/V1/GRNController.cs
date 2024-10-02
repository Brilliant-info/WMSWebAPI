using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System.Text.Json;
using WMSWebAPI.Models.V1.Request;
using WMSWebAPI.Models.V1.Responce;
using WMSWebAPI.Route;
using WMSWebAPI.Utility.V1;
//using ZXing;
//using ZXing.QrCode;
//using ZXing;
//using ZXing.Common;
//using ZXing.Datamatrix;
//using System.Drawing;
//using ConnectCode.BarcodeFonts2D;

namespace WMSWebAPI.Controllers.V1
{
    [Route("api/[controller]")]
    [ApiController]
    public class GRNController : ControllerBase
    {

        SysException exe = new SysException();
        GRNActivity obj = new GRNActivity();

        [HttpPost]
        [Route(APIRoute.GRN.GetSKUList)]
        public async Task<ResponceList> GetSKUList(GetGRNSKUListRequest reqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (reqPara != null)
                {
                    JsonElement result = await obj.GetGRNSKUDetail(reqPara);
                    Response = ResponceResult.SuccessResponseList(result);
                }
                else
                {
                    Response = ResponceResult.ErrorResponseList("No record found..!");
                }
            }
            catch (Exception ex)
            {
                Response = ResponceResult.ErrorResponseList(ex.Message.ToString());
                exe.ErrorLog(ex.Message.ToString(), APIRoute.GRN.GetSKUList, 0);
            }
            return Response;
        }


        [HttpPost]
        [Route(APIRoute.GRN.SaveSKUDetails)]
        public Responce SaveSKUDetails(SaveGRNSKUListRequest ReqPara)
        {
            Responce Response = new Responce();
            try
            {
                if (ReqPara != null)
                {
                    string result = obj.SaveGRNSKUDetail(ReqPara);
                    if (result == "success")
                    {
                        Response = ResponceResult.SuccessResponse(result);
                    }
                    else
                    {
                        Response = ResponceResult.ValidateResponse(result);
                    }
                }
                else
                {
                    Response = ResponceResult.ErrorResponse("Record Not Save..!");
                    return Response;
                }
            }
            catch (Exception ex)
            {
                Response = ResponceResult.ErrorResponse(ex.Message.ToString());
                exe.ErrorLog(ex.Message.ToString(), APIRoute.GRN.SaveSKUDetails, 0);
            }
            return Response;
        }

        [HttpPost]
        [Route(APIRoute.GRN.RemoveSKU)]
        public Responce RemoveSKU(RemoveGRNSKURequest ReqPara)
        {
            Responce Response = new Responce();
            try
            {
                if (ReqPara != null)
                {
                    string result = obj.RemoveGRNSKUDetail(ReqPara);
                    if (result == "success")
                    {
                        Response = ResponceResult.SuccessResponse(result);
                    }
                    else
                    {
                        Response = ResponceResult.ValidateResponse(result);
                    }
                }
                else
                {
                    Response = ResponceResult.ErrorResponse("Record Not Save..!");
                    return Response;
                }
            }
            catch (Exception ex)
            {
                Response = ResponceResult.ErrorResponse(ex.Message.ToString());
                exe.ErrorLog(ex.Message.ToString(), APIRoute.GRN.RemoveSKU, 0);
            }
            return Response;
        }
        [HttpPost]
        [Route(APIRoute.GRN.Closegrnpopup)]
        public Responce CloseGRNSKU(CloseGRNSKURequest ReqPara)
        {
            Responce Response = new Responce();
            try
            {
                if (ReqPara != null)
                {
                    string result = obj.CloseGRNSKUDetail(ReqPara);
                    if (result == "Success")
                    {
                        Response = ResponceResult.SuccessResponse(result);
                    }
                    else
                    {
                        Response = ResponceResult.ValidateResponse(result);
                    }
                }
                else
                {
                    Response = ResponceResult.ErrorResponse("Record Not Save..!");
                    return Response;
                }
            }
            catch (Exception ex)
            {
                Response = ResponceResult.ErrorResponse(ex.Message.ToString());
                exe.ErrorLog(ex.Message.ToString(), APIRoute.GRN.RemoveSKU, 0);
            }
            return Response;
        }



        [HttpPost]
        [Route(APIRoute.GRN.GetTransportList)]
        public async Task<ResponceList> GetTransportList(GetGRNTransportListRequest reqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (reqPara != null)
                {
                    JsonElement result = await obj.GetGRNTransportDetail(reqPara);
                    Response = ResponceResult.SuccessResponseList(result);
                }
                else
                {
                    Response = ResponceResult.ErrorResponseList("No record found..!");
                }
            }
            catch (Exception ex)
            {
                Response = ResponceResult.ErrorResponseList(ex.Message.ToString());
                exe.ErrorLog(ex.Message.ToString(), APIRoute.GRN.GetTransportList, 0);
            }
            return Response;
        }

        [HttpPost]
        [Route(APIRoute.GRN.SaveGRNTransport)]
        public Responce SaveGRNTransport(SaveGRNTransportRequest ReqPara)
        {
            Responce Response = new Responce();
            try
            {
                if (ReqPara != null)
                {
                    string result = obj.SaveTransportDetail(ReqPara);
                    if (result == "success")
                    {
                        Response = ResponceResult.SuccessResponse(result);
                    }
                    else
                    {
                        Response = ResponceResult.ValidateResponse(result);
                    }
                }
                else
                {
                    Response = ResponceResult.ErrorResponse("Record Not Save..!");
                    return Response;
                }
            }
            catch (System.Exception ex)
            {
                Response = ResponceResult.ErrorResponse(ex.Message.ToString());
                exe.ErrorLog(ex.Message.ToString(), APIRoute.GRN.SaveGRNTransport, ReqPara.UserId);
            }
            return Response;
        }
        [HttpPost]
        [Route(APIRoute.GRN.SaveGatePass)]
        public Responce SaveGatePass(SaveGRNTransportRequest ReqPara)
        {
            string getPoOrderID = ReqPara.OrderId;
            string result = "";

            string[] getOrderId = getPoOrderID.Split(',');


            Responce Response = new Responce();
            try
            {
                if (ReqPara != null)
                {
                    for (int i = 0; i < getOrderId.Length; i++)
                    {

                        ReqPara.OrderId = Convert.ToString(getOrderId[i]);
                        result = obj.savegetPassdetails(ReqPara);
                    }
                    if (result == "success")
                    {
                        Response = ResponceResult.SuccessResponse(result);
                    }
                    else
                    {
                        Response = ResponceResult.ValidateResponse(result);
                    }
                }
                else
                {
                    Response = ResponceResult.ErrorResponse("Record Not Save..!");
                    return Response;
                }
            }
            catch (System.Exception ex)
            {
                Response = ResponceResult.ErrorResponse(ex.Message.ToString());
                exe.ErrorLog(ex.Message.ToString(), APIRoute.GRN.SaveGRNTransport, ReqPara.UserId);
            }
            return Response;
        }

        /* SAVE GATEPASS LOTTABLE - 13 DEC 2023 */
 

        [HttpPost]
        [Route(APIRoute.GRN.SaveGatePassLottable)]
        public async Task<ResponceList> SaveGatePassLottable(SaveGatePassLottableRequest reqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (reqPara != null)
                {
                    JsonElement result = await obj.SaveGatePassLottable(reqPara);
                    Response = ResponceResult.SuccessResponseList(result);
                }
                else
                {
                    Response = ResponceResult.ErrorResponseList("No record found..!");
                }
            }
            catch (Exception ex)
            {
                Response = ResponceResult.ErrorResponseList(ex.Message.ToString());
                exe.ErrorLog(ex.Message.ToString(), APIRoute.GRN.SaveGatePassLottable, 0);
            }
            return Response;
        }
        /* SAVE GATEPASS LOTTABLE - 13 DEC 2023 */
        /* SAVE GATEPASS LOTTABLE - 15 DEC 2023 */
   


        [HttpPost]
        [Route(APIRoute.GRN.CreateGatePassSkuSerials)]
        public async Task<ResponceList> CreateGatePassSkuSerials(CreateGatePassSkuSerialsRequest reqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (reqPara != null)
                {
                    JsonElement result = await obj.CreateGatePassSkuSerials(reqPara);
                    Response = ResponceResult.SuccessResponseList(result);
                }
                else
                {
                    Response = ResponceResult.ErrorResponseList("No record found..!");
                }
            }
            catch (Exception ex)
            {
                Response = ResponceResult.ErrorResponseList(ex.Message.ToString());
                exe.ErrorLog(ex.Message.ToString(), APIRoute.GRN.CreateGatePassSkuSerials, 0);
            }
            return Response;
        }
        /* SAVE GATEPASS LOTTABLE - 15 DEC 2023 */


        [HttpPost]
        [Route(APIRoute.GRN.GetGRNHead)]
        public async Task<ResponceList> GetGRNHead(GRNHeadRequest reqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (reqPara != null)
                {
                    JsonElement result = await obj.GRNHead(reqPara);
                    Response = ResponceResult.SuccessResponseList(result);
                }
                else
                {
                    Response = ResponceResult.ErrorResponseList("No record found..!");
                }
            }
            catch (Exception ex)
            {
                Response = ResponceResult.ErrorResponseList(ex.Message.ToString());
                exe.ErrorLog(ex.Message.ToString(), APIRoute.GRN.GetGRNHead, 0);
            }
            return Response;
        }

  


        [HttpPost]

        [Route(APIRoute.GRN.SaveGRNSKUDetail)]
        public Responce SaveGRNDetail(SaveGRNDetailRequest ReqPara)
        {
            Responce Response = new Responce();
            try
            {
                if (ReqPara != null)
                {
                    string result = obj.SaveGRNSKUDetail(ReqPara);
                    if (result != "0" && result != "Lotfaild")
                    {
                        Response = ResponceResult.SuccessResponse(result);
                    }
                    else
                    {
                        Response = ResponceResult.ValidateResponse(result);
                    }
                }
                else
                {
                    Response = ResponceResult.ErrorResponse("Record Not Save..!");
                    return Response;
                }
            }
            catch (System.Exception ex)
            {
                Response = ResponceResult.ErrorResponse(ex.Message.ToString());
                exe.ErrorLog(ex.Message.ToString(), APIRoute.GRN.SaveGRNSKUDetail, 0);
            }
            return Response;
        }
        [HttpPost]

        [Route(APIRoute.GRN.UpdateGrnStatus)]
        public Responce UpdateGrn(UpdatGrnStatus ReqPara)
        {

            Responce Response = new Responce();
            try
            {
                if (ReqPara != null)
                {
                    string result = obj.Updategrn(ReqPara);
                    if (result != "fail")
                    {
                        Response = ResponceResult.SuccessResponse(result);
                    }
                    else
                    {
                        Response = ResponceResult.ValidateResponse(result);
                    }
                }
                else
                {
                    Response = ResponceResult.ErrorResponse("Record Not Save..!");
                    return Response;
                }
            }
            catch (System.Exception ex)
            {
                Response = ResponceResult.ErrorResponse(ex.Message.ToString());
                exe.ErrorLog(ex.Message.ToString(), APIRoute.GRN.UpdateGrnStatus, 0);
            }
            return Response;
        }

 

        [HttpPost]
        [Route(APIRoute.GRN.GetGRNDetail)]
        public async Task<ResponceList> GetGRNDetail(GRNDetailRequest reqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (reqPara != null)
                {
                    JsonElement result = await obj.GRNDetails(reqPara);
                    Response = ResponceResult.SuccessResponseList(result);
                }
                else
                {
                    Response = ResponceResult.ErrorResponseList("No record found..!");
                }
            }
            catch (Exception ex)
            {
                Response = ResponceResult.ErrorResponseList(ex.Message.ToString());
                exe.ErrorLog(ex.Message.ToString(), APIRoute.GRN.GetGRNDetail, 0);
            }
            return Response;
        }



        [HttpPost]
        [Route(APIRoute.GRN.getGRNID)]
        public async Task<ResponceList> GetGRNDetail(poidreq reqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (reqPara != null)
                {
                    JsonElement result = await obj.getGrnID(reqPara);
                    Response = ResponceResult.SuccessResponseList(result);
                }
                else
                {
                    Response = ResponceResult.ErrorResponseList("No record found..!");
                }
            }
            catch (Exception ex)
            {
                Response = ResponceResult.ErrorResponseList(ex.Message.ToString());
                exe.ErrorLog(ex.Message.ToString(), APIRoute.GRN.getGRNID, 0);
            }
            return Response;
        }


      

        [HttpPost]
        [Route(APIRoute.GRN.getPass)]
        public async Task<ResponceList> getPass(poidreq reqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (reqPara != null)
                {
                    JsonElement result = await obj.getPass(reqPara);
                    Response = ResponceResult.SuccessResponseList(result);
                }
                else
                {
                    Response = ResponceResult.ErrorResponseList("No record found..!");
                }
            }
            catch (Exception ex)
            {
                Response = ResponceResult.ErrorResponseList(ex.Message.ToString());
                exe.ErrorLog(ex.Message.ToString(), APIRoute.GRN.getPass, 0);
            }
            return Response;
        }




        //[HttpPost]
        //[Route(APIRoute.GRN.GetGRNTransportDetail)]
        //public async Task<ResponceList> GetGRNTransportDetail(GetGRNTransportDetailtRequest reqPara)
        //{
        //    ResponceList Response = new ResponceList();
        //    try
        //    {
        //        if (reqPara != null)
        //        {
        //            JsonElement result = await obj.GetGRNTransport(reqPara);
        //            Response = ResponceResult.SuccessResponseList(result);
        //        }
        //        else
        //        {
        //            Response = ResponceResult.ErrorResponseList("No record found..!");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Response = ResponceResult.ErrorResponseList(ex.Message.ToString());
        //        exe.ErrorLog(ex.Message.ToString(), APIRoute.GRN.GetGRNTransportDetail, 0);
        //    }

        //}





        [HttpPost]
        [Route(APIRoute.GRN.viewGetPass)]
        public async Task<ResponceList> viewGetPass(viewGetPass reqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (reqPara != null)
                {
                    JsonElement result = await obj.sp_getVendorListRecord(reqPara);
                    Response = ResponceResult.SuccessResponseList(result);
                }
                else
                {
                    Response = ResponceResult.ErrorResponseList("No record found..!");
                }
            }
            catch (Exception ex)
            {
                Response = ResponceResult.ErrorResponseList(ex.Message.ToString());
                exe.ErrorLog(ex.Message.ToString(), APIRoute.GRN.viewGetPass, 0);
            }
            return Response;
        }

    


        [HttpPost]
        [Route(APIRoute.GRN.getPassIdListByID)]
        public async Task<ResponceList> getPassIdListByID(getPassListById reqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (reqPara != null)
                {
                    JsonElement result = await obj.getPassIDList(reqPara);
                    Response = ResponceResult.SuccessResponseList(result);
                }
                else
                {
                    Response = ResponceResult.ErrorResponseList("No record found..!");
                }
            }
            catch (Exception ex)
            {
                Response = ResponceResult.ErrorResponseList(ex.Message.ToString());
                exe.ErrorLog(ex.Message.ToString(), APIRoute.GRN.getPassIdListByID, 0);
            }
            return Response;
        }

        /* GET BARCODE TO PRINT AS PER PATTERN - 04 DEC 2023 */
   

        [HttpPost]
        [Route(APIRoute.GRN.getBarcodeAsPerConfig)]
        public async Task<ResponceList> getBarcodeAsPerConfig(getBarcodeAsPerConfig reqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (reqPara != null)
                {
                    JsonElement result = await obj.getBarcodeAsPerConfig(reqPara);
                    Response = ResponceResult.SuccessResponseList(result);
                }
                else
                {
                    Response = ResponceResult.ErrorResponseList("No record found..!");
                }
            }
            catch (Exception ex)
            {
                Response = ResponceResult.ErrorResponseList(ex.Message.ToString());
                exe.ErrorLog(ex.Message.ToString(), APIRoute.GRN.getBarcodeAsPerConfig, 0);
            }
            return Response;
        }


        //[HttpPost]
        //[Route(APIRoute.GRN.getBarcodePrintData)]
        //public async Task<ResponceList> getBarcodePrintData(getBarcodePrintData reqPara)
        //{
        //    ResponceList response = new ResponceList();
        //    try
        //    {
        //        if (reqPara != null)
        //        {
        //            JsonElement result = await obj.getBarcodePrintData(reqPara);
        //            var jResult = result.GetProperty("Table").EnumerateArray().ToList();

        //            for (int i = 0; i < jResult.Count; i++)
        //            {
        //                var jSkuItem = jResult[i];
        //                var getBarcodeText = jSkuItem.GetProperty("BarcodeString").GetString();

        //                var barcode = new DataMatrix();
        //                barcode.Data = getBarcodeText;
        //                string outputstr = barcode.Encode(DataMatrix.FORMAT_SVG); // Generate SVG format

        //                // Create a JsonDocument with the new QRCode property
        //                using (var doc = JsonDocument.Parse($"{{ \"QRCode\": \"{outputstr}\" }}"))
        //                {
        //                    jResult[i] = MergeJsonElements(jSkuItem, doc.RootElement);
        //                }
        //            }

        //            var updatedResult = result.GetProperty("Table").Clone();
        //            response = ResponceResult.SuccessResponseList(updatedResult);
        //            return response;
        //        }
        //        else
        //        {
        //            response = ResponceResult.ErrorResponseList("No record found..!");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        response = ResponceResult.ErrorResponseList(ex.Message);
        //        exe.ErrorLog(ex.Message, APIRoute.GRN.getBarcodePrintData, 0);
        //    }
        //    return response;
        //}

        private JsonElement MergeJsonElements(JsonElement original, JsonElement toMerge)
        {
            var originalJson = original.GetRawText();
            var toMergeJson = toMerge.GetRawText();
            using (var doc = JsonDocument.Parse(originalJson))
            using (var mergeDoc = JsonDocument.Parse(toMergeJson))
            {
                var jsonObj = JsonSerializer.Deserialize<Dictionary<string, JsonElement>>(doc.RootElement.GetRawText());
                var mergeObj = JsonSerializer.Deserialize<Dictionary<string, JsonElement>>(mergeDoc.RootElement.GetRawText());

                foreach (var kv in mergeObj)
                {
                    jsonObj[kv.Key] = kv.Value;
                }

                var mergedJson = JsonSerializer.Serialize(jsonObj);
                using (var finalDoc = JsonDocument.Parse(mergedJson))
                {
                    return finalDoc.RootElement.Clone();
                }
            }
        }

        //[HttpPost]
        //[Route(APIRoute.GRN.ShowGeneratedSerialList)]
        //public async Task<ResponceList> getShowGeneratedSerialList(ShowGeneratedSerialList reqPara)
        //{
        //    ResponceList response = new ResponceList();
        //    try
        //    {
        //        if (reqPara != null)
        //        {
        //            JsonElement result = await obj.ShowGeneratedSerialList(reqPara);
        //            var jResult = result.GetProperty("Table").EnumerateArray().ToList();

        //            for (int i = 0; i < jResult.Count; i++)
        //            {
        //                var jSkuItem = jResult[i];
        //                var getBarcodeText = jSkuItem.GetProperty("BarcodeString").GetString();

        //                var barcode = new DataMatrix();
        //                barcode.Data = getBarcodeText;
        //                string outputstr = barcode.Encode(DataMatrix.FORMAT_SVG); // Generate SVG format

        //                // Create a JsonDocument with the new QRCode property
        //                using (var doc = JsonDocument.Parse($"{{ \"QRCode\": \"{outputstr}\" }}"))
        //                {
        //                    jResult[i] = MergeJsonElements(jSkuItem, doc.RootElement);
        //                }
        //            }

        //            var updatedResult = result.GetProperty("Table").Clone();
        //            response = ResponceResult.SuccessResponseList(updatedResult);
        //            return response;
        //        }
        //        else
        //        {
        //            response = ResponceResult.ErrorResponseList("No record found..!");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        response = ResponceResult.ErrorResponseList(ex.Message);
        //        exe.ErrorLog(ex.Message, APIRoute.GRN.ShowGeneratedSerialList, 0);
        //    }
        //    return response;
        //}
        /* GET BARCODE TO PRINT AS PER PATTERN - 19 DEC 2023 */

        /* BARCODE SELECTED PRINT LABEL - 03 JUNE 2024 */


        [HttpPost]
        [Route(APIRoute.GRN.GetGrnPrintLabelStyle)]
        public async Task<ResponceList> GetGrnPrintLabelStyle(GetGrnPrintLabelStyle reqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (reqPara != null)
                {
                    JsonElement result = await obj.GetGrnPrintLabelStyle(reqPara);
                    Response = ResponceResult.SuccessResponseList(result);
                }
                else
                {
                    Response = ResponceResult.ErrorResponseList("No record found..!");
                }
            }
            catch (Exception ex)
            {
                Response = ResponceResult.ErrorResponseList(ex.Message.ToString());
                exe.ErrorLog(ex.Message.ToString(), APIRoute.GRN.GetGrnPrintLabelStyle, 0);
            }
            return Response;
        }


    


        [HttpPost]
        [Route(APIRoute.GRN.SaveGrnPrintLabelStyle)]
        public async Task<ResponceList> SaveGrnPrintLabelStyle(SaveGrnPrintLabelStyle reqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (reqPara != null)
                {
                    JsonElement result = await obj.SaveGrnPrintLabelStyle(reqPara);
                    Response = ResponceResult.SuccessResponseList(result);
                }
                else
                {
                    Response = ResponceResult.ErrorResponseList("No record found..!");
                }
            }
            catch (Exception ex)
            {
                Response = ResponceResult.ErrorResponseList(ex.Message.ToString());
                exe.ErrorLog(ex.Message.ToString(), APIRoute.GRN.SaveGrnPrintLabelStyle, 0);
            }
            return Response;
        }
        /* BARCODE SELECTED PRINT LABEL - 03 JUNE 2024 */
    }
}
