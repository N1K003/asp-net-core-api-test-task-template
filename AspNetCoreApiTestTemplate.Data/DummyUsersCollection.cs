using System.Collections;
using System.Collections.Generic;
using AspNetCoreApiTestTemplate.Data.ReadModels;

namespace AspNetCoreApiTestTemplate.Data
{
    public class DummyUsersCollection : IEnumerable<UserReadModel>
    {
        private static readonly IEnumerable<UserReadModel> Users = new List<UserReadModel>
        {
            new(1, "John", "Smith", 19900530),
            new(2, "Charles", "Johnson", 19960720),
            new(3, "Frank", "Williams", 19930917),
            new(4, "Mary", "Brown", 19870722),
            new(5, "Anna", "Jones", 19900812),
            new(6, "Michael", "Miller", 19921116),
            new(7, "Helen", "Davis", 19930921),
            new(8, "Daniel", "Lopez", 19940211),
            new(9, "Elizabeth", "Lee", 19910124),
            new(10, "Olivia", "Clark", 20110801)
        };

        public IEnumerator<UserReadModel> GetEnumerator()
        {
            return Users.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return Users.GetEnumerator();
        }
    }
}