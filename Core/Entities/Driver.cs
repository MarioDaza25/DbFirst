namespace Core.Entities;

public partial class Driver
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public int? Age { get; set; }

    public int? Idteam { get; set; }

    public ICollection<Team> Teams {get;set;} = new HashSet<Team>();
    
    public ICollection<DriverTeam> DriverTeam {get;set;}

}
