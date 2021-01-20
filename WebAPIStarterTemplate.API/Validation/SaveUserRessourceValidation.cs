using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPIStarterTemplate.API.Ressources;

namespace WebAPIStarterTemplate.API.Validation
{
    public class SaveUserResourceValidation : AbstractValidator<UserResource>
    {
        public SaveUserResourceValidation()
        {
            RuleFor(m => m.FirstName)
             .NotEmpty()
             .MaximumLength(50);
            RuleFor(m => m.LastName)
          .NotEmpty()
          .MaximumLength(50);
            RuleFor(m => m.Username)
      .NotEmpty()
      .MaximumLength(50);
            RuleFor(m => m.Password)
       .NotEmpty()
        .MaximumLength(50);
        }
    }
}
