using FluentValidation;

namespace AspNetCoreApiTestTemplate.WebApi.Models.Request
{
    public record ByIdRequest
    {
        /// <summary>
        ///     Id of the requested entry
        /// </summary>
        /// <example>1</example>
        public int Id { get; init; }
    }

    public class ByIdRequestValidator : AbstractValidator<ByIdRequest> { }
}