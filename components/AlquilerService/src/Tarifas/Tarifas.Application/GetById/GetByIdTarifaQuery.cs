
using MediatR;
using Tarifas.Application.Common;

namespace Tarifas.Application.GetById;

public record GetByIdTarifaQuery(long Id) : IRequest<TarifaDto>;