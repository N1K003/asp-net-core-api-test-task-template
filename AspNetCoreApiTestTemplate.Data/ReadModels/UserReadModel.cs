namespace AspNetCoreApiTestTemplate.Data.ReadModels
{
    public record UserReadModel
    {
        public UserReadModel(int id, string firstName, string lastName, long dateOfBirth)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
        }

        public int Id { get; }
        public string FirstName { get; }

        public string LastName { get; }

        // Format is: yyyyMMdd
        public long DateOfBirth { get; }
        // TODO Add user's age property
    }
}