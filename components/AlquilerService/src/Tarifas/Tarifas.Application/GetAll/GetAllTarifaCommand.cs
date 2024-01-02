
using MediatR;
using Tarifas.Application.Common;

namespace Tarifas.Application.GetAll;

public record GetAllTarifaCommand() : IRequest<List<TarifaResponse>>;