
using MediatR;
using Tarifas.Application.Common;

namespace Tarifas.Application.GetAll;

public record GetAllTarifaQuery() : IRequest<List<TarifaDto>>;