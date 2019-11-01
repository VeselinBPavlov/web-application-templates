namespace Template.WebApp.Models
{
    using Application.Managers.Commands.Update;
    using Application.Managers.Queries.GetManagerById;

    public class ManagerUpdateDto
    {
        public ManagerViewModel ManagerViewModel { get; set; }

        public UpdateManagerCommand UpdateManagerCommand { get; set; }
    }
}
