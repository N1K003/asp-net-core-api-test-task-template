using System.Collections.Generic;
using System.Linq;
using FluentValidation;

namespace AspNetCoreApiTestTemplate.WebApi.Models.Request
{
    public record ByIdsRequest
    {
        /// <summary>
        ///     Set of integer ids
        /// </summary>
        /// <example>[1,2,3,4,5] OR null</example>
        public ICollection<int> Ids { get; init; }
    }

    public class ByIdsRequestValidator : AbstractValidator<ByIdsRequest>
    {
        public ByIdsRequestValidator()
        {
            When(x => x.Ids != null && x.Ids.Any(),
                () =>
                {
                    RuleForEach(x => x.Ids).GreaterThan(0);
                });
        }
    }
}