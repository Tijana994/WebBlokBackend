﻿using RentACarApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RentACarApp.Repo
{
    public class PicRepository : Repository<Pic>, IPicRepository
    {
        public PicRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
        }

        public ApplicationDbContext ApplicationDbContext
        {
            get { return Context as ApplicationDbContext; }
        }

        
    }
}