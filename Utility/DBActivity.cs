


//using Microsoft.Ajax.Utilities;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text.Json;
using System.Web;

namespace WMSWebAPI.Utility
{
    public class DBActivity
    {
        private DataSet ds;
        private DataTable _dt;

        public string? con1 { get; set; }

        public string? connstr { get; set; }
        public readonly IConfiguration Config;


        public DBActivity()
        {
            Config = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            //read connectstring from appsettings.json
            connstr = Config.GetConnectionString("DefaultConnection");

        }

        //private string GetConnectionString()
        //{
        //    // Get the current domain
        //    string domain = HttpContext.Current.Request.Url.Host;

        //    // Select the appropriate connection string based on the domain
        //    if (domain.Contains("expressmobuat.easycloudwms.com"))
        //    {
        //        return ConfigurationManager.AppSettings["Database1ConnectionString"];
        //    }
        //    else if (domain.Contains("expressmobuat.easycloudwms.com"))

        //    {
        //        return ConfigurationManager.AppSettings["Database2ConnectionString"];
        //    }
        //    else if (domain.Contains("localhost"))

        //    {
        //        return ConfigurationManager.AppSettings["Database2ConnectionString"];
        //    }



        //    throw new Exception("Unknown domain");
        //}
        public string Return_ScalerValue(string ProcName, params SqlParameter[] Param)
        {
            SqlCommand cmd;
            string result = "";
            using (SqlConnection conn = new SqlConnection(connstr))
            {
                try
                {
                    cmd = new SqlCommand(ProcName, conn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    if (Param != null)
                    {
                        foreach (SqlParameter p in Param)
                        {
                            cmd.Parameters.Add(p);
                        }
                    }
                    conn.Open();
                    result = cmd.ExecuteScalar().ToString();
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }
                finally
                {
                    conn.Close();
                }
                return result;
            }
        }
        public DataSet Return_DataSet(string procName, params SqlParameter[] param)
        {
            DataSet ds = new DataSet();
            using (SqlConnection conn = new SqlConnection(connstr))
            {
                try
                {
                    SqlDataAdapter da = new SqlDataAdapter(procName, connstr);
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    if (param != null)
                    {
                        foreach (SqlParameter p in param)
                        {
                            da.SelectCommand.Parameters.Add(p);
                        }
                    }
                    conn.Open();
                    da.Fill(ds);
                }
                catch (Exception ex)
                {
                    throw;
                }
                finally
                {
                    conn.Close();
                }
                return ds;
            }

        }
        public string ConvertDataSetToJSON(DataSet dataSet)
        {

            string JSONString = string.Empty;
            if (dataSet.Tables[0].Rows.Count > 0)
            {
                JSONString = JsonConvert.SerializeObject(dataSet);
            }
            else
            { JSONString = "{\"Table\":[]}"; }

            return JSONString;
        }
        public async Task<JsonElement> ConvertDataSetToJObject(DataSet dataSet)
        {
            string JSONString = string.Empty;
            if (dataSet.Tables[0].Rows.Count > 0)
            {
                JSONString = JsonConvert.SerializeObject(dataSet);
            }
            else
            { JSONString = "{\"Table\":[]}"; }
            JsonDocument doc = JsonDocument.Parse(JSONString);
            JsonElement respjson = doc.RootElement;
            //  JsonElement respjson = JsonElement.Parse(JSONString);

            return respjson;
        }

        public DataTable exeSP_DT_adapter(string procName, params SqlParameter[] param)
        {
            using (SqlConnection conn = new SqlConnection(connstr))
            {
                try
                {
                    SqlDataAdapter da = new SqlDataAdapter(procName, connstr);
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    if (param != null)
                    {
                        foreach (SqlParameter p in param)
                        {
                            da.SelectCommand.Parameters.Add(p);
                        }
                    }

                    //DataTable _dt = new DataTable();
                    _dt = new DataTable();
                    conn.Open();
                    da.Fill(_dt);
                    return _dt;
                }

                catch (Exception ex)
                {

                    throw;
                }
                finally
                {
                    conn.Close();
                }
            }
        }
        public string DataTableToJSONWithJSONNet(DataTable table)
        {
            string JSONString = string.Empty;
            JSONString = JsonConvert.SerializeObject(table);
            return JSONString;
        }

        //Akash Code Need To Verify
        public JObject ConvertStringToJObject(string data)
        {
            JObject respjson = JObject.Parse("{\"Table\":[]}");
            string JSONString = string.Empty;
            if (data != null)
            {
                respjson = JObject.Parse(data);
                //var dd = new { Table = data };
            }
            return respjson;
        }

        public string Return_StringOutPut(string procName, string jsonOutputParam, params SqlParameter[] param)
        {
            string json = "{\"Table\":[]}";
            using (SqlConnection conn = new SqlConnection(connstr))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand(procName, conn);

                    cmd.CommandType = CommandType.StoredProcedure;
                    if (param != null)
                    {
                        foreach (SqlParameter p in param)
                        {
                            cmd.Parameters.Add(p);
                        }
                    }
                    cmd.Parameters.Add(jsonOutputParam, SqlDbType.NVarChar, -1).Direction = ParameterDirection.Output;
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    json = cmd.Parameters[jsonOutputParam].Value.ToString();

                }
                catch (Exception ex)
                {
                    throw;
                }
                finally
                {
                    conn.Close();
                }
                return json;
            }
        }
    }
}
