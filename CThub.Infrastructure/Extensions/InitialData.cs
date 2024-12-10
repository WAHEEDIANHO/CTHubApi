using CThub.Domain.Models;
using CThub.Domain.ValueObjects;

namespace CThub.Infrastructure.Extensions;

public class InitialData
{
    public static IEnumerable<User> Users => new List<User>
    {
        // User.CreateUser("waheed", "safiu", "asa65@gmail.com"),
        // User.CreateUser("rasheed", "safiu", "asa6@gmail.com"),
        User.CreateUser("tola", "samuel", "asa22@gmail.com"),
        User.CreateUser("tosin", "sade", "asdrivera@gmail.com", 
            Vehincle.Of("Toyota", "CS30", "2020", 3)),
    };
}