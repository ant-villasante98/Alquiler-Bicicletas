using Application.Common;
using MediatR;

namespace Application.GetById;

public record EstacionGetByIdQuery(long Id) : IRequest<EstacionDto>;
