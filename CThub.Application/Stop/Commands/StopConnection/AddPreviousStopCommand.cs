using CThub.Application.Common.CQRS;

namespace CThub.Application.Stop.Commands.StopConnection;

public record AddPreviousStopResult();

public record AddPreviousStopCommand(
        Guid StopId,
        Guid PreviousStopId
    ): ICommand<AddPreviousStopResult>;