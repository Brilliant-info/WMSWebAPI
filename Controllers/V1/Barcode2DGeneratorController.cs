using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using WMSWebAPI.Models.V1.Request;
using WMSWebAPI.Models.V1.Responce;
using WMSWebAPI.Route;
using WMSWebAPI.Utility.V1;


namespace WMSWebAPI.Controllers.V1
{
    [Route("api/[controller]")]
    [ApiController]
    public class Barcode2DGeneratorController : ControllerBase
    {
        Barcode2DGeneratorUtility obj = new Barcode2DGeneratorUtility();
        SysException exe = new SysException();
        [HttpPost]
        [Route(APIRoute.Barcode2DGenerator.Get2DBarcode)]
        public async Task<ResponceList> Barcode2DGenerator(Barcode2DGeneratorRequest ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    int QRType = 0;
                    int PrefixType = 0;
                    // QR Type
                    // 0 - For Square
                    // 1 - For Rectangle

                    // 0 - Prefix Type
                    // 1 - None
                    // 2 - GS1 FNC1
                    // 3 - 05 Macro
                    // 4 - 06 Macro
                    // 5 - Reader Programming 

                    //DataMatrix dm = new DataMatrix(ReqPara.BarcodeText, QRType, PrefixType);
                    string outputstr = "";
                   // outputstr = dm.Encode();
                    JObject result = new JObject();
                    result.Add("QRCode", outputstr);
                    //JObject result = obj.Barcode2DGenerator(ReqPara);

                   // Response = ResponceResult.SuccessResponseList(result);
                }
                else
                {
                    Response = ResponceResult.ErrorResponseList("No record found..!");
                }
            }
            catch (Exception ex)
            {
                Response = ResponceResult.ErrorResponseList(ex.Message.ToString());
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Barcode2DGenerator.Get2DBarcode, Int64.Parse(ReqPara.CustomerID));
            }
            return Response;
        }
    }
}
