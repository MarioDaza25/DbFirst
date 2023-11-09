namespace Api.Dtos
{
    public class GetTeamDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public ICollection<DriverDto> Drivers {get;set;} 

    }
}