using System;
using System.Collections.Generic;

namespace JobPortalDAL.Models
{
    public partial class EmploymentHistory
    {
        public int Id { get; set; }
        public int PersonalInformationId { get; set; }
        public string Organization { get; set; } = null!;
        public string Designation { get; set; } = null!;
        public DateTime JoiningDate { get; set; }
        public DateTime? EndDate { get; set; }
        public decimal? LastSalary { get; set; }
        public bool IsCurrentJob { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual PersonalInformation PersonalInformation { get; set; } = null!;
    }
}
