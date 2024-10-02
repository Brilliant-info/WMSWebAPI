using Newtonsoft.Json.Linq;
using System.Data.SqlClient;
using System.Text.Json;
using WMSWebAPI.Models.V1.Request;

namespace WMSWebAPI.Utility.V1
{
    public class DocumentUtility
    {
        SqlParameter[] param;
        DBActivity obj;
        public DocumentUtility()
        {
            obj = new DBActivity();
        }

        public async Task<JsonElement> GetAll(GetDocumentList req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@CompanyId", Int64.Parse(req.CompanyId)),
                        new SqlParameter("@WarehouseId", Int64.Parse(req.WarehouseId)),
                        new SqlParameter("@UserId", Int64.Parse(req.UserId)),
                        new SqlParameter("@ReferenceID", Int64.Parse(req.ReferenceID)),
                        new SqlParameter("@ObjectName", req.ObjectName)
                    };

            return await obj.ConvertDataSetToJObject(obj.Return_DataSet("Get_DocumentByID", param));
        }

        public string SaveDocument(SavedocumentRequest ReqPara, string DocumentDownloadPath)
        {
            param = new SqlParameter[]
                    {
                    new SqlParameter("@ObjectName",ReqPara.ObjectName),
                    new SqlParameter("@ReferenceID", Int64.Parse(ReqPara.ReferenceID)),
                    new SqlParameter("@DocumentName",ReqPara.DocumentName),
                    new SqlParameter("@Description",ReqPara.Description),
                    new SqlParameter("@DocumentDownloadPath",DocumentDownloadPath),
                    new SqlParameter("@DocumentSavePath",ReqPara.DocumentSavePath),
                    new SqlParameter("@FileType",ReqPara.FileType),
                    new SqlParameter("@UserID", Int64.Parse(ReqPara.UserId)),
                    new SqlParameter("@CompanyID",Int64.Parse(ReqPara.CompanyId)),
                    new SqlParameter("@DocumentType", ReqPara.DocumentType),
                    new SqlParameter("@CustomerID", Int64.Parse(ReqPara.CustomerID))

                    };
            return obj.Return_ScalerValue("IU_Document", param);
        }

        public string RemoveDocument(RemoveDocumentRequest ReqPara)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@CustomerHeadId", Int64.Parse(ReqPara.CustomerHeadId)),
                        new SqlParameter("@UserId", Int64.Parse(ReqPara.UserId)),
                        new SqlParameter("@RefferenceId", Int64.Parse(ReqPara.RefferenceId)),
                        new SqlParameter("@ObjectName", ReqPara.ObjectName),
                    };
            return obj.Return_ScalerValue("Del_DocumentByID", param);
        }
    }

}
