﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StoreManagement.Data.Entities;
using StoreManagement.Service.IGeneralRepositories;

namespace StoreManagement.Service.ApiRepositories
{
    public class EmailListApiRepository : BaseApiRepository, IEmailListGeneralRepository
    {

        protected override string ApiControllerName { get { return "EmailLists"; } }


        public EmailListApiRepository(string webServiceAddress) : base(webServiceAddress)
        {

        }

        public List<EmailList> GetStoreEmailList(int storeId)
        {
            throw new NotImplementedException();
        }



        protected override void SetCache()
        {
            HttpRequestHelper.CacheMinute = CacheMinute;
            HttpRequestHelper.IsCacheEnable = IsCacheEnable;
        }
    }
}
