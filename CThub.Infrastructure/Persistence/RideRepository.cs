using CThub.Application.Ride.Repository;
using CThub.Application.Stop.Repository;
using CThub.Domain.Models;
using CThub.Infrastructure.Data;
using GenericRepository;

namespace CThub.Infrastructure.Persistence;

public class RideRepository(AppDbContext context): GenericRepository<Ride, AppDbContext>(context), IRideRepository
{
    
}