using DevFreela.Application.Commands.InsertProject;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.Validators
{
    public class ProjectValidator:AbstractValidator<InsertProjectCommand>
    {
        public ProjectValidator()
        {
            RuleFor(p => p.Title)
                .NotEmpty()
                    .WithMessage("Não pode ser vazio.")
                .MaximumLength(50)
                    .WithMessage("Tamanho máximo é 50 caracteres.");

            RuleFor(p => p.TotalCost)
                .GreaterThanOrEqualTo(1000)
                    .WithMessage("O projecto deve custar pelo menos R$1.000 reais.");
        }
    }
}
