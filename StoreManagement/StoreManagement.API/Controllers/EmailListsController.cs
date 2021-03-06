﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using StoreManagement.Data.Constants;
using StoreManagement.Data.Entities;
using StoreManagement.Service.IGeneralRepositories;
using WebApi.OutputCache.V2;

namespace StoreManagement.API.Controllers
{
    [CacheOutput(ClientTimeSpan = StoreConstants.CacheClientTimeSpanSeconds, ServerTimeSpan = StoreConstants.CacheServerTimeSpanSeconds)]
    public class EmailListsController : BaseApiController<EmailList>, IEmailListGeneralRepository
    {
        public override IEnumerable<EmailList> GetAll()
        {
            throw new NotImplementedException();
        }

        public override EmailList Get(int id)
        {
            throw new NotImplementedException();
        }

        public override HttpResponseMessage Post(EmailList value)
        {
            throw new NotImplementedException();
        }

        public override HttpResponseMessage Put(int id, EmailList value)
        {
            throw new NotImplementedException();
        }

        public override HttpResponseMessage Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<EmailList> GetStoreEmailList(int storeId)
        {
            throw new NotImplementedException();
        }
    }
}
