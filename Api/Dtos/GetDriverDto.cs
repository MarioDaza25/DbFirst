using Core.Entities;

namespace Api.Dtos
{
    public class GetDriverDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int? Age { get; set; }

        public ICollection<TeamDto> Teams {get;set;}
    }
}