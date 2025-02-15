using CThub.Application.Pagination;
using CThub.Application.Scheduler.Dtos;

namespace CThub.Application.Scheduler.Repository;

public interface IScheduleRepository: IGenericRepository<Schedule, DbContext>
{
    public Task AddRangeAsync(IEnumerable<Schedule> schedules);   
    public Task<Schedule> GetByPath(string path);
    // public Task<IEnumerable<Schedule>> GetAll(Diction)
    
    Task<PaginationResult<Schedule>> GetSchedulesAsync(PaginationRequest paginationRequest);

    IEnumerable<Schedule> GetUserScheduleAsync(string riderId);

}