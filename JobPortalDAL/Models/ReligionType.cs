using System;
using System.Collections.Generic;

namespace JobPortalDAL.Models
{
    public partial class ReligionType
    {
        public ReligionType()
        {
            PersonalInformations = new HashSet<PersonalInformation>();
        }

        public int Id { get; set; }
        public string Description { get; set; } = null!;

        public virtual ICollection<PersonalInformation> PersonalInformations { get; set; }
    }
}
