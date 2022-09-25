namespace JobPortalDTOs
{
    public class PersonalInformationDto
    {
        public int id { get; set; }
        public string nic { get; set; }
        public string fullName { get; set; }
        public string fatherName { get; set; }
        public string? contactNumber { get; set; }
        public string mobileNumber { get; set; }
        public string address { get; set; }
        public int religionid { get; set; }
        public int domocileid { get; set; }
        public string cvpath { get; set; }
        public EmploymentHistoryDto[] employmentHistories { get; set; }
        public EducationalHistoryDto[] educationalHistories { get; set; }
    }
}