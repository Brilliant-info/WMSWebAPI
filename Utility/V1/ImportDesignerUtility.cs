using Newtonsoft.Json.Linq;
using System.Data.SqlClient;
using System.Text.Json;
using WMSWebAPI.Models.V1.Request;

namespace WMSWebAPI.Utility.V1
{
    public class ImportDesignerUtility
    {

        SqlParameter[] param;
        DBActivity obj;
        public ImportDesignerUtility()
        {
            obj = new DBActivity();
        }
        public async Task<JsonElement> ImportDesignerList(ImportDesignerListRequest req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@CompanyID", Int64.Parse(req.CompanyID)),
                        new SqlParameter("@UserID", Int64.Parse(req.UserID)),
                        new SqlParameter("@CustomerID", Int64.Parse(req.CustomerID)),
                    };
            return await obj.ConvertDataSetToJObject(obj.Return_DataSet("sp_ImportDesignerlist", param));
        }
        public async Task<JsonElement> ImportDesignerObjectList(ImportDesignerObjectListRequest req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@UserID", Int64.Parse(req.UserID)),
                       // new SqlParameter("@ViewName", req.ViewName)
                    };
            return await obj.ConvertDataSetToJObject(obj.Return_DataSet("sp_ObjectDropdown", param));
        }
        public async Task<JsonElement> ImpDesignTableColoumlist(ImpDesignTableColoumRequest req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@UserID", Int64.Parse(req.UserID)),
                        new SqlParameter("@ImportID", Int64.Parse(req.ImportID)),
                        new SqlParameter("@TableNM", req.TableNM),
                    };
            return await obj.ConvertDataSetToJObject(obj.Return_DataSet("SP_TableColoumnList", param));

        }
        public async Task<JsonElement> ImpDesignTblColoumDataType(ImpDesignTblColoumDataTypeRequest req)
        {
            param = new SqlParameter[]
                    {

                        new SqlParameter("@ObjectID", Int64.Parse(req.ObjectID)),
                        new SqlParameter("@CompanyID", Int64.Parse(req.CompanyID)),
                        new SqlParameter("@CustomerID", Int64.Parse(req.CustomerID)),
                        new SqlParameter("@UserID", Int64.Parse(req.UserID))

                    };
            return await obj.ConvertDataSetToJObject(obj.Return_DataSet("sp_GetImportTemplateDatatype", param));
        }
        public string ImportDesignerSave(ImportDesignerSaveRequest req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@ColumnData", req.ColumnData),
                        new SqlParameter("@UserID", Int64.Parse(req.UserID)),
                        new SqlParameter("@CustomerID", Int64.Parse(req.CustomerID)),
                        new SqlParameter("@CompanyID", Int64.Parse(req.CompanyID)),
                        new SqlParameter("@ImpID", Int64.Parse(req.ImpID)),
                      //  new SqlParameter("@ObjectName", req.ObjectName),
                        new SqlParameter("@ViewName", req.ViewName),

                    };
            return obj.Return_ScalerValue("Sp_ImportdesignerSave", param);
        }
        public async Task<JsonElement> ImportDesignerViewList(ImportDesignerViewListRequest req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@CompanyID", Int64.Parse(req.CompanyID)),
                        new SqlParameter("@UserID", Int64.Parse(req.UserID)),
                        new SqlParameter("@CustomerID", Int64.Parse(req.CustomerID)),
                    };
            return await obj.ConvertDataSetToJObject(obj.Return_DataSet("sp_ImportDesignerViewlist", param));
        }

        public async Task<JsonElement> CustomImportDetailSavedata(CustomImportDetailSavedataRequest req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@CustomerID", Int64.Parse(req.CustomerID)),
                        new SqlParameter("@Object", req.Object),
                        new SqlParameter("@UserID", Int64.Parse(req.UserID)),
                    };
            return await  obj.ConvertDataSetToJObject(obj.Return_DataSet("sp_GetImportSavedData", param));
        }
    }
}
