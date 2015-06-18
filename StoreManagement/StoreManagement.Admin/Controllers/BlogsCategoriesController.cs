﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StoreManagement.Admin.Constants;

namespace StoreManagement.Admin.Controllers
{
    public class BlogsCategoriesController : CategoriesController
    {
        public BlogsCategoriesController() : base(StoreConstants.BlogsType)
        {

        }
        
    }
}