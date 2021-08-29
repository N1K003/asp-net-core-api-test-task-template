namespace AspNetCoreApiTestTemplate.WebApi.Models.Response
{
    public record UserResponse
    {
        /// <summary>
        ///     User's id
        /// </summary>
        /// <example>1</example>
        public int Id { get; init; }

        /// <summary>
        ///     User's first name
        /// </summary>
        /// <example>John</example>
        public string FistName { get; init; }

        /// <summary>
        ///     User's last nme
        /// </summary>
        /// <example>Smith</example>
        public string LastName { get; init; }

        /// <summary>
        ///     User's date of birth
        /// </summary>
        /// <example>1990-05-25</example>
        public string DateOfBirth { get; init; }

        /// <summary>
        ///     User's display name
        /// </summary>
        /// <example>Smith, John</example>
        public string DisplayName { get; init; }

        /// <summary>
        ///     User's age
        /// </summary>
        /// <example>31</example>
        public int Age { get; init; }
    }
}