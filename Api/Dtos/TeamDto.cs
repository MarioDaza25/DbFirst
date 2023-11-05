using Api.Dtos;

namespace Core.Entities;

public  class TeamDto
{
    public int Id { get; set; }
    public string Name { get; set; }
}

public class GetTeamDto
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public ICollection<DriverDto> Drivers {get;set;} 

}

