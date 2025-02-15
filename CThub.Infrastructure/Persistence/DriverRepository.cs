using CThub.Application.Authentication.Repository;
using CThub.Domain.Models;
using CThub.Infrastructure.Data;
using GenericRepository;

namespace CThub.Infrastructure.Persistence;

public class DriverRepository(AppDbContext context): GenericRepository<Driver, AppDbContext>(context), IDriverRepository
{
    
}