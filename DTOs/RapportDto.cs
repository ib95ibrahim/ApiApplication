namespace API.DTOs
{
    public class RapportDto
    {
        public int RapportId { get; set; }
        public string RapportDate { get; set; }

        public int AdministratorId { get; set; }

        public int ServiceId { get; set; }
    }
}
