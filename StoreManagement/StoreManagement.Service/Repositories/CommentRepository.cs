﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StoreManagement.Data.Entities;
using StoreManagement.Service.DbContext;
using StoreManagement.Service.Repositories.Interfaces;

namespace StoreManagement.Service.Repositories
{
    public class CommentRepository : BaseRepository<Comment, int>, ICommentRepository
    {
        public CommentRepository(IStoreContext dbContext) : base(dbContext)
        {

        }
    }
}