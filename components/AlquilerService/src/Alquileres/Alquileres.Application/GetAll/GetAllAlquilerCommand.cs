
using Alquileres.Application.Common;
using MediatR;

namespace Alquileres.Application.GetAll;

public record GetAllAlquilerCommand : IRequest<List<AlquilerResponse>>;