using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACarApp.Repo
{
    public interface IUnitOfWork: IDisposable
    {
        IAppUserRepository AppUsers { get; }
        int Complete();
    }
}
