using Newtonsoft.Json.Linq;
using System.Data.SqlClient;
using System.Text.Json;
using WMSWebAPI.Models.V1.Request;

namespace WMSWebAPI.Utility.V1
{
    public class ClientUtility
    {
        SqlParameter[] param;
        DBActivity obj;
        public ClientUtility()
        {
            obj = new DBActivity();
        }
        public async Task<JsonElement> ClientList(GetClientRequest req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@currentpage", Int32.Parse(req.CurrentPage)),
                        new SqlParameter("@recordlimit", Int32.Parse(req.RecordLimit)),
                        new SqlParameter("@CustomerId", Int64.Parse(req.CustomerId)),
                        new SqlParameter("@UserID", Int64.Parse(req.UserID)),
                        new SqlParameter("@Search", req.Search),
                        new SqlParameter("@Filter", req.Filter)
                    };
            return await obj.ConvertDataSetToJObject(obj.Return_DataSet("sp_ClientList", param));
        }
        public string AddEditClient(AddEditClientRequest req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@ClientId", Int64.Parse(req.ClientId)),
                        new SqlParameter("@CompanyId", Int64.Parse(req.CompanyID)),
                        new SqlParameter("@CustomerId", Int64.Parse(req.CustomerId)),
                        new SqlParameter("@UserId", Int64.Parse(req.UserId)),
                        new SqlParameter("@ClientName", req.ClientName),
                        new SqlParameter("@ClientCode", req.ClientCode),
                        new SqlParameter("@Email", req.Email),
                        new SqlParameter("@ContactNo", req.ContactNo),
                        new SqlParameter("@Sector", req.Sector),
                        new SqlParameter("@LedgerNo", req.LedgerNo),
                        new SqlParameter("@Website", req.Website),
                        new SqlParameter("@Active", req.Active),
                        new SqlParameter("@SAPCode", req.SAPCode),
                        new SqlParameter("@CLGroupCode", req.CLGroupCode),
                        new SqlParameter("@CategoryId", Int64.Parse(req.CategoryId)),
                        new SqlParameter("@GSTINUIN", req.GSTINUIN)
                    };
            return obj.Return_ScalerValue("sp_SaveClient", param);
        }
        public async Task<JsonElement> editclientList(editclientList req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@ID", Int64.Parse(req.ID))
                    };
            return await obj.ConvertDataSetToJObject(obj.Return_DataSet("sp_ClientEditDetail", param));
        }

        public async Task<JsonElement> GetParameterbyObjectRef(GetParameter req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@Objectname", req.Object),
                        new SqlParameter("@ReferenceID", Int64.Parse(req.ReferenceID)),
                        new SqlParameter("@CompanyID", Int64.Parse(req.CompanyID)),
                    };
            return await obj.ConvertDataSetToJObject(obj.Return_DataSet("Par_GetObjectParamByReference", param));
        }

        public async Task<JsonElement> Getddlparamvalue(GetddlObjectParam req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@Objectname", req.Object),
                        new SqlParameter("@CompanyID", Int64.Parse(req.CompanyID)),
                    };
            return await obj.ConvertDataSetToJObject(obj.Return_DataSet("Par_GetObjectparam", param));
        }

        public string SaveEditParamvalues(SaveEditParamRequest req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@Objectname", req.Objectname),
                        new SqlParameter("@StatuDetailID", Int64.Parse(req.StatuDetailID)),
                        new SqlParameter("@ReferenceID", Int64.Parse(req.ReferenceID)),
                        new SqlParameter("@StatutoryID", Int64.Parse(req.StatutoryID)),
                        new SqlParameter("@StatutoryValue", req.StatutoryValue),
                        new SqlParameter("@createdBy", Int64.Parse(req.createdBy)),
                        new SqlParameter("@CompanyID", Int64.Parse(req.CompanyID)),
                    };
            return obj.Return_ScalerValue("Par_InsertObjectParamvalues", param);
        }
        public async Task<JsonElement> BindClientCategoryList(BindClientCategory req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@CompanyId", Int64.Parse(req.CompanyId)),
                        new SqlParameter("@CustomerID", Int64.Parse(req.CustomerID)),
                        new SqlParameter("@WarehouseID", Int64.Parse(req.WarehouseID)),
                         new SqlParameter("@UserID", Int64.Parse(req.UserID))
                    };
            return await obj.ConvertDataSetToJObject(obj.Return_DataSet("Sp_BindClientCategory", param));
        }



        public async Task<JsonElement> GetBankDetails(GetBankDetails req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@CompanyId", Int64.Parse(req.CompanyId)),
                        new SqlParameter("@UserId", Int64.Parse(req.UserId)),
                        new SqlParameter("@WarehouseId", Int64.Parse(req.WarehouseId)),
                        new SqlParameter("@CustomerId", Int64.Parse(req.CustomerId)),
                        new SqlParameter("@Object", req.Object),
                        new SqlParameter("@ClientId", Int64.Parse(req.ClientId))
                    };
            return await obj.ConvertDataSetToJObject(obj.Return_DataSet("sp_GetBankDetails", param));
        }


        public string SaveBankDetails(SaveBankDetails req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@ObjectName", req.ObjectName),
                        new SqlParameter("@clientID", Int64.Parse(req.clientID)),
                        new SqlParameter("@CompanyID", Int64.Parse(req.CompanyID)),
                        new SqlParameter("@UserId", Int64.Parse(req.UserId)),
                        new SqlParameter("@CustomerId", req.CustomerId),
                        new SqlParameter("@WarehouseId", Int64.Parse(req.WarehouseId)),
                        new SqlParameter("@AccHolderName", req.AccHolderName),
                        new SqlParameter("@BankName", req.BankName),
                        new SqlParameter("@BranchName", req.BranchName),
                        new SqlParameter("@Creditlimit", Int64.Parse(req.Creditlimit)),
                        new SqlParameter("@CreditDay", Int64.Parse(req.CreditDay))
                       /* new SqlParameter("@AccNumber", req.AccNumber),
                        new SqlParameter("@IfscCode", req.IfscCode),
                        new SqlParameter("@SwiftCode", req.SwiftCode)*/
                    };
            return obj.Return_ScalerValue("sp_SaveBankDetails", param);   //Par_InsertObjectParamvalues
        }

        public string EditBankDetails(EditBankDetails req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@ID", Int64.Parse(req.ID)),
                        new SqlParameter("@ObjectName", req.ObjectName),
                        new SqlParameter("@clientID", Int64.Parse(req.clientID)),
                        new SqlParameter("@CompanyID", Int64.Parse(req.CompanyID)),
                        new SqlParameter("@UserId", Int64.Parse(req.UserId)),
                        new SqlParameter("@CustomerId", req.CustomerId),
                        new SqlParameter("@WarehouseId", Int64.Parse(req.WarehouseId)),
                        new SqlParameter("@AccHolderName", req.AccHolderName),
                        new SqlParameter("@BankName", req.BankName),
                        new SqlParameter("@BranchName", req.BranchName),
                        new SqlParameter("@Creditlimit", Int64.Parse(req.Creditlimit)),
                        new SqlParameter("@CreditDay", Int64.Parse(req.CreditDay))
                        /*new SqlParameter("@AccNumber", req.AccNumber),
                         new SqlParameter("@IfscCode", req.IfscCode),
                          new SqlParameter("@SwiftCode", req.SwiftCode)*/
                    };
            return obj.Return_ScalerValue("sp_EditBankDetails", param);   //Par_InsertObjectParamvalues
        }
    }
}
