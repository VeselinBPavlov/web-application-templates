namespace Application.Application.Managers.Commands.Update
{
    using MediatR;

    public class UpdateManagerCommand : IRequest
    {
        public string Id { get; set; }

        public string ManagerFirstName { get; set; }

        public string ManagerLastName { get; set; }

        public string ReceptionDay { get; set; }
    }
}
