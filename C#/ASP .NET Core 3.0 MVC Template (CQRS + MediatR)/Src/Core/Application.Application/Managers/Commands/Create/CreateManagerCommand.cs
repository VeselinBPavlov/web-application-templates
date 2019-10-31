namespace Application.Application.Managers.Commands.Create
{
    using MediatR;

    public class CreateManagerCommand : IRequest
    {
        public string ManagerFirstName { get; set; }

        public string ManagerLastName { get; set; }

        public string ReceptionDay { get; set; }
    }
}
