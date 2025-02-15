using CThub.Application.Dtos;

namespace CThub.Application.Extensions;

public static class StopExtensions
{
     public static StopDto ToStopDto(this Domain.Models.Stop stop)
     {
         return DtoFromStop(stop);
     }

     public static IEnumerable<StopDto> ToStopDtos(this IEnumerable<Domain.Models.Stop> stops)
     {
         return stops.Select(s => DtoFromStop(s));
     }

     private static StopDto DtoFromStop(Domain.Models.Stop stop)
     {
         return new StopDto(
             Id: stop.Id.Value,
             StopName: stop.StopName.Value,
             PrevStops: stop.PrevStops.Select(s => new StopRelation(
                 s.PrevStopId.Value,
                 s.PrevStopName.Value
             )).ToList(),
             NextStops: stop.NextStops.Select(s => new StopRelation(
                 s.NextStopId.Value,
                 s.NextStopName.Value
             )).ToList()    
         );
     }
     
     
}