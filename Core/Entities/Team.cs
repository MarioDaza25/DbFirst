namespace Core.Entities;

public partial class Team
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;

    public ICollection<Driver> Drivers {get;set;} = new HashSet<Driver>();
    public ICollection<DriverTeam> DriverTeam {get;set;}

}
