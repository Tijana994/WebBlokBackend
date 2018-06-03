using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACarApp.Repo
{
    public interface IUnitOfWork : IDisposable
    {
        IAppUserRepository AppUsers { get; }
        IBranchRepository Branches { get; }
        IPicRepository Pics { get; }
        IPriceListRepository PriceLists { get; }
        IRateRepository Rates { get; }
        IReservationRepository Reservations { get;  }
        IServiceRepository Services { get; }
        ITypeOfVehicleRepository TypeOfVehicles { get; }
        IVehicleRepository Vehicles { get; }
        int Complete();
    }
}
