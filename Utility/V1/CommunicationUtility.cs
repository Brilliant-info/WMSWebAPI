using Newtonsoft.Json.Linq;
using System.Data.SqlClient;
using System.Text.Json;
using WMSWebAPI.Models.V1.Request;

namespace WMSWebAPI.Utility.V1
{
    public class CommunicationUtility
    {
        SqlParameter[] param;
        DBActivity obj;
        public CommunicationUtility()
        {
            obj = new DBActivity();
        }
        public async Task<JsonElement> GetCommList(GetCommunicationRequest req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@OrderId", Int64.Parse(req.OrderId)),
                        new SqlParameter("@UserId", Int64.Parse(req.UserId)),
                        new SqlParameter("@ObjectName", req.ObjectName)
                    };
            return await obj.ConvertDataSetToJObject(obj.Return_DataSet("Get_CommList", param));
        }
        public string SaveComm(SaveCommunicationRequest req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@Message", req.Message),
                        new SqlParameter("@UserId", Int64.Parse(req.UserId)),
                        new SqlParameter("@ObjectName", req.ObjectName),
                        new SqlParameter("@OrderId", Int64.Parse(req.OrderId)),
                        new SqlParameter("@FilePath1", req.FilePath1),
                        new SqlParameter("@FilePath2", req.FilePath2),
                        new SqlParameter("@tableName", req.tableName)
                    };
            return obj.Return_ScalerValue("IU_Correspond", param);
        }
        public string Removecomm(RemoveCommunicationRequest ReqPara)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@CommId", Int64.Parse(ReqPara.CommId)),
                        new SqlParameter("@UserId", Int64.Parse(ReqPara.UserId)),
                        new SqlParameter("@FilePath1", ReqPara.FilePath1),
                    };
            return obj.Return_ScalerValue("Del_Correspond", param);
        }
    }
}
