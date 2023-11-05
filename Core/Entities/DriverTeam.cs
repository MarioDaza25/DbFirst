namespace Core.Entities
{
    public class DriverTeam
    {
        public int IdDriverFk { get; set; }
        public  Driver Driver{ get; set; }
        public int IdTeamFk { get; set; }
        public  Team Team{ get; set; }
    
    }
}