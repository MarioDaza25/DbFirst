using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
    public class DriverDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int? Age { get; set; }

}
}