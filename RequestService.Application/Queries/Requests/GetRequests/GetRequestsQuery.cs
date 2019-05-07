using System.Collections.Generic;
using MediatR;
using RequestService.Domain.Requests;

namespace RequestService.Application.Queries.Requests.GetRequests
{
    public class GetRequestsQuery : IRequest<List<RequestPreviewDto>> { }
}