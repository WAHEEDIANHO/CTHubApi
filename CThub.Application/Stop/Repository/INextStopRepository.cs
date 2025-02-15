using CThub.Domain.Models;
using GenericRepository;
using Microsoft.EntityFrameworkCore;

namespace CThub.Application.Stop.Repository;

public interface INextStopRepository: IGenericRepository<NextStop, DbContext>
{
    
}