using RentACarApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RentACarApp.Repo
{
    public class BranchRepository: Repository<Branch>, IBranchRepository
    {
        public BranchRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
        }

        public ApplicationDbContext ApplicationDbContext
        {
            get { return Context as ApplicationDbContext; }
        }
    }
}