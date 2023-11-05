using Core.Entities;
using Core.Interfaces;
using Domain.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;


namespace Application.Repository
{
    public class DriverRepository : GenericRepository<Driver>, IDriver
    {
        private readonly DbFirstContext _context;

        public DriverRepository(DbFirstContext context) : base(context)
        {
            _context = context;
        }
    public override async Task<Driver> GetByIdAsync(int id){
        return await _context.Drivers
                        .Include(p => p.Teams)
                        .FirstOrDefaultAsync(x => x.Id == id);
    }    

    public override async Task<IEnumerable<Driver>> GetAllAsync()
    {
        return await _context.Drivers
                        .Include(p => p.Teams)
                        .ToListAsync();
    }    
    public override async Task<(int totalRegistros, IEnumerable<Driver> registros)> GetAllAsync(int pageIndex, int pageSize, string search)
            {
                var query = _context.Drivers as IQueryable<Driver>;
    
                if(!string.IsNullOrEmpty(search))
                {
                    query = query.Where(p => p.Name.ToString() == search);
                }
    
                query = query.OrderBy(p => p.Name);
                var totalRegistros = await query.CountAsync();
                var registros = await query
                    .Skip((pageIndex - 1) * pageSize)
                    .Take(pageSize)
                    .ToListAsync();
    
                return (totalRegistros, registros);
            }

    }
}