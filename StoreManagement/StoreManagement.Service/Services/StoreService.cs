﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using StoreManagement.Data.Entities;
using StoreManagement.Data.GeneralHelper;
using StoreManagement.Service.Interfaces;

namespace StoreManagement.Service.Services
{
    public class StoreService : BaseService, IStoreService
    {
        private const String ApiControllerName = "Stores";
        public StoreService(string webServiceAddress) : base(webServiceAddress)
        {

        }

        public Store GetStoreByDomain(string domainName)
        {
            try
            {
                string url = string.Format("http://{0}/api/{1}/GetStoreByDomain?domainName={2}", WebServiceAddress, ApiControllerName, domainName);
                return RequestHelper.GetUrlResult<Store>(url);
            }
            catch (Exception ex)
            {
                Logger.ErrorException("Error:" + ex.Message, ex);
                return new Store();
            }
        }
        

        public Store GetStore(string domain)
        {
            try
            {
                string url = string.Format("http://{0}/api/{1}/GetStore?domain={2}", WebServiceAddress, ApiControllerName, domain);
                return RequestHelper.GetUrlResult<Store>(url);
            }
            catch (Exception ex)
            {
                Logger.ErrorException("Error:" + ex.Message, ex);
                return new Store();
            }
        }


        public Store GetSingle(int id)
        {
            try
            {
                string url = string.Format("http://{0}/api/{1}/GetSingle?id={2}", WebServiceAddress, ApiControllerName, id);
                return RequestHelper.GetUrlResult<Store>(url);
            }
            catch (Exception ex)
            {
                Logger.ErrorException("Error:" + ex.Message, ex);
                return new Store();
            }
        }
    }
}
