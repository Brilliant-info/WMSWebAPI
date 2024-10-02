using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WMSWebAPI.Models.V1.Request
{
    public class GetUserTypeListRequest
    {

        public string CompanyId { get; set; }
        public string UserId { get; set; }

    }
    public class GetUserlistRequest
    {
        public string CurrentPage { get; set; }
        public string RecordLimit { get; set; }
        public string CustomerId { get; set; }
        public string UserId { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string Search { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string Filter { get; set; }
    }
    //saveUser
    public class SaveUserRequest
    {
        public string CompanyId { get; set; }
        public string UserId { get; set; }
        public string UserType { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmployeeNo { get; set; }
        public string EmailId { get; set; }
        public string MobileNo { get; set; }
        public string username { get; set; }
        public string Active { get; set; }
        public string CreatedBy { get; set; }
        public string ReportingTo { get; set; }

    }
    //Password
    public class NewUserPassRequest
    {
        public string UserId { get; set; }
        public string Username { get; set; }
        public string UId { get; set; }
        public string Email { get; set; }
        public string CompanyID { get; set; }
    }
    //Get Warehouse list
    public class WarehouseListRequest
    {
        public string CompanyId { get; set; }
        public string UserId { get; set; }
        public long CreatedBy { get; set; }
    }
    public class CustomerListRequest
    {
        public string CompanyId { get; set; }
        public string UserId { get; set; }
        public long CreatedBy { get; set; }

    }
    //Get Warehouse list
    public class AssginUserWarehouseRequest
    {
        public string UserId { get; set; }
        public string UID { get; set; }
        public string CompanyId { get; set; }
        public string WarehouseId { get; set; }
    }
    //Get Warehouse list
    public class RemoveUserWarehouseRequest
    {
        public string UserId { get; set; }
        public string WarehouseId { get; set; }
        public string CreatedBy { get; set; }

    }
    //Customer Assgin Code

    public class AssginUserCustomerRequest
    {
        public string UserId { get; set; }
        public string CreatedBy { get; set; }
        public string CustomerId { get; set; }
    }
    //Remove Customer list
    public class RemoveUserCustomerRequest
    {
        public string UserId { get; set; }
        public string CustomerId { get; set; }
        public string CreatedBy { get; set; }
    }

    public class lockunlockrequest
    {
        public string UserId { get; set; }
        public string lockunlock { get; set; }
    }

    #region user Client request classes
    public class ClientListRequest
    {
        public string UserId { get; set; }
        public string CompanyId { get; set; }
    }

    //For client list for particular user parameters are:
    public class ClientAssignListRequest
    {
        public string UserId { get; set; }
        public string CustomerID { get; set; }
    }

    //For assign client
    public class AssginUserClientRequest
    {
        public string UserId { get; set; }
        public string ClientId { get; set; }
        public string CreatedBy { get; set; }
        public string CustomerID { get; set; }
    }

    //For client remove:
    public class RemoveUserClientRequest
    {
        public string UserId { get; set; }
        public string ClientId { get; set; }
        public string CreatedBy { get; set; }

    }

    #endregion

    #region User Roles code start
    public class GetRoleList
    {
        public string CompanyID { get; set; }
        public string UserID { get; set; }
        public string CreatedBy { get; set; }
        public long CustomerID { get; set; }
    }

    public class GetRoleDetailsbyID
    {
        public string Roleid { get; set; }
        public string UserID { get; set; }
        public string CreatedBy { get; set; }
    }

    public class SaveUserRole
    {
        public string Roleid { get; set; }
        public string UserID { get; set; }
        public string CompanyID { get; set; }
        public string CreatedBy { get; set; }
        public string RoleDetailID { get; set; }
        public string MenuID { get; set; }
        public string Action { get; set; }
    }

    public class ChkUserpreRole
    {
        public string Roleid { get; set; }
        public string UserID { get; set; }
        public string CreatedBy { get; set; }
    }

    public class SelectAllRoleReq
    {
        public long Roleid { get; set; }
        public long UserID { get; set; }
        public long CompanyID { get; set; }
        public long CreatedBy { get; set; }
        public string Action { get; set; }
        public string Checkval { get; set; }
    }


    #endregion User Roles code end

    public class emailParaU
    {
        public string Email_host { get; set; }
        public string Email_password { get; set; }
        public string Email_port { get; set; }
        public string from { get; set; }
    }

    public class GetUserreportingToRequest
    {
        public string CompanyId { get; set; }
        public string UserId { get; set; }
    }
}
