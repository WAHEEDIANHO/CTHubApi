using CThub.Application.Common.CQRS;

namespace CThub.Application.Stop.Commands.CreateStop;

public record CreateStopResult(Guid Id);
public record CreateStopCommand(
    string StopName
    ): ICommand<CreateStopResult>;