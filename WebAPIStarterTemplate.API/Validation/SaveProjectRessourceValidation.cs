using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPIStarterTemplate.API.Ressources;

namespace WebAPIStarterTemplate.API.Validation
{
    public class SaveProjectRessourceValidation:AbstractValidator<SaveProjectRessource>
    {
        public SaveProjectRessourceValidation()
        {
            RuleFor(m => m.Name)
                .NotEmpty()
                .MaximumLength(50);

        }
    }
}
