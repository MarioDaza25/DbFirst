
using Application.Repository;
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;

namespace Application.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork,IDisposable
    {
        private readonly DbFirstContext _context;
        private DriverRepository _driver;
        private TeamRepository _team;




        public UnitOfWork(DbFirstContext context)
        {
            _context = context;
        }

        public IDriver Drivers 
        {
            get
            {
                if(_driver == null)
                {
                    _driver = new DriverRepository(_context);
                }
                return _driver;
            }
        }
        public ITeam Teams 
        {
            get
            {
                if(_team == null)
                {
                    _team = new TeamRepository(_context);
                }
                return _team;
            }
        }

        
        public void Dispose()
        {
            _context.Dispose();
        }

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }

        
    }
}