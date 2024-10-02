


using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WMSWebAPI.Utility.V1
{
    public class SysException
    {
        SqlParameter[] param;
        DBActivity obj;
        public SysException()
        {
            obj = new DBActivity();
        }
        public void ErrorLog(string msg, string source, long uid)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@msg", msg),
                        new SqlParameter("@source", source),
                        new SqlParameter("@uid", uid)
                    };
            obj.Return_ScalerValue("ErrorException", param);
        }

    }
}
