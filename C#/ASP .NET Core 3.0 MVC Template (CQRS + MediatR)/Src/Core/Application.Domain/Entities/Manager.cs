namespace Application.Domain.Entities
{
    using Common;
    using Enumerations;
    using ValueObjects;

    public class Manager : BaseDeletableModel<Manager>
    {        
        public virtual ManagerName ManagerName { get; set; }

        public WeekDay ReceptionDay { get; set; }
    }
}
