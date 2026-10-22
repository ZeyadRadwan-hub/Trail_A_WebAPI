namespace JobPortal.DTOs.Company
{
    public class CompanyInfoDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string Location { get; set; } = null!;
        public string? Website { get; set; }
    }
}
