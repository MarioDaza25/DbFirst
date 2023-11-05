using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Data;
using Core.Entities;
using Core.Interfaces;

namespace Application.Repository
{
    public class TeamRepository : GenericRepository<Team>, ITeam
    {
        private readonly DbFirstContext _context;

        public TeamRepository(DbFirstContext context) : base(context)
        {
            _context = context;
        }
    public override async Task<Team> GetByIdAsync(int id){
        return await _context.Teams
                        .Include(p => p.Drivers)
                        .FirstOrDefaultAsync(x => x.Id == id);
    }    

    public override async Task<IEnumerable<Team>> GetAllAsync()
    {
        return await _context.Teams
                        .Include(p => p.Drivers)
                        .ToListAsync();
    }    

    public override async Task<(int totalRegistros, IEnumerable<Team> registros)> GetAllAsync(int pageIndex, int pageSize, string search)
            {
                var query = _context.Teams as IQueryable<Team>;
    
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