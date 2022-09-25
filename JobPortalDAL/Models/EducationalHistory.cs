using System;
using System.Collections.Generic;

namespace JobPortalDAL.Models
{
    public partial class EducationalHistory
    {
        public int Id { get; set; }
        public int PersonalInformationId { get; set; }
        public string DegressTitle { get; set; } = null!;
        public string YearPassing { get; set; } = null!;
        public string Grade { get; set; } = null!;
        public string MajorSubject { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual PersonalInformation PersonalInformation { get; set; } = null!;
    }
}
