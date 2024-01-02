using Application.Common;
using MediatR;

namespace Application.GetAll;

public record EstacionesGetAllQuery() : IRequest<List<EstacionDto>>;
