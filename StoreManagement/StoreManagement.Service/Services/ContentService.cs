﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StoreManagement.Data.Entities;
using StoreManagement.Data.GeneralHelper;
using StoreManagement.Data.HelpersModel;
using StoreManagement.Data.Paging;
using StoreManagement.Service.Interfaces;

namespace StoreManagement.Service.Services
{
    public class ContentService : BaseService, IContentService
    {
        private const String ApiControllerName = "Contents";
        public ContentService(string webServiceAddress)
            : base(webServiceAddress)
        {

        }

        public Content GetContentsContentId(int contentId)
        {
            try
            {
                string url = string.Format("http://{0}/api/{1}/GetContentsContentId?contentId={2}", WebServiceAddress, ApiControllerName, contentId);
                return HttpRequestHelper.GetUrlResult<Content>(url);
            }
            catch (Exception ex)
            {
                Logger.ErrorException("Error:" + ex.Message, ex);
                return new Content();
            }
        }

        public List<Content> GetContentByType(string typeName)
        {
            try
            {
                string url = string.Format("http://{0}/api/{1}/GetContentByType?typeName={2}", WebServiceAddress, ApiControllerName, typeName);
                return HttpRequestHelper.GetUrlResults<Content>(url);
            }
            catch (Exception ex)
            {
                Logger.ErrorException("Error:" + ex.Message, ex);
                return new List<Content>();
            }
        }

        public List<Content> GetContentByType(int storeId, string typeName)
        {
            try
            {
                string url = string.Format("http://{0}/api/{1}/GetContentByType?storeId={2}&typeName={3}", WebServiceAddress, ApiControllerName, storeId, typeName);
                return HttpRequestHelper.GetUrlResults<Content>(url);
            }
            catch (Exception ex)
            {
                Logger.ErrorException("Error:" + ex.Message, ex);
                return new List<Content>();
            }
        }

        public Content GetContentByUrl(int storeId, string url)
        {
            try
            {
                string url2 = string.Format("http://{0}/api/{1}/GetContentByUrl?storeId={2}&url={3}", WebServiceAddress, ApiControllerName, storeId, url);
                return HttpRequestHelper.GetUrlResult<Content>(url2);
            }
            catch (Exception ex)
            {
                Logger.ErrorException("Error:" + ex.Message, ex);
                return new Content();
            }
        }

        public List<Content> GetContentByTypeAndCategoryId(int storeId, string typeName, int categoryId)
        {
            try
            {
                string url = string.Format("http://{0}/api/{1}/GetContentByTypeAndCategoryId?" +
                                           "storeId={2}" +
                                           "&typeName={3}&categoryId={4}",
                                           WebServiceAddress,
                                           ApiControllerName,
                                           storeId,
                                           typeName,
                                           categoryId);

                return HttpRequestHelper.GetUrlResults<Content>(url);
            }
            catch (Exception ex)
            {
                Logger.ErrorException("Error:" + ex.Message, ex);
                return new List<Content>();
            }
        }

        public List<Content> GetContentByTypeAndCategoryIdFromCache(int storeId, string typeName, int categoryId)
        {
            try
            {
                string url = string.Format("http://{0}/api/{1}/GetContentByTypeAndCategoryIdFromCache" +
                                           "?storeId={2}" +
                                           "&typeName={3}" +
                                           "&categoryId={4}", WebServiceAddress, ApiControllerName, storeId, typeName, categoryId);
                return HttpRequestHelper.GetUrlResults<Content>(url);
            }
            catch (Exception ex)
            {
                Logger.ErrorException("Error:" + ex.Message, ex);
                return new List<Content>();
            }
        }

        public StorePagedList<Content> GetContentsCategoryId(int storeId, int ? categoryId, string typeName, bool? isActive, int page, int pageSize)
        {
            try
            {
                string url = string.Format("http://{0}/api/{1}/GetContentsCategoryId?storeId={2}" +
                                           "&categoryId={3}" +
                                           "&typeName={4}" +
                                           "&isActive={5}&page={6}&pageSize={7}", WebServiceAddress, ApiControllerName, storeId, categoryId, typeName, isActive, page, pageSize);
                return HttpRequestHelper.GetUrlPagedResults<Content>(url);
            }
            catch (Exception ex)
            {
                Logger.ErrorException("Error:" + ex.Message, ex);
                return null;
            }
        }

        public Content GetContentWithFiles(int id)
        {
            try
            {
                string url = string.Format("http://{0}/api/{1}/GetContentWithFiles?id={2}", WebServiceAddress, ApiControllerName, id);
                
                return HttpRequestHelper.GetUrlResult<Content>(url);
            }
            catch (Exception ex)
            {
                Logger.ErrorException("Error:" + ex.Message, ex);
                return new Content();
            }
        }
    }
}
