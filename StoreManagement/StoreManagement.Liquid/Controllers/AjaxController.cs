﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StoreManagement.Data.Constants;
using StoreManagement.Data.GeneralHelper;
using StoreManagement.Data.RequestModel;

namespace StoreManagement.Liquid.Controllers
{
    public class AjaxController : BaseController
    {
        
        public ActionResult GetRelatedProducts(int categoryId)
        {
            var returnModel = new ProductDetailViewModel();
            returnModel.Store = Store;
            returnModel.Category = ProductCategoryService.GetProductCategory(categoryId);
            returnModel.RelatedProducts = ProductService.GetProductByTypeAndCategoryId(Store.Id, "product", categoryId).Take(5).ToList();
            String partialViewName = @"pProducts\pRelatedProducts";
            var html = this.RenderPartialToString(partialViewName, new ViewDataDictionary(returnModel));
            return Json(html, JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetProductCategories()
        {
            var categories = ProductCategoryService.GetProductCategoriesByStoreIdFromCache(Store.Id, StoreConstants.ProductType);
            String partialViewName = @"pProducts\pProductCategories";
            var html = this.RenderPartialToString(partialViewName, new ViewDataDictionary(categories));
            return Json(html, JsonRequestBehavior.AllowGet);
        }
	}
}