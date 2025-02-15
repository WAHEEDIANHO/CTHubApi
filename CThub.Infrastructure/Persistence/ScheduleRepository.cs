using CThub.Application.Extensions;
using CThub.Application.Pagination;
using CThub.Application.Scheduler.Dtos;
using CThub.Application.Scheduler.Repository;
using CThub.Domain.Exceptions;
using CThub.Domain.Models;
using CThub.Infrastructure.Data;
using GenericRepository;
using Microsoft.EntityFrameworkCore;

namespace CThub.Infrastructure.Persistence;

public class ScheduleRepository(AppDbContext context): GenericRepository<Schedule, AppDbContext>(context), IScheduleRepository
{
    public Task AddRangeAsync(IEnumerable<Schedule> schedules)
    {
        context.Schedule.AddRangeAsync(schedules);
        return context.SaveChangesAsync();
    }

    public Task<Schedule?> GetByPath(string path)
    {
        return context.Schedule.FirstOrDefaultAsync(x => x.Path == path);
    }

    public async Task<PaginationResult<Schedule>> GetSchedulesAsync(PaginationRequest paginationRequest)
    {
        int pageIndex = paginationRequest.PageIndex;
        int pageSize = paginationRequest.PageSize;
        var totalCount = await context.Schedule.CountAsync();
        
        var skip = (pageIndex - 1) * pageSize;
        var result = await context.Schedule
            .Include(s => s.User)
            .Skip(skip)
            .Take(paginationRequest.PageSize)
            .ToListAsync();

        return new PaginationResult<Schedule>(pageIndex, pageSize, totalCount, result);
    }

    public  IEnumerable<Schedule> GetUserScheduleAsync(string riderId)
    {
        if (context.Users.Find(riderId) is not User user) throw new NotFoundException("User not found");
        
        var result =  context.Schedule
            .Include(s => s.User)
            .Where(x => x.User.Contains(user));
        return result;
    }

    public async Task<IEnumerable<Schedule>> GetAll(Dictionary<string, string>? fields)
    {
        return await context.Schedule.Include(s => s.User).ToListAsync();
    }
    
    
}