using Newtonsoft.Json.Linq;
using System.Data.SqlClient;
using System.Text.Json;
using WMSWebAPI.Models.V1.Request;

namespace WMSWebAPI.Utility.V1
{
    public class EmailSmsUtility
    {

        SqlParameter[] param;
        DBActivity obj;

        public EmailSmsUtility()
        {
            obj = new DBActivity();
        }

        public async Task<JsonElement> getEmailSmSList(getEmailSmsList req)

        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@UserId", req.UserId),
                        new SqlParameter("@CustomerID", req.CustomerID),
                        new SqlParameter("@WarehouseID", req.WarehouseID),

                    };
            return await obj.ConvertDataSetToJObject(obj.Return_DataSet("eml_GetEmilSMSTemplate", param));

        }
        public async Task<JsonElement> getEmailSmSActive(getEmailSmSActive req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@TemplateID",Int64.Parse(req.TemplateID)),
                        new SqlParameter("@UserID", Int64.Parse(req.UserID)),
                        new SqlParameter("@CustomerID",Int64.Parse( req.CustomerID)),
                        new SqlParameter("@CompanyID",Int64.Parse( req.CompanyID)),
                        new SqlParameter("@WarehouseID", Int64.Parse(req.WarehouseID)),
                        new SqlParameter("@Email",Int32.Parse( req.Email)),
                        new SqlParameter("@SMS",Int32.Parse( req.SMS)),
                        new SqlParameter("@whatsup",Int32.Parse( req.whatsup)),

                    };
            return await obj.ConvertDataSetToJObject(obj.Return_DataSet("eml_AssignEmailSMSToCust", param));

        }
        public async Task<JsonElement> getEmailSMSTemplate(getEmailSMSTemplate req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@EmailTemplateID",Int32.Parse(req.EmailTemplateID)),
                        new SqlParameter("@WarehouseID", Int32.Parse(req.WarehouseID)),
                        new SqlParameter("@CompanyID",Int32.Parse(req.CompanyID)),
                        new SqlParameter("@UserID",Int32.Parse(req.UserID)),
                        new SqlParameter("@CustomerID",Int32.Parse(req.CustomerID)),
                        new SqlParameter("@Application",req.Application),
                    };
            return await obj.ConvertDataSetToJObject(obj.Return_DataSet("sp_EmailSMSTemplate", param));
        }

        public string GetSaveEmailSMS(GetSaveEmailSMS req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@EmailTemplateID", Int64.Parse(req.EmailTemplateID)),
                        new SqlParameter("@WarehouseID", Int64.Parse(req.WarehouseID)),
                        new SqlParameter("@CompanyID", Int64.Parse(req.CompanyID)),
                        new SqlParameter("@UserID", Int64.Parse(req.UserID)),
                        new SqlParameter("@CustomerID", Int64.Parse(req.CustomerID)),
                        new SqlParameter("@Application", req.Application),
                        new SqlParameter("@AddEmail", req.AddEmail),
                    };
            return obj.Return_ScalerValue("sp_GetEmailSMSSave", param);
        }

        public string GetroleSaveEmailSMS(GetroleSaveEmailSMS req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@EmailTemplateID", Int64.Parse(req.EmailTemplateID)),
                        new SqlParameter("@WarehouseID", Int64.Parse(req.WarehouseID)),
                        new SqlParameter("@CompanyID", Int64.Parse(req.CompanyID)),
                        new SqlParameter("@UserID", Int64.Parse(req.UserID)),
                        new SqlParameter("@CustomerID", Int64.Parse(req.CustomerID)),
                        new SqlParameter("@Application", req.Application),
                        new SqlParameter("@AddRole", req.AddRole),
                    };
            return obj.Return_ScalerValue("sp_GetRoleEmailSMSWHSave", param);
        }
    
        public string GetRemoveEmailSMS(GetRemoveEmailSMS req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@EmailTemplateID", Int64.Parse(req.EmailTemplateID)),
                        new SqlParameter("@WarehouseID", Int64.Parse(req.WarehouseID)),
                        new SqlParameter("@CompanyID", Int64.Parse(req.CompanyID)),
                        new SqlParameter("@UserID", Int64.Parse(req.UserID)),
                        new SqlParameter("@CustomerID", Int64.Parse(req.CustomerID)),
                        new SqlParameter("@Application", req.Application),
                        new SqlParameter("@AddEmail", req.AddEmail),
                    };
            return obj.Return_ScalerValue("RemoveEmailSMS", param);
        }
        public string RemoveRoleEmailSMS(GetRoleRemoveEmailSMS req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@EmailTemplateID", Int64.Parse(req.EmailTemplateID)),
                        new SqlParameter("@WarehouseID", Int64.Parse(req.WarehouseID)),
                        new SqlParameter("@CompanyID", Int64.Parse(req.CompanyID)),
                        new SqlParameter("@UserID", Int64.Parse(req.UserID)),
                        new SqlParameter("@CustomerID", Int64.Parse(req.CustomerID)),
                        new SqlParameter("@Application", req.Application),
                        new SqlParameter("@AddRole", req.AddRole),
                    };
            return obj.Return_ScalerValue("RemoveRoleEmailSMS", param);
        }
    }
}
