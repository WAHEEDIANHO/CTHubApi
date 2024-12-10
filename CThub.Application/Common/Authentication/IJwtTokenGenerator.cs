using User = CThub.Domain.Models.User;

namespace CThub.Application.Common.Authentication;

public interface IJwtTokenGenerator
{
    string GetToken(User user);
}