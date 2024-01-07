
using MediatR;

namespace Tarifas.Application.Delete;

public record DeleteTarifaCommand(long Id) : IRequest;