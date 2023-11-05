using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IUnitOfWork
    {
        public ITeam Teams {get;}
        public IDriver Drivers {get; }
        Task<int> SaveAsync();
    }
}