namespace ClubFitnessSolution.Models
{
    public class GroupNotification
    {
        public IEnumerable<string> Roles { get; set; } = new List<string>
            { "All", "Supervisor", "Administrator", "Manager", "Employee" };
    }
}
