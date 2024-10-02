using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text.Json;
using System.Web;
using WMSWebAPI.Models.V1.Request;


namespace WMSWebAPI.Utility.V1
{
    public class ProductUtility
    {
        SqlParameter[] param;
        DBActivity obj;
        public ProductUtility()
        {
            obj = new DBActivity();
        }
        public async Task<JsonElement> ProductList(GetProductListRequest req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@CurrentPage", Int64.Parse(req.CurrentPage)),
                        new SqlParameter("@RecordLimit", Int64.Parse(req.RecordLimit)),
                        new SqlParameter("@CompanyId", Int64.Parse(req.CompanyId)),
                        new SqlParameter("@UserId", Int64.Parse(req.UserId)),
                        new SqlParameter("@CustomerId", Int64.Parse(req.CustomerId)),
                        new SqlParameter("@Search", req.Search),
                        new SqlParameter("@Filter", req.Filter)
                    };
            return await obj.ConvertDataSetToJObject(obj.Return_DataSet("ProductList", param));
        }
        public async Task<JsonElement> EditProduct(EditProductRequest req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@UserId", Int64.Parse(req.UserId)),
                        new SqlParameter("@ProductId", Int64.Parse(req.ProductId))
                    };

            return await obj.ConvertDataSetToJObject(obj.Return_DataSet("editproduct", param));
        }
        public string AddProduct(AddProductRequest req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@CompanyId", Int64.Parse(req.CompanyId)),
                        new SqlParameter("@UserId", Int64.Parse(req.UserId)),
                        new SqlParameter("@CustomerId", Int64.Parse(req.CustomerId)),
                        new SqlParameter("@SkuId", Int64.Parse(req.SkuId)),
                        new SqlParameter("@CategoryId", Int64.Parse(req.CategoryId)),
                        new SqlParameter("@SubcategoryId", Int64.Parse(req.SubcategoryId)),
                        new SqlParameter("@PrinciplePrice", Int64.Parse(req.PrinciplePrice)),
                        new SqlParameter("@SkuCode", req.SkuCode),
                        new SqlParameter("@AliasSkuCode", req.AliasSkuCode),
                        new SqlParameter("@GroupSet", req.GroupSet),
                        new SqlParameter("@PickingMethod", req.PickingMethod),
                        new SqlParameter("@PickingfamilyGroup", Int64.Parse(req.PickingfamilyGroup)),
                        new SqlParameter("@SkuName", req.SkuName),
                        new SqlParameter("@Description", req.Description),
                        new SqlParameter("@Active", req.Active),
                        new SqlParameter("@UpcBarcode", req.UpcBarcode),
                        new SqlParameter("@MinReplenishQty", req.MinReplenishQty),
                        new SqlParameter("@MaxReplenishQty", req.MaxReplenishQty),
                        new SqlParameter("@MinOrderQty", req.MinOrderQty),
                        new SqlParameter("@WarehouseID",req.WarehouseID)
                    };
            return obj.Return_ScalerValue("AddProduct", param);
        }
        public async Task<JsonElement> CategoryList(GetCategoryListRequest req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@CompanyId", Int64.Parse(req.CompanyId)),
                        new SqlParameter("@UserId", Int64.Parse(req.UserId)),
                        new SqlParameter("@CustomerId", Int64.Parse(req.CustomerId)),
                    };
            return await obj.ConvertDataSetToJObject(obj.Return_DataSet("CategoryList", param));
        }
        public string AddCategory(AddCategoryRequest req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@CompanyId", Int64.Parse(req.CompanyId)),
                        new SqlParameter("@UserId", Int64.Parse(req.UserId)),
                        new SqlParameter("@CustomerId", Int64.Parse(req.CustomerId)),
                        new SqlParameter("@CategoryId", Int64.Parse(req.CategoryId)),
                        new SqlParameter("@Name", req.Name),
                        new SqlParameter("@Active", req.Active)
                    };
            return obj.Return_ScalerValue("AddCategory", param);
        }
        public async Task<JsonElement> SubCategoryList(GetSubCategoryListRequest req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@CompanyId", Int64.Parse(req.CompanyId)),
                        new SqlParameter("@UserId", Int64.Parse(req.UserId)),
                        new SqlParameter("@CustomerId", Int64.Parse(req.CustomerId)),
                        new SqlParameter("@SkuCategoryId", Int64.Parse(req.SkuCategoryId)),
                    };
            return await obj.ConvertDataSetToJObject(obj.Return_DataSet("SubCategoryList", param));
        }
        public string AddSubCategory(AddSubCategoryRequest req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@CompanyId", Int64.Parse(req.CompanyId)),
                        new SqlParameter("@UserId", Int64.Parse(req.UserId)),
                        new SqlParameter("@CustomerId", Int64.Parse(req.CustomerId)),
                        new SqlParameter("@SkuCategoryId", Int64.Parse(req.SkuCategoryId)),
                        new SqlParameter("@SkuSubCategoryId", Int64.Parse(req.SkuSubCategoryId)),
                        new SqlParameter("@Name", req.Name),
                        new SqlParameter("@Active", req.Active)
                    };
            return obj.Return_ScalerValue("AddSubCategory", param);
        }
        public async Task<JsonElement> ImageList(GetImageListRequest req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@UserId", Int64.Parse(req.UserId)),
                        new SqlParameter("@SkuId", Int64.Parse(req.SkuId))
                    };
            return await obj.ConvertDataSetToJObject(obj.Return_DataSet("ImageList", param));
        }
        public string AddImage(AddImageRequest req)
        {
            param = new SqlParameter[]
                    {

                        new SqlParameter("@UserId", Int64.Parse(req.UserId)),
                        new SqlParameter("@SkuId", Int64.Parse(req.SkuID)),
                        new SqlParameter("@ImageId", Int64.Parse(req.ImageId)),
                        new SqlParameter("@ImageTitle", req.ImageTitle),
                        new SqlParameter("@Description", req.Description),
                        new SqlParameter("@Attachment", req.Attachment),
                        new SqlParameter("@Path", req.Path)
                    };
            return obj.Return_ScalerValue("AddImage", param);
        }
        public string UploadImage(UploadImageRequest req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@CustomerId", Int64.Parse(req.CustomerId)),
                        new SqlParameter("@UserId", Int64.Parse(req.UserId)),
                        new SqlParameter("@SkuId",Int64.Parse(req.SkuID)),
                        new SqlParameter("@File",req.fileloc),
                        new SqlParameter("@ImgDownload",req.ImageDownload),
                        new SqlParameter("@objectName",req.ObjectName)

                    };
            return obj.Return_ScalerValue("Sp_UploadImage", param);
        }
        public string RemoveImage(RemoveImageRequest req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@UserId", Int64.Parse(req.UserId)),
                        new SqlParameter("@ImageId", Int64.Parse(req.ImageId)),
                    };
            return obj.Return_ScalerValue("RemoveImage", param);
        }
        public async Task<JsonElement> UomList(GetUomListRequest req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@UserId", Int64.Parse(req.UserId)),
                        new SqlParameter("@SkuId", Int64.Parse(req.SkuID))
                    };
            return await obj.ConvertDataSetToJObject(obj.Return_DataSet("UomList", param));
        }
        public string AddUom(AddUomRequest req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@UserId", Int64.Parse(req.UserId)),
                        new SqlParameter("@UomId", Int64.Parse(req.UomId)),
                        new SqlParameter("@Description", req.Description),
                        new SqlParameter("@Quantity", Int64.Parse(req.Quantity)),
                        new SqlParameter("@SkuId", Int64.Parse(req.SkuID)),
                    };
            return obj.Return_ScalerValue("AddUom", param);
        }
        public async Task<JsonElement> LottableList(GetLottableListRequest req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@UserId", Int64.Parse(req.UserId)),
                        new SqlParameter("@SkuId", Int64.Parse(req.SkuID))
                    };
            return await obj.ConvertDataSetToJObject(obj.Return_DataSet("LottableList", param));
        }
        public string AddLottable(AddLottableRequest req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@UserId", Int64.Parse(req.UserId)),
                        new SqlParameter("@lottableType", req.lottableType),
                        new SqlParameter("@DataType", req.DataType),
                        new SqlParameter("@ToRange", Int64.Parse(req.ToRange)),
                        new SqlParameter("@FromRange", Int64.Parse(req.FromRange)),
                        new SqlParameter("@SkuId", Int64.Parse(req.SkuID)),
                        new SqlParameter("@Active", req.Active),
                        new SqlParameter("@Fixedlegnth", req.Fixedlegnth),
                        new SqlParameter("@IsPartOfInward", req.IsPartOfInward),
                        new SqlParameter("@IsPartOfOutward", req.IsPartOfOutward),
                        new SqlParameter("@IsUnique", req.IsUnique),
                        new SqlParameter("@CustomerID", req.CustomerID)

                    };
            return obj.Return_ScalerValue("AddLottable", param);
        }
        public string RemoveLottable(RemoveLottableRequest req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@UserId", Int64.Parse(req.UserId)),
                        new SqlParameter("@SkuId", Int64.Parse(req.SkuID)),
                        new SqlParameter("@LottableID", Int64.Parse(req.LottableID))
                    };
            return obj.Return_ScalerValue("RemoveLottable", param);
        }
        public string RemoveUom(RemoveUomRequest req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@UserId", Int64.Parse(req.UserId)),
                        new SqlParameter("@SkuId", Int64.Parse(req.SkuID))
                    };
            return obj.Return_ScalerValue("RemoveUom", param);
        }
        public async Task<JsonElement> packingfamilyddl(GetpackingfamilyddlRequest req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@UserId", Int64.Parse(req.UserId))
                    };
            return await obj.ConvertDataSetToJObject(obj.Return_DataSet("sp_packingfamilyddl", param));
        }
        public async Task<JsonElement> Uomddl(GetUomddlRequest req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@UserId", Int64.Parse(req.UserId))
                    };
            return await obj.ConvertDataSetToJObject(obj.Return_DataSet("sp_Uomddl", param));
        }
        public async Task<JsonElement> Lottableddl(GetLottableddlRequest req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@CompanyId", req.CompanyId),
                        new SqlParameter("@CustomerID", req.CustomerID),
                        new SqlParameter("@UserId", req.UserId)
                    };
            return await obj.ConvertDataSetToJObject(obj.Return_DataSet("sp_lottableddl", param));
        }

        public async Task<JsonElement> LotableDataType(LotableDataType req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@CustomerID", req.CustomerID),
                        new SqlParameter("@UserID", req.UserID),
                        new SqlParameter("@LotableType", req.LotableType)
                    };
            return await obj.ConvertDataSetToJObject(obj.Return_DataSet("lot_GetLottableDataType", param));
        }

        public async Task<JsonElement> ProductInventoryAssignList(ProductInventoryAssignListRequest req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@ProductId", Int64.Parse(req.ProductId)),
                        new SqlParameter("@WarehouseID", Int64.Parse(req.WarehouseId)),
                        new SqlParameter("@CustomerID", Int64.Parse(req.CustomerId)),
                        new SqlParameter("@CurrentPage", Int64.Parse(req.CurrentPage)),
                        new SqlParameter("@UserID", Int64.Parse(req.UserId)),
                    };
            return await obj.ConvertDataSetToJObject(obj.Return_DataSet("SP_ProductInventory", param));
        }
        public async Task<JsonElement> ProductLocationList(ProductLocationListRequest req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@WarehouseId", Int64.Parse(req.WarehouseId)),
                        new SqlParameter("@Type", req.Type),
                        new SqlParameter("@Filter", req.Filter)
                    };
            return await obj.ConvertDataSetToJObject(obj.Return_DataSet("Sp_ProductInventoryLocation", param));
        }

        public string AddSKULocation(AddSKULocationReq req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@SKUID", Int64.Parse(req.SKUID)),
                        new SqlParameter("@LocationID", req.LocationID),
                        new SqlParameter("@WarehouseID", Int64.Parse(req.WarehouseID)),
                        new SqlParameter("@CustomerID", Int64.Parse(req.CustomerID)),
                        new SqlParameter("@LocObject", req.LocObject)
                    };
            return obj.Return_ScalerValue("Inv_InsertSKULocation", param);
        }

        public string RemoveSKULoc(RemoveSKULocRequest req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@SKUID", Int64.Parse(req.SKUID)),
                        new SqlParameter("@LocationID", Int64.Parse(req.LocationID)),
                    };
            return obj.Return_ScalerValue("skuinv_RemoveSKUlocation", param);
        }

        // API CHANGES FOR BARCODE CONFIGURATION - 27 Nov 2023
        public async Task<JsonElement> SaveBarcodePrdConfig(SaveBarcodeRequest req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@CustomerID",Int64.Parse(req.CustomerID)),
                        new SqlParameter("@WarehouseID", Int64.Parse(req.WarehouseID)),
                        new SqlParameter("@UserID", Int64.Parse(req.UserID)),
                        new SqlParameter("@LabelSize",req.LabelSize),
                        new SqlParameter("@ISdelimated",req.ISdelimated),
                        new SqlParameter("@BarcodeType",req.BarcodeType),
                        new SqlParameter("@finalbarcodeConfig",req.finalbarcodeConfig),
                        new SqlParameter("@Lottable",req.Lottable),
                        new SqlParameter("@IsFrom",Int64.Parse(req.IsFrom)),
                        new SqlParameter("@IsTo",Int64.Parse(req.IsTo)),
                        new SqlParameter("@BarcodeFixLength",req.BarcodeFixLength),
                        new SqlParameter("@BarcodeSize",Int64.Parse(req.BarcodeSize)),
                        new SqlParameter("@separatedBy",req.separatedBy),
                        new SqlParameter("@SkuId", Int64.Parse(req.SkuId)),
                        new SqlParameter("@Prefix",req.Prefix),
                        new SqlParameter("@SerialPrefix",req.SerialPrefix),
                        new SqlParameter("@SerialPrefixPos",req.SerialPrefixPos)
                    };

            return await obj.ConvertDataSetToJObject(obj.Return_DataSet("SP_SaveBarcodeprdConfig", param));
        }
        public async Task<JsonElement> GetLottableSave(GetLottableSaveRequest req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@SkuID",Int64.Parse(req.SkuID)),
                        new SqlParameter("@WarehouseID", Int64.Parse(req.WarehouseID)),
                        new SqlParameter("@CustomerID",Int64.Parse(req.CustomerID)),
                        new SqlParameter("@UserID", Int64.Parse(req.UserID)),
                        new SqlParameter("@AddLottable",req.AddLottable),
                        new SqlParameter("@IsFrom", Int64.Parse(req.IsFrom)),
                        new SqlParameter("@IsTo", Int64.Parse(req.IsTo))
                    };
            return await obj.ConvertDataSetToJObject(obj.Return_DataSet("sp_GetLottableSave", param));
        }
        public async Task<JsonElement> GetLottableRemove(GetLottableRemoveRequest req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@SkuID",Int64.Parse(req.SkuID)),
                        new SqlParameter("@WarehouseID", Int64.Parse(req.WarehouseID)),
                        new SqlParameter("@CustomerID",Int64.Parse(req.CustomerID)),
                        new SqlParameter("@UserID", Int64.Parse(req.UserID)),
                        new SqlParameter("@Lottable",req.Lottable),
                        new SqlParameter("@IsFrom", Int64.Parse(req.IsFrom)),
                        new SqlParameter("@IsTo", Int64.Parse(req.IsTo))
                    };
            return await obj.ConvertDataSetToJObject(obj.Return_DataSet("sp_GetLottableRemove", param));
        }
        public async Task<JsonElement> GetLottableDropdown(GetLottableDropdownRequest req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@CustomerId",Int64.Parse(req.CustomerId)),
                        new SqlParameter("@WarehouseId", Int64.Parse(req.WarehouseId)),
                        new SqlParameter("@UserId", Int64.Parse(req.UserId)),
                        new SqlParameter("@SkuId", Int64.Parse(req.SkuId))
                    };
            return await obj.ConvertDataSetToJObject(obj.Return_DataSet("SP_LottableDropdown", param));
        }
        public async Task<JsonElement> GetLottablebarcode(GetLottablebarcodeRequest req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@SkuID",Int64.Parse(req.SkuID)),
                        new SqlParameter("@WarehouseID", Int64.Parse(req.WarehouseID)),
                        new SqlParameter("@CustomerID",Int64.Parse(req.CustomerID)),
                        new SqlParameter("@UserID", Int64.Parse(req.UserID)),
                    };
            return await obj.ConvertDataSetToJObject(obj.Return_DataSet("sp_GetLottablebarcode", param));
        }
        public async Task<JsonElement> GetPrdBarcodeConfig(GetPrdBarcodeConfigRequest req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@SkuID",Int64.Parse(req.SkuID)),
                        new SqlParameter("@WarehouseID", Int64.Parse(req.WarehouseID)),
                        new SqlParameter("@CustomerID",Int64.Parse(req.CustomerID)),
                        new SqlParameter("@UserID", Int64.Parse(req.UserID)),
                    };
            return await obj.ConvertDataSetToJObject(obj.Return_DataSet("sp_GetPrdBarcodeConfig", param));
        }
        // API CHANGES FOR BARCODE CONFIGURATION - 27 Nov 2023

        public async Task<JsonElement> CategoryList(BindCategory req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@CompanyId", Int64.Parse(req.CompanyId)),
                        new SqlParameter("@CustomerID", Int64.Parse(req.CustomerID)),
                        new SqlParameter("@WarehouseID", Int64.Parse(req.WarehouseID)),
                         new SqlParameter("@UserID", Int64.Parse(req.UserID))
                    };
            return await obj.ConvertDataSetToJObject(obj.Return_DataSet("Sp_BindCategory", param));
        }

        public async Task<JsonElement> GetPriceList(GetPriceList req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@CompanyId", Int64.Parse(req.CompanyId)),
                        new SqlParameter("@CustomerID", Int64.Parse(req.CustomerID)),
                        new SqlParameter("@WarehouseID", Int64.Parse(req.WarehouseID)),
                        new SqlParameter("@SkuId", Int64.Parse(req.SkuID)),
                         new SqlParameter("@UserID", Int64.Parse(req.UserID))
                    };
            return await obj.ConvertDataSetToJObject(obj.Return_DataSet("Sp_GetPriceList", param));
        }


        public string SavePrice(SavePrice req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@CompanyId", Int64.Parse(req.CompanyId)),
                        new SqlParameter("@CustomerId", Int64.Parse(req.CustomerID)),
                        new SqlParameter("@WarehouseID",req.WarehouseID),
                        new SqlParameter("@SkuId", Int64.Parse(req.SkuID)),
                        new SqlParameter("@CategoryId", Int64.Parse(req.CategoryValue)),
                        new SqlParameter("@RateValue", Int64.Parse(req.RateValue)),
                        new SqlParameter("@DiscountValue", Int64.Parse(req.DiscountValue)),
                         new SqlParameter("@UserID", Int64.Parse(req.UserID))
                    };
            return obj.Return_ScalerValue("SavePrice", param);
        }




        public async Task<JsonElement> GetGSTList(GetGSTList req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@CompanyId", Int64.Parse(req.CompanyId)),
                        new SqlParameter("@CustomerID", Int64.Parse(req.CustomerID)),
                        new SqlParameter("@WarehouseID", Int64.Parse(req.WarehouseID)),
                        new SqlParameter("@SkuId", Int64.Parse(req.SkuID)),
                         new SqlParameter("@UserID", Int64.Parse(req.UserID))
                    };
            return await obj.ConvertDataSetToJObject(obj.Return_DataSet("Sp_GetGSTList", param));
        }


        public string SaveGST(SaveGST req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@CompanyId", Int64.Parse(req.CompanyId)),
                        new SqlParameter("@CustomerId", Int64.Parse(req.CustomerID)),
                        new SqlParameter("@WarehouseID",req.WarehouseID),
                        new SqlParameter("@SkuId", Int64.Parse(req.SkuID)),
                       // new SqlParameter("@GSTName", Int64.Parse(req.GSTName)),
                               new SqlParameter("@GSTName", req.GSTName),
                        new SqlParameter("@Value",  req.Value ),
                        new SqlParameter("@Ramark", req.Remark),
                         new SqlParameter("@UserID", Int64.Parse(req.UserID))
                    };
            return obj.Return_ScalerValue("SaveGST", param);
        }
        public async Task<JsonElement> Getskucodelist(GetskucodelistRequest req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@CustomerID",Int64.Parse(req.CustomerID)),
                        new SqlParameter("@WarehouseID", Int64.Parse(req.WarehouseID)),
                        new SqlParameter("@CompanyID",Int64.Parse(req.CompanyID)),
                        new SqlParameter("@UserID", Int64.Parse(req.UserID)),
                        new SqlParameter("@skey", req.skey),
                    };
            return await obj.ConvertDataSetToJObject(obj.Return_DataSet("sp_SkuCodelist", param));
        }
        public string Getskusave(GetskusaveRequest req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@CustomerID",Int64.Parse(req.CustomerID)),
                        //new SqlParameter("@WarehouseID", Int64.Parse(req.WarehouseID)),
                        new SqlParameter("@CompanyID",Int64.Parse(req.CompanyID)),
                        new SqlParameter("@UserID", Int64.Parse(req.UserID)),
                        new SqlParameter("@MSkuId",Int64.Parse(req.MSkuId)),
                        new SqlParameter("@MUOM", Int64.Parse(req.MUOM)),
                        new SqlParameter("@SkuId",Int64.Parse(req.SkuId)),
                        new SqlParameter("@Qty ", Int64.Parse(req.Qty)),
                      //  new SqlParameter("@UOM",req.UOM),
                        new SqlParameter("@Remark",req.Remark),
                    };
            return obj.Return_ScalerValue("SP_SkuConversionlistSave", param);
        }
        public async Task<JsonElement> Getskubind(GetskubindRequest req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@CustomerID",Int64.Parse(req.CustomerID)),
                        new SqlParameter("@WarehouseID", Int64.Parse(req.WarehouseID)),
                        new SqlParameter("@CompanyID",Int64.Parse(req.CompanyID)),
                        new SqlParameter("@UserID", Int64.Parse(req.UserID)),
                        new SqlParameter("@ID", Int64.Parse(req.ID)),
                    };
            return await obj.ConvertDataSetToJObject(obj.Return_DataSet("SP_SkuCodeNamelist", param));
        }
        public string GetattributeSave(GetattributeSaveRequest req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@CustomerID",Int64.Parse(req.CustomerID)),
                        new SqlParameter("@WarehouseID", Int64.Parse(req.WarehouseID)),
                        new SqlParameter("@CompanyID",Int64.Parse(req.CompanyID)),
                        new SqlParameter("@UserID", Int64.Parse(req.UserID)),
                        new SqlParameter("@height",req.height),
                        new SqlParameter("@weight", req.weight),
                        new SqlParameter("@length",req.length),
                        new SqlParameter("@width", req.width),
                        new SqlParameter("@selflife",req.selflife),
                        new SqlParameter("@packmode",req.packmode),
                        new SqlParameter("@contorging",req.contorging),
                        new SqlParameter("@packsize", req.packsize),
                        new SqlParameter("@color",req.color),
                        new SqlParameter("@band",req.band),
                        new SqlParameter("@productId",Int64.Parse(req.productId))
                    };
            return obj.Return_ScalerValue("SP_SkuattributelistSave ", param);
        }
        public async Task<JsonElement> Getattributebind(GetattributebindRequest req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@CompanyId",Int64.Parse(req.CompanyId)),
                        new SqlParameter("@CustomerID", Int64.Parse(req.CustomerID)),
                        new SqlParameter("@WarehouseID",Int64.Parse(req.WarehouseID)),
                        new SqlParameter("@UserID", Int64.Parse(req.UserID)),
                        new SqlParameter("@ProductId", Int64.Parse(req.ProductId)),
                    };
            return await obj.ConvertDataSetToJObject(obj.Return_DataSet("Sp_GetattributeBind", param));
        }
        public async Task<JsonElement> GetUOMDropdown(GetUOMDropdownRequest req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@CustomerID",Int64.Parse(req.CustomerID)),
                        new SqlParameter("@CompanyID",Int64.Parse(req.CompanyID)),
                        new SqlParameter("@skuid",Int64.Parse(req.skuid))
                    };
            return await obj.ConvertDataSetToJObject(obj.Return_DataSet("sp_ProConvUOMlist", param));
        }
        public async Task<JsonElement> DispSkuConvDetail(DispSkuConvDetailRequest req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@orderid",Int64.Parse(req.orderid))
                    };
            return await obj.ConvertDataSetToJObject(obj.Return_DataSet("SP_DispSkuConvDetail", param));
        }
        public string RemoveskuConv(RemoveskuConvRequest req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@orderid",Int64.Parse(req.orderid))
                    };
            return obj.Return_ScalerValue("SP_RemoveskuConv", param);
        }
        public async Task<JsonElement> ddlGetGST(ddlGetGST req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@CompanyId", Int64.Parse(req.CompanyId)),
                        new SqlParameter("@CustomerID", Int64.Parse(req.CustomerID)),
                        new SqlParameter("@WarehouseID", Int64.Parse(req.WarehouseID))
                    };
            return await obj.ConvertDataSetToJObject(obj.Return_DataSet("Sp_ddlGetGSTList", param));
        }
        public string EditGST(EditGST req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@CompanyId", Int64.Parse(req.CompanyId)),
                        new SqlParameter("@CustomerId", Int64.Parse(req.CustomerID)),
                        new SqlParameter("@WarehouseID",req.WarehouseID),
                        new SqlParameter("@SkuId", Int64.Parse(req.SkuID)),
                        new SqlParameter("@GSTName", req.GSTName),
                        new SqlParameter("@Value", Int64.Parse(req.Value)),
                        new SqlParameter("@Ramark", req.Remark),
                        new SqlParameter("@UserID", Int64.Parse(req.UserID)),
                        new SqlParameter("@rowno", Int64.Parse(req.rowno))
                    };
            return obj.Return_ScalerValue("EditGST", param);
        }
    }
}
