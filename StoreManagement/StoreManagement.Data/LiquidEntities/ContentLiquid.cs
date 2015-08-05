﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using DotLiquid;
using StoreManagement.Data.Entities;
using StoreManagement.Data.GeneralHelper;

namespace StoreManagement.Data.LiquidEntities
{
    [LiquidType]
    public class ContentLiquid
    {
        public Content Content { get; set; }
        public Category Category { get; set; }
        public PageDesign PageDesign { get; set; }
        public ImageLiquid ImageLiquid { get; set; }
        private String Type { get; set; }
        public ContentLiquid(Content content, Category category, PageDesign pageDesign, String type)
        {
            this.Content = content;
            this.Category = category;
            this.PageDesign = pageDesign;
            List<FileManager> fileManagers = content.ContentFiles != null && content.ContentFiles.Any() ? content.ContentFiles.Select(r => r.FileManager).ToList() : new List<FileManager>();
            this.ImageLiquid = new ImageLiquid(fileManagers, pageDesign);
            this.Type = type;
        }


        public String DetailLink
        {
            get
            {
                return LinkHelper.GetContentLink(this.Content, Category.Name, this.Type);
            }
        }
        //int width = 60, int height = 60
        public String ImageSource
        {
            get
            {
                if (ImageHas)
                {
                    var firstOrDefault = this.Content.ContentFiles.FirstOrDefault();
                    return LinkHelper.GetImageLink("Thumbnail", firstOrDefault.FileManager.GoogleImageId, this.PageDesign.ImageWidth, this.PageDesign.ImageHeight);
                }
                else
                {

                    return "";
                }
            }
        }

        public bool ImageHas
        {
            get
            {
                return this.Content.ContentFiles.Any();
            }
        }
    }
}
