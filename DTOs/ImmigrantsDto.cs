using API.entities;

namespace API.DTOs
{
    public class ImmigrantsDto : Person
    {
        public string Nationality { get; set; }
        public string BirthDate { get; set; }
        public string Vulnerability { get; set; }
        public string LocalId { get; set; }
    }
}
