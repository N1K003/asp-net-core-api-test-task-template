using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AspNetCoreApiTestTemplate.Data.Queries;
using AspNetCoreApiTestTemplate.Data.ReadModels;
using MediatR;

namespace AspNetCoreApiTestTemplate.Data.QueryHandlers
{
    public class UsersQueryHandler : IRequestHandler<GetUserQuery, UserReadModel>,
        IRequestHandler<GetUsersQuery, IEnumerable<UserReadModel>>
    {
        public async Task<UserReadModel> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            var users = new DummyUsersCollection();
            var user = users.FirstOrDefault(x => x.Id == request.Id);

            if (user == null)
            {
                // TODO change for not found exception
                throw new NullReferenceException($"User with id {request.Id} not found");
            }

            return await Task.FromResult(user);
        }

        public async Task<IEnumerable<UserReadModel>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            var users = new DummyUsersCollection();
            // TODO add filter by ids
            return await Task.FromResult(users);
        }
    }
}