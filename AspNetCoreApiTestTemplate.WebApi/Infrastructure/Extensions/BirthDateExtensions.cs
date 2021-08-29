using System;

namespace AspNetCoreApiTestTemplate.WebApi.Infrastructure.Extensions
{
    public static class BirthDateExtensions
    {
        public static string ToDateOfBirthString(this long dateOfBirth)
        {
            // TODO convert to date of birth
            return DateTime.Today.ToString("yyyy-MM-dd");
        }
    }
}