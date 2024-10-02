


using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Web;


namespace WMSWebAPI.Models.V1.Responce
{
    public class ResponceResult
    {
        public static ResponceList SuccessResponseList(JsonElement Message)
        {
            var Response = new ResponceList();
            Response.Status = "200";
            Response.StatusCode = "Success";
            Response.Result = Message;
            return Response;
        }
        public static ResponceList ErrorResponseList(string Message)
        {
            using (JsonDocument doc = JsonDocument.Parse(Message))
            {
                var Response = new ResponceList();
                Response.Status = "400";
                Response.StatusCode = "failed";
                //  Response.Result = JObject.Parse(stringtoJSON(Message));
                Response.Result = doc.RootElement;
                return Response;
            }

            //Response.Result = JObject.Parse(stringtoJSON(Message));
            // JsonDocument doc = JsonDocument.Parse(JSONString);
            //JsonElement respjson = doc.RootElement;


        }


        public static Responce SuccessResponse(string Message)
        {
            var Response = new Responce();
            Response.Status = "200";
            Response.StatusCode = "Success";
            Response.Result = JObject.Parse(stringtoJSON(Message));
            return Response;
        }
        public static Responce ValidateResponse(string Message)
        {
            var Response = new Responce();
            Response.Status = "300";
            Response.StatusCode = "Validate";
            Response.Result = JObject.Parse(stringtoJSON(Message));
            return Response;
        }
        public static Responce ErrorResponse(string Message)
        {
            var Response = new Responce();
            Response.Status = "400";
            Response.StatusCode = "failed";
            Response.Result = JObject.Parse(stringtoJSON(Message));
            return Response;
        }


        public static Responce SuccessResponseOrder(string Message, string orderno)
        {
            var Response = new Responce();
            Response.Status = "200";
            Response.StatusCode = "Success";
            Response.Result = JObject.Parse(stringtoJSONOrder(Message, orderno));
            return Response;
        }


        public static string stringtoJSONOrder(string Message, string orderno)
        {
            string result = "{\"Message\":\"" + Message + "\",\"OrderNo\":\"" + orderno + "\"}";
            return result;
        }




        //public static ResponceResult SuccessResponseList(JObject Message)
        //{
        //    var Response = new ResponceList();
        //    Response.Status = "200";
        //    Response.StatusCode = "Success";
        //    Response.Result = Message;
        //    return Response;
        //}
        //public static ResponceResult ErrorResponseList(string Message)
        //{
        //    var Response = new ResponceList();
        //    Response.Status = "400";
        //    Response.StatusCode = "failed";
        //    Response.Result = JObject.Parse(stringtoJSON(Message));
        //    return Response;
        //}
        public static string stringtoJSON(string Message)
        {
            string result = "{\"Message\":\"" + Message + "\"}";
            return result;
        }
        public static BarcodeScan BarcodeScanSuccess(string type, string id, string code)
        {
            var responce = new BarcodeScan();
            List<validation_result> vallst = new List<validation_result>();
            validation_result val = new validation_result();
            responce.scanType = type;
            responce.id = id;
            responce.code = code;

            val.status = "success";
            val.result = "";
            vallst.Add(val);
            responce.validation_result = vallst;
            return responce;
        }
        public static BarcodeScan BarcodeScanPacking(string type, string id, string code, string param)
        {
            var responce = new BarcodeScan();
            List<validation_result> vallst = new List<validation_result>();
            validation_result val = new validation_result();
            responce.scanType = type;
            responce.id = id;
            responce.code = code;
            val.status = "success";
            val.result = param;
            vallst.Add(val);
            responce.validation_result = vallst;
            return responce;
        }
        public static BarcodeScan BarcodeScanFailed(string type, string id, string code, string result)
        {
            var responce = new BarcodeScan();
            List<validation_result> vallst = new List<validation_result>();
            validation_result val = new validation_result();
            responce.scanType = type;
            responce.id = id;
            responce.code = code;
            val.status = "failed";
            val.result = result;
            vallst.Add(val);
            responce.validation_result = vallst;
            return responce;
        }
    }

}

