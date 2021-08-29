using AspNetCoreApiTestTemplate.Data.ReadModels;
using MediatR;

namespace AspNetCoreApiTestTemplate.Data.Queries
{
    public record GetUserQuery : IRequest<UserReadModel>
    {
        public GetUserQuery(int id)
        {
            Id = id;
        }

        public int Id { get; }
    }
}