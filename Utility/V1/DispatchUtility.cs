using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Data;
using System.Data.SqlClient;
using System.Text.Json;
using WMSWebAPI.Models.V1.Request;
using WMSWebAPI.Utility;
using System.Net.Mail;
using System.Net;
using Microsoft.OpenApi.Models;
using System.Text;
using RestSharp;

namespace WMSWebAPI.Utility.V1
{
    public class DispatchUtility
    {
        SqlParameter[] param;
        DBActivity obj;

        public DispatchUtility()
        {
            obj = new DBActivity();
        }

        public async Task<JsonElement> DispatchList(DispatchListRequest req)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@currentpg", Int32.Parse(req.CurrentPage)),
                new SqlParameter("@recordlmt", Int32.Parse(req.recordLimit)),
                new SqlParameter("@custid", Int64.Parse(req.CustomerId)),
                new SqlParameter("@wrid", Int64.Parse(req.WarehouseId)),
                new SqlParameter("@uid", Int64.Parse(req.UserId)),
                new SqlParameter("@obj", req.Object),
                new SqlParameter("@skeycol", req.filtercol),
                new SqlParameter("@skeyval", req.filterval),
                new SqlParameter("@clientid", Int64.Parse(req.ClientId))
            };

            DataSet ds =  obj.Return_DataSet("DispatchList", param);

            var dispatchListResult = new
            {
                DispatchListResult = new[]
                {
                    new
                    {
                        CurrentPage = req.CurrentPage,
                        TotalRecords = ds.Tables[0].Rows.Count > 0 ? Convert.ToInt32(ds.Tables[0].Rows[0]["TotalRecords"]) : 0,
                        Dashboard = new[]
                        {
                            new
                            {
                                OutboundOrder = ds.Tables[0].Rows.Count > 0 ? Convert.ToInt32(ds.Tables[0].Rows[0]["OutboundOrder"]) : 0,
                                Allocated = ds.Tables[0].Rows.Count > 0 ? Convert.ToInt32(ds.Tables[0].Rows[0]["Allocated"]) : 0,
                                Picking = ds.Tables[0].Rows.Count > 0 ? Convert.ToInt32(ds.Tables[0].Rows[0]["Picking"]) : 0,
                                QC = ds.Tables[0].Rows.Count > 0 ? Convert.ToInt32(ds.Tables[0].Rows[0]["QC"]) : 0,
                                Packing = ds.Tables[0].Rows.Count > 0 ? Convert.ToInt32(ds.Tables[0].Rows[0]["Packing"]) : 0,
                                Shipped = ds.Tables[0].Rows.Count > 0 ? Convert.ToInt32(ds.Tables[0].Rows[0]["Dispatch"]) : 0,
                                CancelOrder = ds.Tables[0].Rows.Count > 0 ? Convert.ToInt32(ds.Tables[0].Rows[0]["CancelOrder"]) : 0
                            }
                        },
                        DispatchList = ds.Tables[1].Rows.Count > 0 ? JsonConvert.SerializeObject(ds.Tables[1]) : "[]"
                    }
                }
            };

