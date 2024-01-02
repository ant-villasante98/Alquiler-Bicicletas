
using MediatR;

namespace Application.Delete;

public record EstacionDeleteCommand(long Id) : IRequest;