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
            Pics = new PicRepository(context);
            PriceLists = new PriceListRepository(context);
            Rates = new RateRepository(context);
            Reservations = new ReservationRepository(context);
            Services = new ServiceRepository(context);
            TypeOfVehicles = new TypeOfVehicleRepository(context);
            Vehicles = new VehicleRepository(context);
        }


        public IAppUserRepository AppUsers { get; private set; }
        public IBranchRepository Branches { get; private set; }
        public IPicRepository Pics { get; private set; }
        public IPriceListRepository PriceLists { get; private set; }
        public IRateRepository Rates { get; private set; }
        public IReservationRepository Reservations { get; private set; }
        public IServiceRepository Services { get; private set; }
        public ITypeOfVehicleRepository TypeOfVehicles { get; private set; }
        public IVehicleRepository Vehicles { get; private set; }

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