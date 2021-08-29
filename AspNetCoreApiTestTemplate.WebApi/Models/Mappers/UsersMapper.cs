using System;
using AspNetCoreApiTestTemplate.Data.ReadModels;
using AspNetCoreApiTestTemplate.WebApi.Infrastructure.Extensions;
using AspNetCoreApiTestTemplate.WebApi.Models.Response;

namespace AspNetCoreApiTestTemplate.WebApi.Models.Mappers
{
    public static class UsersMapper
    {
        public static UserResponse MapToResponse(this UserReadModel readModel)
        {
            if (readModel == null)
            {
                throw new ArgumentNullException(nameof(readModel));
            }

            return new UserResponse
            {
                Id = readModel.Id,
                FistName = readModel.FirstName,
                LastName = readModel.LastName,
                DisplayName = $"{readModel.LastName}, {readModel.FirstName}",
                DateOfBirth = readModel.DateOfBirth.ToDateOfBirthString(),
                Age = CalculateAge(readModel.DateOfBirth)
            };
        }

        private static int CalculateAge(long dateOfBirth)
        {
            // TODO calculate age
            return 0;
        }
    }
}