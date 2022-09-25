using System;
using System.Collections.Generic;

namespace JobPortalDAL.Models
{
    public partial class PersonalInformation
    {
        public PersonalInformation()
        {
            EducationalHistories = new HashSet<EducationalHistory>();
            EmploymentHistories = new HashSet<EmploymentHistory>();
        }

        public int PersonalInformationId { get; set; }
        public string Nic { get; set; } = null!;
        public string FullName { get; set; } = null!;
        public string? FatherName { get; set; }
        public string? ContactNumber { get; set; }
        public string? MobileNumber { get; set; }
        public string PermenantAddress { get; set; } = null!;
        public int ReligionId { get; set; }
        public int DomocileId { get; set; }
        public string CvPath { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual DomocileType Domocile { get; set; } = null!;
        public virtual ReligionType Religion { get; set; } = null!;
        public virtual ICollection<EducationalHistory> EducationalHistories { get; set; }
        public virtual ICollection<EmploymentHistory> EmploymentHistories { get; set; }
    }
}
