﻿using FluentValidation;
using KokaarCis.Domain.Assemblers;

namespace KokaarCis.BusinessLogic.Commands.Contracts
{
    public class BusinessPartnerValidator : AbstractValidator<BusinessPartnerDto>
    {
        public BusinessPartnerValidator()
        {
            RuleFor(u => u.Name).NotNull().NotEmpty()
                .WithMessage("Le nom de l'apporteur d'affaire est obligatoire;\n");

            RuleFor(u => u.PhoneNumber).NotNull().NotEmpty()
                .WithMessage("Le numéro de téléphone est obligatoire;\n");
        }
    }
}
