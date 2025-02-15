namespace CThub.Application.Dtos;

public record StopDto(
        Guid Id,
        string StopName,
        List<StopRelation> PrevStops,
        List<StopRelation> NextStops
    );