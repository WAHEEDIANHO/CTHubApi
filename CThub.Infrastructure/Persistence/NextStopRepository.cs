using CThub.Application.Stop.Repository;
using CThub.Domain.Models;
using CThub.Infrastructure.Data;
using GenericRepository;

namespace CThub.Infrastructure.Persistence;

public class NextStopRepository(AppDbContext _context): GenericRepository<NextStop, AppDbContext>(_context), INextStopRepository
{
    
}