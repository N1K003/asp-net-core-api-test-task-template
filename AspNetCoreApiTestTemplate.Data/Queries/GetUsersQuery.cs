using System.Collections.Generic;
using AspNetCoreApiTestTemplate.Data.ReadModels;
using MediatR;

namespace AspNetCoreApiTestTemplate.Data.Queries
{
    public record GetUsersQuery : IRequest<IEnumerable<UserReadModel>>
    {
        public GetUsersQuery(ICollection<int> userIdsFilter)
        {
            UserIdsFilter = userIdsFilter;
        }

        public ICollection<int> UserIdsFilter { get; }
    }
}