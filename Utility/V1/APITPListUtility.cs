using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Data.SqlClient;
using System.Data;
using System.Security.Cryptography;
using System.Text;
using WMSWebAPI.Models.V1.Request;
using System.Text.Json;

namespace WMSWebAPI.Utility.V1
{
    public class APITPListUtility
    {
        SqlParameter[] param;
        DBActivity obj;

        public APITPListUtility()
        {
            obj = new DBActivity();
        }

        public async Task<JsonElement> GetAPITPList(APITPList req)
        {
            param = new SqlParameter[]
            {
                new SqlParameter("@CustomerId", Int64.Parse(req.CustomerId)),
                new SqlParameter("@CompnayId", Int64.Parse(req.CompnayId)),
                new SqlParameter("@UserId", Int64.Parse(req.UserId)),
            };
            return await obj.ConvertDataSetToJObject(obj.Return_DataSet("SP_TPAPIList", param));

        }

        public string APITPSave(RequestAPITPSave req)
        {
            param = new SqlParameter[]
            {
                new SqlParameter("@Id", Int64.Parse(req.Id)),
                new SqlParameter("@API", req.API),
                new SqlParameter("@Method", req.Method),
                new SqlParameter("@APIKeys", req.APIKeys),
                new SqlParameter("@CompanyId", Int64.Parse(req.CompnayId)),
                new SqlParameter("@CustomerId", Int64.Parse(req.CustomerId)),
                new SqlParameter("@WarehouseId", Int64.Parse(req.WarehouseId)),
                new SqlParameter("@IsActive",Int64.Parse( req.IsActive)),
                new SqlParameter("@Remarks", req.Remarks),
                new SqlParameter("@UserId", Int64.Parse(req.UserId))
            };
            return obj.Return_ScalerValue("TP_APIListsave", param);

        }
        public async Task<JsonElement> APITPActiveList(RequestAPITPActiveList req)
        {
            param = new SqlParameter[]
            {
                new SqlParameter("@CustomerId", Int64.Parse(req.CustomerId)),
                new SqlParameter("@CompnayId", Int64.Parse(req.CompnayId)),
                new SqlParameter("@UserId", Int64.Parse(req.UserId)),
            };
            return await obj.ConvertDataSetToJObject(obj.Return_DataSet("SP_TPAPIACTIVEList", param));

        }

        public async Task<JsonElement> APITPLogList(RequestAPITPLogList req)
        {
            param = new SqlParameter[]
            {
                new SqlParameter("@CustomerId",Int64.Parse(req.CustomerId) ),
                new SqlParameter("@WarehouseId", Int64.Parse(req.WarehouseId)),
                new SqlParameter("@CompanyID", Int64.Parse(req.CompanyID)),
                new SqlParameter("@SearchFilter", req.SearchFilter),
                new SqlParameter("@SearchValue",req.SearchValue),
                new SqlParameter("@fromDate", req.fromDate),
                new SqlParameter("@toDate",req.toDate),
                new SqlParameter("@OrderType",req.OrderType)
            };
            return await obj.ConvertDataSetToJObject(obj.Return_DataSet("SP_TPAPILogList", param));

        }
        public async Task<JsonElement> APITPReqReadJSON(RequestAPIJSON req)
        {


            var jsonText = File.ReadAllText(req.fileLogPath);
            var JSONString = string.Empty;
            JSONString = JsonConvert.SerializeObject(jsonText);
            JSONString = JSONString.Replace("//\\", "");

            // JObject respjson = JObject.Parse(jsonText);
            JsonDocument doc = JsonDocument.Parse(JSONString);
            JsonElement respjson = doc.RootElement;
            //JsonElement respjson = JObject.Parse(jsonText);
            //var sponsors = JsonConvert.DeserializeObject<IList<SponsorInfo>>(jsonText);
            //JObject respjson = Co;
            return respjson;

        }
        public async Task<JsonElement> APITPRespReadJSON(ResponseAPIJSON req)
        {


            var jsonText = File.ReadAllText(req.fileLogPath);
            var JSONString = string.Empty;
            JSONString = JsonConvert.SerializeObject(jsonText);
            JSONString = JSONString.Replace("//\\", "");
            //JObject respjson = JObject.Parse(jsonText);
            JsonDocument doc = JsonDocument.Parse(JSONString);
            JsonElement respjson = doc.RootElement;
            //var sponsors = JsonConvert.DeserializeObject<IList<SponsorInfo>>(jsonText);
            //JObject respjson = Co;
            return respjson;

        }
        public async Task<JsonElement> APITPKEY(RequestAPITPKEY req)
        {
            param = new SqlParameter[]
            {
                new SqlParameter("@CustomerId", Int64.Parse(req.CustomerId)),
                new SqlParameter("@CompnayId", Int64.Parse(req.CompnayId)),
                new SqlParameter("@WarehouseId", Int64.Parse(req.WarehouseId)),
                new SqlParameter("@UserId", Int64.Parse(req.UserId)),
                new SqlParameter("@getkeyid", Int64.Parse(req.getkeyid)),
            };

            DataSet ds = new DataSet();
            ds = obj.Return_DataSet("SP_TPAPIKEY", param);
            string SecurityKeys = "";
            string Security_Code = "";
            string Pass_code = "";
            string Warehouse_code = "";

            if (ds.Tables[0].Rows.Count > 0)
            {
                SecurityKeys = ds.Tables[0].Rows[0]["SecurityKeys"].ToString();
                Security_Code = encryptstring(ds.Tables[0].Rows[0]["Security_Code"].ToString());
                Pass_code = encryptstring(ds.Tables[0].Rows[0]["Pass_code"].ToString());
                Warehouse_code = encryptstring(ds.Tables[0].Rows[0]["Warehouse_code"].ToString());

            }
            String jsonString = String.Empty;
            jsonString = "{\"Table\":[{";
            jsonString = jsonString + "\"SecurityKeys\":\"" + SecurityKeys + "\",";
            jsonString = jsonString + "\"Security_Code\":\"" + Security_Code + "\",";
            jsonString = jsonString + "\"Pass_code\":\"" + Pass_code + "\",";
            jsonString = jsonString + "\"Warehouse_code\":\"" + Warehouse_code + "\"";

            jsonString = jsonString + "}]}";


            //return JObject.Parse(jsonString);
            string JSONString = string.Empty;
            JsonDocument doc = JsonDocument.Parse(JSONString);
            JsonElement respjson = doc.RootElement;
            return respjson;

        }
        public string encryptstring(string encryptString)
        {
            string EncryptionKey = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            byte[] clearBytes = Encoding.Unicode.GetBytes(encryptString);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] {
            0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76
        });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }
                    encryptString = Convert.ToBase64String(ms.ToArray());
                }
            }
            return encryptString;
        }

        public async Task<JsonElement> getAPITPParameterlist(APITPParameterlist req)
        {
            param = new SqlParameter[]
            {
                new SqlParameter("@CompanyID", Int64.Parse(req.CompanyID)),
                new SqlParameter("@CustomerID", Int64.Parse(req.CustomerID)),
                new SqlParameter("@UserId", Int64.Parse(req.UserID)),
                new SqlParameter("@ObjectID", Int64.Parse(req.ObjectID)),
            };
            return await obj.ConvertDataSetToJObject(obj.Return_DataSet("SP_GETWMSAPITPParameter", param));

        }
    }
}
