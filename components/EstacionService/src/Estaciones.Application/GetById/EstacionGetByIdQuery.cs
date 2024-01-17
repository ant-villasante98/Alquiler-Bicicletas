using Estaciones.Application.Common;
using MediatR;

namespace Estaciones.Application.GetById;

public record EstacionGetByIdQuery(long Id) : IRequest<EstacionDto>;
