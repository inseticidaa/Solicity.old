using FluentValidation;
using Solicity.Domain.Entities;

namespace Solicity.Domain.Validators
{
    public class TeamValidator : AbstractValidator<Team>
    {
        public TeamValidator()
        {
            RuleFor(c => c.Name).NotEmpty().MaximumLength(50).NotNull();
            RuleFor(c => c.Description).MaximumLength(256);
            RuleFor(c => c.Public).NotEmpty().NotNull();
            RuleFor(c => c.CreatedAt).NotNull();
            RuleFor(c => c.UdpatedAt).NotNull();
            RuleFor(c => c.Enabled).NotNull();
        }
    }
}