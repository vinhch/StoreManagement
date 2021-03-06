﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GenericRepository.EntityFramework;
using StoreManagement.Data.Entities;
using StoreManagement.Service.IGeneralRepositories;

namespace StoreManagement.Service.Repositories.Interfaces
{
    public interface IContentFileRepository : IBaseRepository<ContentFile, int>, IContentFileGeneralRepository, IDisposable 
    {
        List<ContentFile> GetContentFilesByContentId(int contentId);
        List<ContentFile> GetContentFilesByFileManagerId(int fileManagerId);
        void DeleteContentFileByContentId(int contentId);
        void SaveContentFiles(int[] selectedFileId, int contentId);
        void SetMainImage(int id, int fileId);

    }

}
