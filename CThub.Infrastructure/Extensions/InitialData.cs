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
            Vehincle.Of("Toyota", Domain.Enums.Vehincle.CAR, "2020", 3)),
    };

    public static IEnumerable<Stop> Stops => new List<Stop>()
    {
        Stop.Create(StopId.Of(Guid.NewGuid()), StopName.Of("Main Gate")),
        Stop.Create(StopId.Of(Guid.NewGuid()), StopName.Of("Queen Hall")),
        Stop.Create(StopId.Of(Guid.NewGuid()), StopName.Of("BookShop")),
        Stop.Create(StopId.Of(Guid.NewGuid()), StopName.Of("Mosque")),
        Stop.Create(StopId.Of(Guid.NewGuid()), StopName.Of("Tedder")),
        Stop.Create(StopId.Of(Guid.NewGuid()), StopName.Of("Mellanby")),
        Stop.Create(StopId.Of(Guid.NewGuid()), StopName.Of("SUB")),
        Stop.Create(StopId.Of(Guid.NewGuid()), StopName.Of("Faculty of Science")),
        Stop.Create(StopId.Of(Guid.NewGuid()), StopName.Of("Faculty of Social Science")),
        Stop.Create(StopId.Of(Guid.NewGuid()), StopName.Of("Faculty of Technology")),
        Stop.Create(StopId.Of(Guid.NewGuid()), StopName.Of("Faculty of Art")),
        Stop.Create(StopId.Of(Guid.NewGuid()), StopName.Of("Faculty of Agriculture")),
        Stop.Create(StopId.Of(Guid.NewGuid()), StopName.Of("Veterinary")),
        Stop.Create(StopId.Of(Guid.NewGuid()), StopName.Of("UI Hotel")),
        Stop.Create(StopId.Of(Guid.NewGuid()), StopName.Of("Abadina")),
        Stop.Create(StopId.Of(Guid.NewGuid()), StopName.Of("Ajibode")),
        Stop.Create(StopId.Of(Guid.NewGuid()), StopName.Of("Access Bank")),
        Stop.Create(StopId.Of(Guid.NewGuid()), StopName.Of("Zik Hall")),
        Stop.Create(StopId.Of(Guid.NewGuid()), StopName.Of("Indy Hall")),
        Stop.Create(StopId.Of(Guid.NewGuid()), StopName.Of("Saint Annes")),
        Stop.Create(StopId.Of(Guid.NewGuid()), StopName.Of("ISI")),
        Stop.Create(StopId.Of(Guid.NewGuid()), StopName.Of("Idia Hall")),
        Stop.Create(StopId.Of(Guid.NewGuid()), StopName.Of("Awo Hall")),
        Stop.Create(StopId.Of(Guid.NewGuid()), StopName.Of("Private Hostel"))
    };

    public static IEnumerable<PrevStop> PrevStops => new List<PrevStop>()
    {
        // PrevStop.Create(
        //     Stop.Create(StopId.Of(new Guid("18e227cf-f84e-4586-b06b-7e9536c7db2d")), StopName.Of(("faculty of art"))),
        //     StopId.Of(new Guid("c53b0b67-15f9-425e-a22b-185803c158a8")), 
        //     StopName.Of("sub")
        //     ),
        // PrevStop.Create(
        //     Stop.Create(StopId.Of(new Guid("96a6cfa7-605e-43f7-bdd1-cb9248f9b8e5")), StopName.Of(("faculty of science"))),
        //     StopId.Of(new Guid("c53b0b67-15f9-425e-a22b-185803c158a8")), 
        //     StopName.Of("sub")
        // ),
        // PrevStop.Create(
        //     Stop.Create(StopId.Of(new Guid("d4be3819-93d1-4cc4-91ed-2315745077cb")), StopName.Of(("queen hall"))),
        //     StopId.Of(new Guid("e23d4115-75d7-43fe-8bd1-5e4d03854e5d")), 
        //     StopName.Of("main gate")
        // ),
       
       
        // PrevStop.Create(StopId.Of(new Guid("41ccbd77-2641-4e79-9d53-cf5f84a64893")),
        //     StopId.Of(new Guid("eaba4408-12f9-4199-9f15-1badd68a4c61"))),
    };
}



// var optionsBuilder = new DbContextOptionsBuilder<YourDbContext>();
// optionsBuilder.UseLoggerFactory(LoggerFactory.Create(builder => builder.AddConsole()));
// optionsBuilder.EnableSensitiveDataLogging();
