using RentACarApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace RentACarApp.Repo
{
    public class VehicleRepository: Repository<Vehicle>, IVehicleRepository
    {
        public VehicleRepository(DbContext applicationDbContext) : base(applicationDbContext)
        {
        }

        public ApplicationDbContext ApplicationDbContext
        {
            get { return Context as ApplicationDbContext; }
        }
    }
}