using Domain.Models;
using Domain.Repositories;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository;

public class EstacionRepository : GenericRepository<Estacion, long>, IEstacionRepository
{
    private readonly BicicletasBdaContext _context;

    public EstacionRepository(BicicletasBdaContext context) : base(context)
    {
        _context = context;
    }
}
