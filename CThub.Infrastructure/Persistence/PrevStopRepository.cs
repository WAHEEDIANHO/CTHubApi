using CThub.Application.Stop.Repository;
using CThub.Domain.Models;
using CThub.Infrastructure.Data;
using GenericRepository;

namespace CThub.Infrastructure.Persistence;

public class PrevStopRepository(AppDbContext context): GenericRepository<PrevStop, AppDbContext>(context), IPrevStopRepository
{
    
}