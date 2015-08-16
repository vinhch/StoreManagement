﻿using GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace StoreManagement.Data.Entities
{
          [Serializable]
    public class PageDesign : BaseEntity
    {
        public string Type { get; set; }
        [AllowHtml]
        public string PageTemplate { get; set; }
        public string Name { get; set; }
        public bool IsPagingUp { get; set; }
        public bool IsPagingDown { get; set; }

        public override string ToString()
        {
            return String.Format(
            "Id:{0} Type:{1} PageRazorTemplate:{2} StoreId:{3} ", Id, Type, PageTemplate, StoreId);
        }
    }

}
