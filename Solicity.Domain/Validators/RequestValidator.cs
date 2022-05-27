using FluentValidation;
using Solicity.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solicity.Domain.Validators
{
    public class RequestValidator : AbstractValidator<Request>
    {
        public RequestValidator()
        {
            RuleFor(c => c.Description).NotEmpty().NotNull();
            RuleFor(x => x.AuthorId).NotEmpty().NotNull();
            RuleFor(x => x.Title).NotEmpty().MaximumLength(50).NotNull();
            RuleFor(x => x.RequestTypeId).NotEmpty().NotNull();
            RuleFor(x => x.TeamId).NotEmpty().NotNull();
            RuleFor(x => x).NotEmpty().NotNull();
        }
    }
}
