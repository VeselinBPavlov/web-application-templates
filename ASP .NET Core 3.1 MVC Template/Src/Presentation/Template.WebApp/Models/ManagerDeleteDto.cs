namespace Template.WebApp.Models
{
    using Application.Managers.Queries.GetManagerById;
    using Application.Managers.Commands.Delete;

    public class ManagerDeleteDto
    {
        public ManagerViewModel ManagerViewModel { get; set; }

        public DeleteManagerCommand DeleteManagerCommand { get; set; }
    }
}
