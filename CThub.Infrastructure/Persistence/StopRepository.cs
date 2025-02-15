using CThub.Application.Pagination;
using CThub.Application.Stop.Repository;
using CThub.Domain.Models;
using CThub.Domain.ValueObjects;
using CThub.Infrastructure.Data;
using GenericRepository;
using Microsoft.EntityFrameworkCore;

namespace CThub.Infrastructure.Persistence;

public class StopRepository(AppDbContext _context): GenericRepository<Stop, AppDbContext>(_context), IStopRepository
{
    public async Task<Stop> GetStopByIdAsync(StopId id)
    {
        var resp = await _context.Stops
            .Include(s => s.NextStops)
            .Include(s => s.PrevStops)
            .AsNoTracking()
            .FirstAsync(s => s.Id == id);
        return resp;
    }

  

    public async Task<PaginationResult<Stop>> GetStopsAsync(PaginationRequest paginationRequest)
    {
        var pageIndex =  paginationRequest.PageIndex;
        var pageSize = paginationRequest.PageSize;

        var totalCount = await _context.Stops.LongCountAsync();
        var stops = await _context.Stops
            .Include(s => s.NextStops)
            .Include(s => s.PrevStops)
            .OrderBy(s => s.StopName)
            .Skip((pageIndex - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
        
        return new PaginationResult<Stop>(pageIndex, pageSize, totalCount, stops);

    }

    public async Task<IEnumerable<Stop>> GetAll(Dictionary<string, string>? fields)
    {
        var stops = await _context.Stops
            .Include(s => s.NextStops)
            .Include(s => s.PrevStops)
            .OrderBy(s => s.StopName)
            .ToListAsync();

        return stops;
    }
}