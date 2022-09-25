using JobPortalDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.Interface
{
    public interface IEmployeeProfileService
    {
        PersonalInformationDto CreateEmployeeProfile(PersonalInformationDto personalInformationDto);
        List<PersonalInformationDto> GetAllEmployeeProfile();
    }
}
