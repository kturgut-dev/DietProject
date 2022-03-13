﻿using DietProject.Core.Entities;
using DietProject.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace DietProject.Core.DataAccess
{
    public class MessageOperations : BaseDataAccess<Message>
    {
        public MessageOperations(IDbContextFactory<DietProjectContext> blogContext) : base(blogContext) { }
    
    }
}
