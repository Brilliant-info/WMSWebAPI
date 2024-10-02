using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using WMSWebAPI.Models.V1.Request;
using WMSWebAPI.Models.V1.Responce;
using WMSWebAPI.Route;
using WMSWebAPI.Utility.V1;

namespace WMSWebAPI.Controllers.V1
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        CompanyUtility obj = new CompanyUtility();
        SysException exe = new SysException();

        [HttpPost]
        [Route(APIRoute.Company.GetCompanyList)]
        public async Task<ResponceList> GetCompanyList(GetCompanyListRequest ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JsonElement result = await obj.CompanyList(ReqPara);

                    Response = ResponceResult.SuccessResponseList(result);
                }
                else
                {
                    Response = ResponceResult.ErrorResponseList("No record found..!");
                }
            }
            catch (Exception ex)
            {
                Response = ResponceResult.ErrorResponseList(ex.Message.ToString());
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Company.GetCompanyList, Int64.Parse(ReqPara.UserId));
            }
            return Response;
        }


        [HttpPost]
        [Route(APIRoute.Company.AddCompany)]
        public async Task<Responce> AddCompany(AddCompanyRequest ReqPara)
        {
            Responce Response = new Responce();
            try
            {
                if (ReqPara != null)
                {
                    string result = obj.AddCompany(ReqPara);
                    if (result == "success")
                    {
                        Response = ResponceResult.SuccessResponse(result);
                    }

                    else
                    {
                        Response = ResponceResult.ValidateResponse(result);
                    }
                }
                else
                {
                    Response = ResponceResult.ErrorResponse("Record Not Save..!");
                }
            }
            catch (System.Exception ex)
            {
                Response = ResponceResult.ErrorResponse(ex.Message.ToString());
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Product.AddProduct, Int64.Parse(ReqPara.UserId));
            }
            return Response;
        }

        [HttpPost]
        [Route(APIRoute.Company.Editcompany)]
        public async Task<ResponceList> EditCompany(EditCompanyRequest ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JsonElement result = await obj.EditCompany(ReqPara);

                    Response = ResponceResult.SuccessResponseList(result);
                }
                else
                {
                    Response = ResponceResult.ErrorResponseList("No record found..!");
                }
            }
            catch (System.Exception ex)
            {
                Response = ResponceResult.ErrorResponseList(ex.Message.ToString());
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Company.Editcompany, Int64.Parse(ReqPara.UserId));
            }
            return Response;
        }

        /*  [HttpPost]
          [Route(APIRoute.Customer.EditCustomer)]
          public ResponceList EditCustomer(EditCustomerRequest ReqPara)
          {
              ResponceList Response = new ResponceList();
              try
              {
                  if (ReqPara != null)
                  {
                      JsonElement result = obj.EditCustomer(ReqPara);

                      Response = ResponceResult.SuccessResponseList(result);
                  }
                  else
                  {
                      Response = ResponceResult.ErrorResponseList("No record found..!");
                  }
              }
              catch (System.Exception ex)
              {
                  Response = ResponceResult.ErrorResponseList(ex.Message.ToString());
                  exe.ErrorLog(ex.Message.ToString(), APIRoute.Customer.EditCustomer, Int64.Parse(ReqPara.UserId));
              }
              return Response;
          }

          [HttpPost]
          [Route(APIRoute.Customer.ShowWarehouse)]
          public ResponceList ShowWarehouse(ShowWarehouseRequest ReqPara)
          {
              ResponceList Response = new ResponceList();
              try
              {
                  if (ReqPara != null)
                  {
                      JsonElement result = obj.ShowWarehouse(ReqPara);

                      Response = ResponceResult.SuccessResponseList(result);
                  }
                  else
                  {
                      Response = ResponceResult.ErrorResponseList("No record found..!");
                  }
              }
              catch (System.Exception ex)
              {
                  Response = ResponceResult.ErrorResponseList(ex.Message.ToString());
                  exe.ErrorLog(ex.Message.ToString(), APIRoute.Customer.ShowWarehouse, Int64.Parse(ReqPara.UserId));
              }
              return Response;
          }

          [HttpPost]
          [Route(APIRoute.Customer.AssginCustomerWarehouse)]
          public Responce AssginCustomerWarehouse(AssginCustomerWarehouseRequest ReqPara)
          {
              Responce Response = new Responce();
              try
              {
                  if (ReqPara != null)
                  {
                      string result = obj.AssginCustomerWarehouse(ReqPara);
                      if (result == "success")
                      {
                          Response = ResponceResult.SuccessResponse(result);
                      }
                      else
                      {
                          Response = ResponceResult.ValidateResponse(result);
                      }
                  }
                  else
                  {
                      Response = ResponceResult.ErrorResponse("Record Not Save..!");
                  }
              }
              catch (System.Exception ex)
              {
                  Response = ResponceResult.ErrorResponse(ex.Message.ToString());
                  exe.ErrorLog(ex.Message.ToString(), APIRoute.Customer.AssginCustomerWarehouse, Int64.Parse(ReqPara.UserId));
              }
              return Response;
          }


          [HttpPost]
          [Route(APIRoute.Customer.RemoveWarehouse)]
          public Responce RemoveWarehouse(RemoveWarehouseRequest ReqPara)
          {
              Responce Response = new Responce();
              try
              {
                  if (ReqPara != null)
                  {
                      string result = obj.RemoveWarehouse(ReqPara);
                      if (result == "success")
                      {
                          Response = ResponceResult.SuccessResponse(result);
                      }
                      else
                      {
                          Response = ResponceResult.ValidateResponse(result);
                      }
                  }
                  else
                  {
                      Response = ResponceResult.ErrorResponse("Record Not Save..!");
                  }
              }
              catch (System.Exception ex)
              {
                  Response = ResponceResult.ErrorResponse(ex.Message.ToString());
                  exe.ErrorLog(ex.Message.ToString(), APIRoute.Customer.RemoveWarehouse, Int64.Parse(ReqPara.UserId));
              }
              return Response;
          }
        */

        [HttpPost]
        [Route(APIRoute.Company.EmailConfigList)]
        public async Task<ResponceList> EmailConfigList(GetEmailConfigList ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JsonElement result = await obj.EmailConfigList(ReqPara);

                    Response = ResponceResult.SuccessResponseList(result);
                }
                else
                {
                    Response = ResponceResult.ErrorResponseList("No record found..!");
                }
            }
            catch (Exception ex)
            {
                Response = ResponceResult.ErrorResponseList(ex.Message.ToString());
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Company.EmailConfigList, ReqPara.UserId);
            }
            return Response;
        }


        [HttpPost]
        [Route(APIRoute.Company.EmailConfigSave)]
        public async Task<Responce> EmailConfigSave(EmailConfigSave ReqPara)
        {
            Responce Response = new Responce();
            try
            {
                if (ReqPara != null)
                {
                    string result = obj.EmailConfigSave(ReqPara);
                    if (result == "success")
                    {
                        Response = ResponceResult.SuccessResponse(result);
                    }

                    else
                    {
                        Response = ResponceResult.ValidateResponse(result);
                    }
                }
                else
                {
                    Response = ResponceResult.ErrorResponse("Record Not Save..!");
                }
            }
            catch (System.Exception ex)
            {
                Response = ResponceResult.ErrorResponse(ex.Message.ToString());
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Company.EmailConfigSave, ReqPara.UserId);
            }
            return Response;
        }

        [HttpPost]
        [Route(APIRoute.Company.GetholidayList)]
        public async Task<ResponceList> GetholidayList(RequestGetholidayList ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JsonElement result = await obj.GetholidayList(ReqPara);

                    Response = ResponceResult.SuccessResponseList(result);
                }
                else
                {
                    Response = ResponceResult.ErrorResponseList("No record found..!");
                }
            }
            catch (Exception ex)
            {
                Response = ResponceResult.ErrorResponseList(ex.Message.ToString());
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Company.GetholidayList, 0);
            }
            return Response;
        }

        [HttpPost]
        [Route(APIRoute.Company.Saveholidaylist)]
        public async Task<Responce> Saveholidaylist(reqSaveholidaylist ReqPara)
        {
            Responce Response = new Responce();
            try
            {
                if (ReqPara != null)
                {
                    string result = obj.Saveholidaylist(ReqPara);
                    if (result == "success")
                    {
                        Response = ResponceResult.SuccessResponse(result);
                    }

                    else
                    {
                        Response = ResponceResult.ValidateResponse(result);
                    }
                }
                else
                {
                    Response = ResponceResult.ErrorResponse("Record Not Save..!");
                }
            }
            catch (System.Exception ex)
            {
                Response = ResponceResult.ErrorResponse(ex.Message.ToString());
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Company.Saveholidaylist, 0);
            }
            return Response;
        }

        [HttpPost]
        [Route(APIRoute.Company.SaveTaxlist)]
        public async Task<Responce> SaveTaxlist(reqSaveTaxlist ReqPara)
        {
            Responce Response = new Responce();
            try
            {
                if (ReqPara != null)
                {
                    string result = obj.SaveTaxlist(ReqPara);
                    if (result == "success")
                    {
                        Response = ResponceResult.SuccessResponse(result);
                    }

                    else
                    {
                        Response = ResponceResult.ValidateResponse(result);
                    }
                }
                else
                {
                    Response = ResponceResult.ErrorResponse("Record Not Save..!");
                }
            }
            catch (System.Exception ex)
            {
                Response = ResponceResult.ErrorResponse(ex.Message.ToString());
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Company.SaveTaxlist, 0);
            }
            return Response;
        }

        [HttpPost]
        [Route(APIRoute.Company.GetTaxList)]
        public async Task<ResponceList> GetTaxList(RequestGetTaxList ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JsonElement result =await obj.GetTaxList(ReqPara);

                    Response = ResponceResult.SuccessResponseList(result);
                }
                else
                {
                    Response = ResponceResult.ErrorResponseList("No record found..!");
                }
            }
            catch (Exception ex)
            {
                Response = ResponceResult.ErrorResponseList(ex.Message.ToString());
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Company.GetTaxList, 0);
            }
            return Response;
        }

        [HttpPost]
        [Route(APIRoute.Company.EditTax)]
        public async Task<Responce> EditTax(reqEditTax ReqPara)
        {
            Responce Response = new Responce();
            try
            {
                if (ReqPara != null)
                {
                    string result = obj.EditTax(ReqPara);
                    if (result == "success")
                    {
                        Response = ResponceResult.SuccessResponse(result);
                    }

                    else
                    {
                        Response = ResponceResult.ValidateResponse(result);
                    }
                }
                else
                {
                    Response = ResponceResult.ErrorResponse("Record Not Save..!");
                }
            }
            catch (System.Exception ex)
            {
                Response = ResponceResult.ErrorResponse(ex.Message.ToString());
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Company.EditTax, 0);
            }
            return Response;
        }
    }
}
