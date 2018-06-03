using RentACarApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace RentACarApp.Repo
{
    public class TypeOfVehicleRepository: Repository<TypeOfVehicle>, ITypeOfVehicleRepository
    {
        public TypeOfVehicleRepository(DbContext applicationDbContext) : base(applicationDbContext)
        {
        }

        public ApplicationDbContext ApplicationDbContext
        {
            get { return Context as ApplicationDbContext; }
        }
    }
}