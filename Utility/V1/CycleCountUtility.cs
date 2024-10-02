using Newtonsoft.Json.Linq;
using System.Data.SqlClient;
using System.Text.Json;
using WMSWebAPI.Models.V1.Request;

namespace WMSWebAPI.Utility.V1
{
    public class CycleCountUtility
    {
        SqlParameter[] param;
        DBActivity obj;
        public CycleCountUtility()
        {
            obj = new DBActivity();
        }
        public async Task<JsonElement> CycleCountList(GetCycleCountListRequest req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@CurrentPage", Int64.Parse(req.CurrentPage)),
                        new SqlParameter("@RecordLimit", Int64.Parse(req.RecordLimit)),
                        new SqlParameter("@WarehouseId", Int64.Parse(req.WarehouseId)),
                        new SqlParameter("@UserId", Int64.Parse(req.UserId)),
                        new SqlParameter("@CustomerId", Int64.Parse(req.CustomerId)),
                        new SqlParameter("@Filter", req.Filter),
                        new SqlParameter("@Search", req.Search)
                    };
            return await obj.ConvertDataSetToJObject(obj.Return_DataSet("Sp_CycleCountList", param));
        }
        public async Task<JsonElement> CycleCountEdit(CycleCountEditRequest req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@CountHeadID", Int64.Parse(req.CountHeadID)),
                        new SqlParameter("@UserId", Int64.Parse(req.UserId))
                    };
            return await obj.ConvertDataSetToJObject(obj.Return_DataSet("Sp_CycleCountEdit", param));
        }
        public async Task<JsonElement> CycleCountdetail(CycleCountdetailRequest req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@CurrentPage", Int64.Parse(req.CurrentPage)),
                        new SqlParameter("@RecordLimit", Int64.Parse(req.RecordLimit)),
                        new SqlParameter("@CountHeadID", Int64.Parse(req.CountHeadID)),
                        new SqlParameter("@UserId", Int64.Parse(req.UserId)),
                        new SqlParameter("@Filter", req.Filter),
                        new SqlParameter("@Search", req.Search)
                    };
            return await obj.ConvertDataSetToJObject(obj.Return_DataSet("Sp_CycleCountdetailList", param));
        }
        public string CycleCountUpdate(CycleCountUpdateRequest req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@CycleCountId", Int64.Parse(req.CycleCountId)),
                        new SqlParameter("@UserId", Int64.Parse(req.UserId)),
                        new SqlParameter("@Active", req.Active),
                        new SqlParameter("@StatusName", req.StatusName)
                    };
            return obj.Return_ScalerValue("UpdateCycleCount", param);
        }
    }
}
