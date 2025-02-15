namespace CThub.Application.DriverQueueImpl.Repository;

public interface IDriverQueueRepository: IGenericRepository<DriverQueue, DbContext>
{
    Task<IEnumerable<DriverQueue>> GetAll(Dictionary<string, object>? fields);
    Task<int> Add(DriverQueue queue);

    Task<DriverQueue> GetByDriverId(string driverId);

}