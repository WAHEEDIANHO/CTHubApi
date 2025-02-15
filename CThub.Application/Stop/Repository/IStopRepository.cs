using CThub.Application.Pagination;
using CThub.Domain.ValueObjects;

namespace CThub.Application.Stop.Repository;

public interface IStopRepository: IGenericRepository<Domain.Models.Stop, DbContext>
{
    Task<Domain.Models.Stop> GetStopByIdAsync(StopId id);
    Task<PaginationResult<Domain.Models.Stop>> GetStopsAsync(PaginationRequest paginationRequest);
    // Task CreateStopAsync(Domain.Models.Stop stop);
}