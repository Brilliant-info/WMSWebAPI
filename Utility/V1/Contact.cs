using Newtonsoft.Json.Linq;
using System.Data.SqlClient;
using System.Text.Json;
using WMSWebAPI.Models.V1.Request;

namespace WMSWebAPI.Utility.V1
{
    public class Contact
    {
        SqlParameter[] param;
        DBActivity obj;
        public Contact()
        {
            obj = new DBActivity();
        }
        public async Task<JsonElement> ContactList(GetcontactListRequest req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@CurrentPage", Int32.Parse(req.CurrentPage)),
                        new SqlParameter("@Record", Int32.Parse(req.RecordLimit)),
                        new SqlParameter("@CompanyId", Int64.Parse(req.CompanyId)),
                        new SqlParameter("@UserId", Int64.Parse(req.UserId)),
                        new SqlParameter("@WarehouseId", Int64.Parse(req.WarehouseId)),
                        new SqlParameter("@Search", req.Search),
                        new SqlParameter("@Filter", req.Filter),
                        new SqlParameter("@Object", req.Object),
                        new SqlParameter("@ObjectId", Int64.Parse(req.ObjectId))
                    };
            return await obj.ConvertDataSetToJObject(obj.Return_DataSet("ContactList", param));
        }
        public string SaveContact(SaveContactRequest req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@ContactID", Int64.Parse(req.ContactID)),
                        new SqlParameter("@ObjectName", req.ObjectName),
                        new SqlParameter("@ReferenceID", Int64.Parse(req.ReferenceID)),
                        new SqlParameter("@ContactName", req.ContactName),
                        new SqlParameter("@EmailID", req.EmailID),
                        new SqlParameter("@MobileNo", req.MobileNo),
                        new SqlParameter("@Address", req.Address),
                        new SqlParameter("@Country", req.Country),
                        new SqlParameter("@State", req.State),
                        new SqlParameter("@City", req.City),
                        new SqlParameter("@PostalCode", req.PostalCode),
                        new SqlParameter("@Active", req.Active),
                        new SqlParameter("@CompanyID", Int64.Parse(req.CompanyID)),
                        new SqlParameter("@CreatedBy", Int64.Parse(req.CreatedBy)),
                        new SqlParameter("@clientIsOwner", req.clientIsOwner),

                    };
            return obj.Return_ScalerValue("Con_SaveContactAddress", param);
        }
    }
}
