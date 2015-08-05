﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using StoreManagement.Data.Entities;
using StoreManagement.Data.GeneralHelper;
using StoreManagement.Data.LiquidEngineHelpers;
using StoreManagement.Data.LiquidEntities;
using StoreManagement.Data.Paging;

namespace StoreManagement.Liquid.Helper
{
    public class PhotoGalleryHelper : BaseLiquidHelper
    {
        public static Dictionary<String, String> GetPhotoGalleryIndexPage(Task<PageDesign> pageDesignTask, Task<List<FileManager>> fileManagersTask)
        {
            Task.WaitAll(pageDesignTask, fileManagersTask);
            var pageDesign = pageDesignTask.Result;
            var fileManagers = fileManagersTask.Result;
            Logger.Trace("FileManagers :"+fileManagers.Count);

            var cats = new List<FileManagerLiquid>();
            foreach (var item in fileManagers)
            {
                cats.Add(new FileManagerLiquid(item, pageDesign));
            }

            object anonymousObject = new
            {
                items = from s in cats
                             select new
                             {
                                 Name= s.FileManager.OriginalFilename,
                                 s.ImageSource 
                             }
            };

            var indexPageOutput = LiquidEngineHelper.RenderPage(pageDesign.PageTemplate, anonymousObject);


            var dic = new Dictionary<String, String>();
            dic.Add("PageOutput", indexPageOutput);



            return dic;

        }

      
    }
}