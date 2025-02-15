using System.Linq.Expressions;
using CThub.Application.DriverQueueImpl.Repository;
using CThub.Domain.Models;
using CThub.Infrastructure.Data;
using GenericRepository;
using Microsoft.EntityFrameworkCore;

namespace CThub.Infrastructure.Persistence;

public class DriverQueueRepository(AppDbContext context): GenericRepository<DriverQueue, AppDbContext>(context), IDriverQueueRepository
{
    public async Task<IEnumerable<DriverQueue>> GetAll(Dictionary<string, object>? fields)
    {
        IQueryable<DriverQueue> source = context.Set<DriverQueue>().AsQueryable();
        if (fields == null)
            return (IEnumerable<DriverQueue>) await context.Set<DriverQueue>().ToListAsync<DriverQueue>();
        foreach (string key in fields.Keys)
        {
            string field = key;
            source = source.Where<DriverQueue>((Expression<Func<DriverQueue, bool>>) (x => EF.Property<string>(x, field) == fields[field]));
        }
        return (IEnumerable<DriverQueue>) await source.OrderBy(x => x.QueueTime).ToListAsync();
        // return resp.OrderByDescending(x => x.QueueTime);
    }

    public async Task<int> Add(DriverQueue entity)
    {
        await base.Add(entity);
        return await context.DriverQueues.CountAsync();
    }

    public async Task<DriverQueue> GetByDriverId(string driverId)
    {
        return await context.DriverQueues.FirstOrDefaultAsync(dqueue => dqueue.DriverId == driverId);
    }
}