namespace Application.Application.Managers.Commands.Update
{
    using FluentValidation;

    public class UpdateManagerCommandValidator : AbstractValidator<UpdateManagerCommand>
    {
        public UpdateManagerCommandValidator()
        {        
            RuleFor(c => c.Id)
                .NotEmpty();   

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