            string jsonString = JsonConvert.SerializeObject(dispatchListResult);
            return JsonDocument.Parse(jsonString).RootElement;
        }

        public async Task<JsonElement> BatchDispatchList(BatchDispatchListRequest reqPara)
        {

            param = new SqlParameter[]
                    {new SqlParameter("@custid",Convert.ToInt64(reqPara.CustomerId)),
                    new SqlParameter("@wrid",Convert.ToInt64(reqPara.WarehouseId)),
                    new SqlParameter("@uid",Convert.ToInt64(reqPara.UserId)),
                    new SqlParameter("@bid",Convert.ToInt64(reqPara.BatchID)),

                    };

            return await obj.ConvertDataSetToJObject(obj.Return_DataSet("BatchDispatchList", param));

        }

        public async Task<JsonElement> GetBatchDispatchDetail(BatchDispatchDetailRequest reqPara)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@bid", Convert.ToInt64(reqPara.BatchID)),
                        new SqlParameter("@uid", Convert.ToInt64(reqPara.UserId)),
                        new SqlParameter("@custid", Convert.ToInt64(reqPara.CustomerId)),
                        new SqlParameter("@wrid", Convert.ToInt64(reqPara.WarehouseId)),
                        new SqlParameter("@soid", Convert.ToInt64(reqPara.SOID)),
                        new SqlParameter("@dispId", Convert.ToInt64(reqPara.DispId)),
                    };
            return await obj.ConvertDataSetToJObject(obj.Return_DataSet("BatchDispatchDetailBySO", param));

        }

        public async Task<JsonElement> GetBatchDispatchEdit(DispatchDetailEdit reqPara)
 
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@dispId", Convert.ToInt64(reqPara.DispId))
                    };

            return await obj.ConvertDataSetToJObject(obj.Return_DataSet("DispatchEditByDispId", param));
        }


        public async Task<JsonElement> GetBatchDispatchDetailNEW(BatchDispatchDetailRequestNew reqPara)

        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@bid", Convert.ToInt64(reqPara.BatchID)),
                        new SqlParameter("@uid", Convert.ToInt64(reqPara.UserId)),
                        new SqlParameter("@custid", Convert.ToInt64(reqPara.CustomerId)),
                        new SqlParameter("@wrid", Convert.ToInt64(reqPara.WarehouseId)),
                        new SqlParameter("@soid", Convert.ToInt64(reqPara.SOID)),
                        //new SqlParameter("@AddNew",req.AddNew),
                        new SqlParameter("@dispId",reqPara.dispId)
                    };
            return await obj.ConvertDataSetToJObject(obj.Return_DataSet("BatchDispatchDetailBySONEW", param));

        }



        public string SaveDispatchBySO(SaveDispatchBySORequest req)
        {
            string result = "";
            param = new SqlParameter[]
                    {

                        new SqlParameter("@bid", Convert.ToInt64(req.BatchID)),
                        new SqlParameter("@soid", Convert.ToInt64(req.SOID)),
                        new SqlParameter("@uid", Convert.ToInt64(req.UserId)),
                        new SqlParameter("@custid", Convert.ToInt64(req.CustomerId)),
                        new SqlParameter("@wrid", Convert.ToInt64(req.WarehouseId)),
                        new SqlParameter("@carierid", Convert.ToInt64(req.CarrierID)),
                        new SqlParameter("@trno", req.TrackingNO),
                        new SqlParameter("@driver", req.DriverName),
                        new SqlParameter("@pickby", req.PickUpBy),
                        new SqlParameter("@schdatetime", req.ScheduleDateTime),
                        new SqlParameter("@actdatetime", req.ActualDateTime),
                        new SqlParameter("@lrno", req.LRNo),
                        new SqlParameter("@vehicleno", req.VehicleNo),
                        new SqlParameter("@transremark", req.TransportRemark),
                        new SqlParameter("@bol", req.BOL),
                        new SqlParameter("@transname", req.TransportName),
                        new SqlParameter("@DispId", req.DispId),
                    };

            result = obj.Return_ScalerValue("SaveDispatchBySO", param);
            if (result == "success")
            {
                //DispatchNotification(Convert.ToInt64(req.SOID), Convert.ToInt64(req.UserId));
                //SendDispatchMail(Convert.ToInt64(req.SOID));
            }
            return result;
        }


        public string EditDispatchbyso(EditDispatchBySORequest req)
        {
            string result = "";
            param = new SqlParameter[]
                    {
                        new SqlParameter("@EditVhDateTime", req.EditVhDateTime),
                        new SqlParameter("@EditRelDateTime", req.EditRelDateTime),
                        new SqlParameter("@EditERPInvNo", req.EditERPInvNo),
                        new SqlParameter("@EditDate", req.EditDate),
                        new SqlParameter("@EditSealNo", req.EditSealNo),
                        new SqlParameter("@EditRemark", req.EditRemark),
                        new SqlParameter("@DispId", req.DispId),
                        new SqlParameter("@userId", req.userId),
                        new SqlParameter("@TMSSTATUS", req.TMSSTATUS),
                    };

            result = obj.Return_ScalerValue("EditSaveDispatchBySO", param);
            // if (result == "success")
            // {

            //}
            return result;
        }

       
        public async Task<JsonElement> CarrierDetail(CarrierListRequest reqPara)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@uid", Convert.ToInt64(reqPara.UserId)),
                        new SqlParameter("@custid", Convert.ToInt64(reqPara.CustomerId)),
                        new SqlParameter("@wrid", Convert.ToInt64(reqPara.WarehouseId))
                    };

            return await obj.ConvertDataSetToJObject(obj.Return_DataSet("CarrierList", param));
        }

        public async Task<JsonElement> TrackingDetail(TrackingDetailRequest reqPara)
   
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@orderid", Convert.ToInt64(reqPara.OrderId)),
                        new SqlParameter("@bid", Convert.ToInt64(reqPara.BatchID))
                    };
            return await obj.ConvertDataSetToJObject(obj.Return_DataSet("getTrackingDetail", param));
        
        }

        public string SaveTrackingDetail(SaveTrackingDetailRequest req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@uid", Convert.ToInt64(req.UserId)),
                        new SqlParameter("@orderid", Convert.ToInt64(req.OrderId)),
                        new SqlParameter("@date", req.TrackDate),
                        new SqlParameter("@time", req.TrackTime),
                        new SqlParameter("@status", req.Status),
                        new SqlParameter("@remark", req.Remark)
                    };
            return obj.Return_ScalerValue("saveTrackingDetail", param);
        }

        public string SendDispatchMail(long soid)
        {
            DataSet ds = new DataSet();
            DataSet dsdtls = new DataSet();
            string message = "Please find below details of Order with status.";
            string useremail = "", UserName = "", Email_host = "", Email_password = "", from = "", Result = "";
            int Email_port = 0;
            try
            {
                ds = obj.Return_DataSet("sp_emailDetails", param);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    Email_host = ds.Tables[0].Rows[0]["EmailHost"].ToString();
                    Email_password = ds.Tables[0].Rows[0]["EmailPassword"].ToString();
                    Email_port = Convert.ToInt32(ds.Tables[0].Rows[0]["EmailPort"]);
                    from = ds.Tables[0].Rows[0]["EmailUsername"].ToString();
                }

                SmtpClient smtpClient = new SmtpClient(Email_host, Email_port);
                MailAddress fromAddress = new MailAddress(from, "iWMS");
                NetworkCredential basicCredential = new NetworkCredential(from, Email_password);

                param = new SqlParameter[]
                    {
                        new SqlParameter("@soid", soid)
                    };
                dsdtls = obj.Return_DataSet("SP_getDispatchMailDtls", param);
                useremail = dsdtls.Tables[0].Rows[0]["Email"].ToString();
                //useremail = "surajg@brilliantinfosys.com";
                UserName = dsdtls.Tables[0].Rows[0]["UserName"].ToString();

                //From address will be given as a MailAddress Object
                MailMessage message1 = new MailMessage();

                message1.From = fromAddress;

                //To address collection of MailAddress
                message1.To.Add(useremail);
                message1.Subject = "Dispatch Notification" + " Order #" + soid + " ";

                //Body can be Html or text format
                //Specify true if it  is html message
                message1.IsBodyHtml = true;

                //Message body content
                message1.Body = "Dear " + UserName + ", <br/><br/>";
                message1.Body = message1.Body + message;
                message1.Body = message1.Body + "<br/><br/>" + GetMsgHead(dsdtls);
                message1.Body = message1.Body + MailGetFooter();

                smtpClient.EnableSsl = false;
                //Send SMTP mail
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = basicCredential;
                smtpClient.Send(message1);
                Result = "success";
            }
            catch (Exception e) { Result = e.Message; }
            return Result;
        }
        public string GetMsgHead(DataSet ds)
        {
            string messageBody = "", OrderDate = "", orderno = "", Deliverydate = "", Status = "", RequestedBy = "", saporderno = "";
            try
            {
                OrderDate = ds.Tables[0].Rows[0]["OrderDate"].ToString();
                Deliverydate = ds.Tables[0].Rows[0]["DeliveryDate"].ToString();
                Status = ds.Tables[0].Rows[0]["StatusName"].ToString();
                RequestedBy = ds.Tables[0].Rows[0]["UserName"].ToString();
                orderno = ds.Tables[0].Rows[0]["OrderId"].ToString();
                saporderno = ds.Tables[0].Rows[0]["SAPOrderNo"].ToString();

                messageBody = "<font><b>Order Summary :  </b> </font><br/><br/>";

                string htmlTableStart = "<table style=\"border-collapse:collapse; text-align:center;\" >";
                string htmlTableEnd = "</table>";
                string htmlHeaderRowStart = "<tr style =\"background-color:#6FA1D2; color:#ffffff;\">";
                string htmlHeaderRowEnd = "</tr>";
                string htmlTrStart = "<tr style =\"color:#555555; text-align: center;\">";
                string htmlTrEnd = "</tr>";
                string htmlTdStart = "<td style=\" border-color:#5c87b2; border-style:solid; border-width:thin; padding: 5px; text-align: center;\">";
                string htmlTdEnd = "</td>";

                messageBody += htmlTableStart;

                messageBody += htmlHeaderRowStart;
                messageBody += htmlTdStart + "Order Date" + htmlTdEnd;
                messageBody += htmlTdStart + "Order Id" + htmlTdEnd;
                messageBody += htmlTdStart + "SAP Order No" + htmlTdEnd;
                messageBody += htmlTdStart + "Exp. Delivery Date" + htmlTdEnd;
                messageBody += htmlTdStart + "Status" + htmlTdEnd;
                messageBody += htmlTdStart + "Requested By" + htmlTdEnd;
                messageBody += htmlHeaderRowEnd;

                messageBody += htmlTrStart;
                messageBody += htmlTdStart + " " + OrderDate + " " + htmlTdEnd;
                messageBody += htmlTdStart + " " + orderno + " " + htmlTdEnd;
                messageBody += htmlTdStart + " " + saporderno + " " + htmlTdEnd;
                messageBody += htmlTdStart + " " + Deliverydate + " " + htmlTdEnd;
                messageBody += htmlTdStart + " " + Status + " " + htmlTdEnd;
                messageBody += htmlTdStart + " " + RequestedBy + " " + htmlTdEnd;

                messageBody += htmlTrEnd;
                messageBody += htmlTableEnd;
            }
            catch (Exception ex)
            {
            }
            finally
            {
            }
            return messageBody;
        }
        public string MailGetFooter()
        {
            string MailFooter = "";
            try
            {
                MailFooter = "<br/><br/>" +

                "Please <a href='http://173.212.244.46/DemandPortal/' target='_blank' style='color: #3BB9FF;  text-decoration: none;'>click here </a>  to view the order details." +
                "<br/><br/>" +
                "Thank you, <br/>" +
                "iWMS Notification Team<br/>" +
                "<br/><br/><hr/>";
            }
            catch
            {
            }
            return MailFooter;
        }



        //public async Task<string> DispatchNotification(long soid, long uid)
        //{
        //    ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls | SecurityProtocolType.Ssl3;
        //    string result = "";
        //    DispatchNotify dn = new DispatchNotify();
        //    try
        //    {
        //        // Token
        //        string username = "C_BALAJI";
        //        string password = "Wittymoon502@";
        //        var client = new RestClient("https://fiori-dev.da.com.bn/sap/opu/odata/sap/ZIWMS_OUTBOUND_DELIVERIES_SRV/OutBoundHeaderSet?sap-client=520");
        //        var reqcode = new RestRequest(Method.GET);
        //        reqcode.AddHeader("Content-Type", "application/json; charset=UTF-8");
        //        reqcode.AddHeader("Authorization", "Basic " + Convert.ToBase64String(Encoding.Default.GetBytes(username + ":" + password)));
        //        reqcode.AddHeader("X-CSRF-Token", "fetch");

        //        // Execute the request
        //        var rescode = await client.ExecuteAsync(reqcode); // Await here
        //        var name = rescode.Headers.FirstOrDefault(h => h.Name == "some-header-name")?.Name;
        //        var value = rescode.Headers.FirstOrDefault(h => h.Name == "some-header-name")?.Value;

        //        // Continue with your logic...
        //        dn = ReqJSON(soid);
        //        string json = JsonConvert.SerializeObject(dn);

        //        // Dispatch Notification
        //        var clientPost = new RestClient("https://fiori-dev.da.com.bn/sap/opu/odata/sap/ZIWMS_OUTBOUND_DELIVERIES_SRV/OutBoundHeaderSet?sap-client=520");
        //        var req = new RestRequest(Method.POST);
        //        req.AddHeader("Authorization", "Basic " + Convert.ToBase64String(Encoding.Default.GetBytes(username + ":" + password)));
        //        req.AddHeader(name, value);
        //        foreach (var ck in rescode.Cookies)
        //        {
        //            req.AddCookie(ck.Name, ck.Value);
        //        }
        //        req.AddHeader("Accept", "application/json");
        //        req.AddParameter("application/json; charset=UTF-8", json, ParameterType.RequestBody);

        //        // Execute the post request
        //        var res = await clientPost.ExecuteAsync(req); // Await here

        //        JObject joResponse = JObject.Parse(res.Content);
        //        if ((JObject)joResponse["d"] != null)
        //        {
        //            JObject ojObject = (JObject)joResponse["d"];
        //            string val = ojObject["OutBoundOrderNo"].ToString();

        //            param = new SqlParameter[]
        //            {
        //        new SqlParameter("@delno", val),
        //        new SqlParameter("@soid", soid),
        //        new SqlParameter("@uid", uid),
        //        new SqlParameter("@rescode", "200"),
        //        new SqlParameter("@msg", "Dispatch notification sent successfully"),
        //        new SqlParameter("@status", "Success")
        //            };
        //            obj.Return_ScalerValue("UpdateDelivery", param);
        //        }
        //        if ((JObject)joResponse["error"] != null)
        //        {
        //            JObject ojObject = (JObject)joResponse["error"];
        //            JObject ojmsg = (JObject)ojObject["message"];
        //            string val = ojmsg["value"].ToString();

        //            param = new SqlParameter[]
        //            {
        //        new SqlParameter("@delno", ""),
        //        new SqlParameter("@soid", soid),
        //        new SqlParameter("@uid", uid),
        //        new SqlParameter("@rescode", "400"),
        //        new SqlParameter("@msg", val),
        //        new SqlParameter("@status", "Failed")
        //            };
        //            obj.Return_ScalerValue("UpdateDelivery", param);
        //        }

        //        result = "success";
        //    }
        //    catch (Exception ex)
        //    {
        //        result = ex.Message;
        //    }
        //    return result;
        //}



        public DispatchNotify ReqJSON(long soid)
        {
            DispatchNotify main = new DispatchNotify();
            DataSet ds = new DataSet();
            try
            {
                param = new SqlParameter[]
                    {
                        new SqlParameter("@soid", soid)
                    };
                ds = obj.Return_DataSet("GetDispatchData", param);

                main.DeliveryNo = ds.Tables[0].Rows[0]["DeliveryNo"].ToString();
                main.OutBoundOrderNo = ds.Tables[0].Rows[0]["OutBoundOrderNo"].ToString();
                main.DeliveryType = ds.Tables[0].Rows[0]["DeliveryType"].ToString();

                //OutBoundItemSet

                int dscnt = ds.Tables[0].Rows.Count;
                List<OutBoundItemSet> oislst = new List<OutBoundItemSet>();
                for (int i = 0; i < dscnt; i++)
                {
                    OutBoundItemSet ois = new OutBoundItemSet();
                    ois.DeliveryNo = ds.Tables[0].Rows[i]["DeliveryNo"].ToString();
                    ois.ItemNo = ds.Tables[0].Rows[i]["ItemNo"].ToString();
                    ois.SUkCode = ds.Tables[0].Rows[i]["SUkCode"].ToString();
                    ois.DeliveryQty = ds.Tables[0].Rows[i]["DeliveryQty"].ToString();
                    ois.SalesUnitIso = ds.Tables[0].Rows[i]["SalesUnitIso"].ToString();
                    ois.SalesUnit = ds.Tables[0].Rows[i]["SalesUnit"].ToString();
                    oislst.Add(ois);
                }
                main.OutBoundItemSet = oislst;
                //OutBoundItemSet End

                //OutBoundHeaderPartnerSet
                OutBoundHeaderPartnerSet ohts = new OutBoundHeaderPartnerSet();
                List<OutBoundHeaderPartnerSet> ohpslst = new List<OutBoundHeaderPartnerSet>();
                ohts.DeliveryNo = ds.Tables[0].Rows[0]["DeliveryNo"].ToString();
                ohts.PartnerRole = ds.Tables[0].Rows[0]["PartnerRole"].ToString();
                ohts.PartnerNo = ds.Tables[0].Rows[0]["PartnerNo"].ToString();
                ohpslst.Add(ohts);
                main.OutBoundHeaderPartnerSet = ohpslst;
                //OutBoundHeaderPartnerSet End

                //OutBoundHeaderDeadLineSet
                OutBoundHeaderDeadLineSet ohds = new OutBoundHeaderDeadLineSet();
                List<OutBoundHeaderDeadLineSet> ohdslst = new List<OutBoundHeaderDeadLineSet>();
                ohds.DeliveryNo = ds.Tables[0].Rows[0]["DeliveryNo"].ToString();
                ohds.Timetype = ds.Tables[0].Rows[0]["Timetype"].ToString();
                ohds.TimestampUtc = null; //ds.Tables[0].Rows[0]["TimestampUtc"].ToString();
                ohds.Timezone = ds.Tables[0].Rows[0]["Timezone"].ToString();
                ohdslst.Add(ohds);
                main.OutBoundHeaderDeadLineSet = ohdslst;
                //OutBoundHeaderDeadLineSet End

                //OutBoundHeaderOrgSet
                OutBoundHeaderOrgSet ohos = new OutBoundHeaderOrgSet();
                ohos.ShipPoint = ds.Tables[0].Rows[0]["ShipPoint"].ToString();
                ohos.SalesOrg = ds.Tables[0].Rows[0]["SalesOrg"].ToString();
                main.OutBoundHeaderOrgSet = ohos;
                //OutBoundHeaderOrgSet End

                //OutBoundItemOrgSet            
                List<OutBoundItemOrgSet> oioslst = new List<OutBoundItemOrgSet>();
                for (int j = 0; j < dscnt; j++)
                {
                    OutBoundItemOrgSet oios = new OutBoundItemOrgSet();
                    oios.DeliveryNo = ds.Tables[0].Rows[j]["DeliveryNo"].ToString();
                    oios.ItemNumber = ds.Tables[0].Rows[j]["ItemNumber"].ToString();
                    oios.Distribution_Channel = ds.Tables[0].Rows[j]["Distribution_Channel"].ToString();
                    oios.Division = ds.Tables[0].Rows[j]["Division"].ToString();
                    oios.Plant = ds.Tables[0].Rows[j]["Plant"].ToString();
                    oioslst.Add(oios);
                }
                main.OutBoundItemOrgSet = oioslst;
                //OutBoundItemOrgSet End

                //ReturnMessageSet
                List<ReturnMessageSet> rmslst = new List<ReturnMessageSet>();
                main.ReturnMessageSet = rmslst;
                //ReturnMessageSet End
            }
            catch (Exception ex)
            {
            }
            return main;
        }


        public string SaveReturn(SaveReturnBySORequest req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@custid", req.CustomerId),
                        new SqlParameter("@wrid", req.WarehouseId),
                        new SqlParameter("@uid", req.UserId),
                        new SqlParameter("@soid", req.SOID),
                        new SqlParameter("@data", req.Data)
                    };
            return obj.Return_ScalerValue("SaveReturnSO", param);
        }


        public string UpdateQty(UpdateQtyRequest req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@did", req.DispatchId),
                        new SqlParameter("@soid", req.Soid),
                        new SqlParameter("@prodid", req.ProdId),
                        new SqlParameter("@cartonid", req.CartonId),
                        new SqlParameter("@lot", req.Lottables),
                        new SqlParameter("@dispqty", req.DispatchQty),
                        new SqlParameter("@qty", req.Qty),
                        new SqlParameter("@uid", req.UserId)
                    };
            return obj.Return_ScalerValue("UpdateDispQty", param);
        }


  
        public async Task<JsonElement> getDriverList(reqDispatchDriverList reqPara)
        {
            param = new SqlParameter[]
            {
                new SqlParameter("@CustomerId",Convert.ToInt32(reqPara.CustomerId)),
                new SqlParameter("@UserId", Convert.ToInt32(reqPara.UserId)),
                new SqlParameter("@Object",reqPara.Object),
                new SqlParameter("@searchValue",reqPara.searchValue)
            };
            return await obj.ConvertDataSetToJObject(obj.Return_DataSet("sp_getDemandDriverList", param));

        }

        public string saveDriver(saveDispatchDriverDetails req)
        {
            param = new SqlParameter[]
            {
                    new SqlParameter("@CustomerId",Convert.ToInt32(req.CustomerId)),
                    new SqlParameter("@UserId", Convert.ToInt32(req.UserId)),
                    new SqlParameter("@Warehouseid", Convert.ToInt32(req.Warehouseid)),
                    new SqlParameter("@DriverId", Convert.ToInt32(req.DriverId)),
                    new SqlParameter("@OrderId", Convert.ToInt32(req.OrderId)),
                    new SqlParameter("@Contactno", req.Contactno),
                    new SqlParameter("@Email", req.Email),
                    new SqlParameter("@DeviceId", Convert.ToInt32(req.DeviceId)),
                    new SqlParameter("@VehicleId", Convert.ToInt32(req.VehicleId))
            };
            return obj.Return_ScalerValue("sp_saveDriverDetails", param);
        }

        public async Task<JsonElement> driverTransportdetail(driverTransportdetailRequest req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@DispatchId", req.DispatchId)
                    };
            return await obj.ConvertDataSetToJObject(obj.Return_DataSet("getdriverTransportdetail", param));

        }
        public string CheckDriverAssignInvoice(ReqDriverInvoice ReqPara)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@CustomerId", Convert.ToInt64(ReqPara.CustomerId)),
                        new SqlParameter("@OrderId", ReqPara.OrderId)
                    };
            return obj.Return_ScalerValue("sp_chkDriverAssInvorSku", param);
        }

    }
}
