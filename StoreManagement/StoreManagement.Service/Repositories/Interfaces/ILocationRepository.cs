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

    public interface ILocationRepository : IBaseRepository<Location, int>, ILocationGeneralRepository, IDisposable 
    {
        List<Location> GetLocationsByStoreId(int storeId, string search);
    }
}
