namespace CThub.Contract.Stop;

public record AddPreviousStopRequest(
    Guid StopId,
    Guid PreviousStopId
    );