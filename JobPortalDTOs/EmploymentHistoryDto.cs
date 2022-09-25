namespace JobPortalDTOs
{
    public class EmploymentHistoryDto
    {
        public string organisationName { get; set; }
        public string designation { get; set; }
        public string joiningDate { get; set; }
        public string? endDate { get; set; }
        public decimal? salary { get; set; }
        public bool? isCurrentJob { get; set; }
    }
}