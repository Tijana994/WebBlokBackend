using RentACarApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RentACarApp.Repo
{
    public class UnitOfWork: IUnitOfWork
    {
        private readonly ApplicationDbContext applicationDbContext;

        public UnitOfWork(ApplicationDbContext context)
        {
            applicationDbContext = context;
            AppUsers = new AppUserRepository(context);
            Branches = new BranchRepository(context);
        }

        public IAppUserRepository AppUsers { get; private set; }
        public IBranchRepository Branches { get; private set; }

        public int Complete()
        {
            return applicationDbContext.SaveChanges();
        }

        public void Dispose()
        {
            applicationDbContext.Dispose();
        }
    }
}