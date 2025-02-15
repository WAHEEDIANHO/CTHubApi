using CThub.Application.Common.Resolver;
using CThub.Application.Pagination;
using CThub.Application.Stop.Repository;
using CThub.Domain.Models;
using CThub.Domain.ValueObjects;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;

namespace CThub.Infrastructure.Persistence.Cache;

public class CachedStopRepository(IStopRepository _stopRepository, IMemoryCache _memoryCache): IStopRepository //IDistributedCache _distributedCache
{
    
    public  Task<Stop> GetByKey(string id)
    {
        var key = $"key_{id}";
        // var cachedStop = await _distributedCache.GetStringAsync(key);
        // Stop? stop;
        // if (string.IsNullOrEmpty(cachedStop))
        // {
        //     stop = await _stopRepository.GetByKey(id);
        //     if (stop is null) return stop;
        //
        //     await _distributedCache.SetStringAsync(
        //         key,
        //         JsonConvert.SerializeObject(stop)
        //     );
        //
        //     return stop;
        // }
        //
        // stop = JsonConvert.DeserializeObject<Stop>(
        //     cachedStop,
        //     new JsonSerializerSettings
        //     {
        //         ConstructorHandling = ConstructorHandling.AllowNonPublicDefaultConstructor,
        //         ContractResolver = new PrivateResolver()
        //     }
        //     );
        // return stop;
        
        
        
        
        
        return _memoryCache.GetOrCreateAsync(
                key,
                entry =>
                {
                    entry.SetAbsoluteExpiration(TimeSpan.FromMinutes(5));
                    return _stopRepository.GetByKey(id);
                }
            )!;
        // return _stopRepository.GetByKey(id);
    }
 
    public Task<Stop> GetByKey(Guid id)
    {
        var key = $"stop_{id}";

        return _memoryCache.GetOrCreateAsync(
            key,
            entry =>
            {
                entry.SetAbsoluteExpiration(TimeSpan.FromMinutes(5));
                return _stopRepository.GetByKey(key);
            }
        )!;

        // var cachedStop = await _distributedCache.GetStringAsync(key);
        // Stop? stop;
        // if (string.IsNullOrEmpty(cachedStop))
        // {
        //     stop = await _stopRepository.GetByKey(id);
        //     if (stop is null) return stop;
        //
        //     await _distributedCache.SetStringAsync(
        //         key,
        //         JsonConvert.SerializeObject(stop)
        //     );
        //
        //
        //     return stop;
        // }
        //
        // stop = JsonConvert.DeserializeObject<Stop>(
        //     cachedStop,
        //     new JsonSerializerSettings
        //     {
        //         ConstructorHandling = ConstructorHandling.AllowNonPublicDefaultConstructor,
        //         ContractResolver = new PrivateResolver()
        //     }
        // );
        // return stop;
    }

    public Task<IEnumerable<Stop>> GetAll(Dictionary<string, string>? fields)
    {
        var key = "stops";
        // var cacchedStop = await _distributedCache.GetStringAsync(key);
        //
        // IEnumerable<Stop>? stops;
        // if (string.IsNullOrEmpty(cacchedStop))
        // {
        //    stops =  await _stopRepository.GetAll(fields);
        //    if(stops is null) return stops;
        //
        //    _distributedCache.SetStringAsync(
        //        key,
        //        JsonConvert.SerializeObject(stops)
        //    );
        //    return stops;
        // }
        //
        // stops = JsonConvert.DeserializeObject<IEnumerable<Stop>>(
        //     cacchedStop,
        //     new JsonSerializerSettings
        //     {
        //         ConstructorHandling = ConstructorHandling.AllowNonPublicDefaultConstructor,
        //         ContractResolver = new PrivateResolver()
        //     }
        // );
        // return stops;
       return _memoryCache.GetOrCreateAsync(key,
            entry =>
            {
                entry.SetAbsoluteExpiration(TimeSpan.FromMinutes(5));
                return _stopRepository.GetAll(fields);
            }
        )!;
    }

    public Task Add(Stop entity)
    {
        return _stopRepository.Add(entity);
    }

    public void Delete(Stop entity)
    {
        _stopRepository.Delete(entity);
    }

    public void Update(Stop entity)
    {
        _stopRepository.Update(entity);
    }

    public Task<Stop> GetStopByIdAsync(StopId id)
    {
        return _stopRepository.GetStopByIdAsync(id);
    }

    public Task<PaginationResult<Stop>> GetStopsAsync(PaginationRequest paginationRequest)
    {
        var key = $"stop_pagination_{paginationRequest.PageIndex}_{paginationRequest.PageSize}";
        // var cacchedStops = await _distributedCache.GetStringAsync(key);
        //
        // PaginationResult<Stop> stop;
        // if (string.IsNullOrEmpty(cacchedStops))
        // {
        //    stop = await _stopRepository.GetStopsAsync(paginationRequest);
        //    if (stop == null) return stop;
        //    
        //    _distributedCache.SetStringAsync(
        //         key,
        //         JsonConvert.SerializeObject(stop)
        //        );
        //    return stop;
        // }
        //
        // stop = JsonConvert.DeserializeObject<PaginationResult<Stop>>(
        //         cacchedStops,
        //         new JsonSerializerSettings
        //         {
        //             ConstructorHandling = ConstructorHandling.AllowNonPublicDefaultConstructor,
        //             ContractResolver = new PrivateResolver()
        //         }
        //     )!;
        //
        // return stop;
        
        return _memoryCache.GetOrCreateAsync(
            key,
            entry =>
            {
                entry.SetAbsoluteExpiration(TimeSpan.FromMinutes(5));
        
                return _stopRepository.GetStopsAsync(paginationRequest);
            }
        )!;
    }
}