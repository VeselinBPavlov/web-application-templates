namespace Application.Application.Managers.Commands.Create
{
    using FluentValidation;

    public class CreateManagerCommandValidator : AbstractValidator<CreateManagerCommand>
    {        
        public CreateManagerCommandValidator()
        {            
            RuleFor(c => c.ManagerFirstName)
                .MaximumLength(50)
                .NotEmpty();

            RuleFor(c => c.ManagerFirstName)
                .MaximumLength(50)
                .NotEmpty();

            RuleFor(c => c.ReceptionDay)
                .NotEmpty();
        }
    }
}
