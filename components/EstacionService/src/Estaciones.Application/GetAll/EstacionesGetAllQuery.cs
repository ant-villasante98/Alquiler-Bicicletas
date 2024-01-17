using Estaciones.Application.Common;
using MediatR;

namespace Estaciones.Application.GetAll;

public record EstacionesGetAllQuery() : IRequest<List<EstacionDto>>;
