using JobPortal.Interface;
using JobPortalDAL.Models;
using JobPortalDTOs;

namespace JobPortalBLL.Service
{
    public class EmployeeProfileService : IEmployeeProfileService
    {
        UnitOfWork _unitOfWork;
        ModelUnitOfWork _modelUnitOfWork;
        //public EmployeeProfileService(UnitOfWork unitOfWork, ModelUnitOfWork modelUnitOfWork)
        public EmployeeProfileService()
        {
            _unitOfWork = new UnitOfWork();
            _modelUnitOfWork = new ModelUnitOfWork();
        }

        public PersonalInformationDto CreateEmployeeProfile(PersonalInformationDto personalInformationDto)
        {
            var personalInfo = _modelUnitOfWork.PersonalInfomation;

            personalInfo.Nic = personalInformationDto.nic;
            personalInfo.FullName = personalInformationDto.fullName;
            personalInfo.FatherName = personalInformationDto.fatherName;
            personalInfo.ContactNumber = personalInformationDto.contactNumber;
            personalInfo.MobileNumber = personalInformationDto.mobileNumber;
            personalInfo.CvPath = string.IsNullOrEmpty(personalInformationDto.cvpath) ? string.Empty : personalInformationDto.cvpath;
            personalInfo.PermenantAddress = personalInformationDto.address;
            personalInfo.DomocileId = personalInformationDto.domocileid;
            personalInfo.ReligionId = personalInformationDto.religionid;

            var newPersonalInformation = _unitOfWork.PersonalInforepo.Add(personalInfo);

            foreach (var emphistorydto in personalInformationDto.employmentHistories)
            {
                var empHistory = _modelUnitOfWork.EmploymentHistory;

                empHistory.PersonalInformation = personalInfo;
                empHistory.Organization = emphistorydto.organisationName;
                empHistory.Designation = emphistorydto.designation;
                empHistory.JoiningDate = Convert.ToDateTime(emphistorydto.joiningDate);
                empHistory.EndDate = Convert.ToDateTime(emphistorydto.endDate);
                empHistory.IsCurrentJob = emphistorydto.isCurrentJob.HasValue ? emphistorydto.isCurrentJob.Value : false;
                empHistory.LastSalary = emphistorydto.salary.HasValue ? emphistorydto.salary.Value : 0;

                _unitOfWork.EmploymentHistoryrepo.Add(empHistory);
            }

            foreach (var eduhistorydto in personalInformationDto.educationalHistories)
            {
                var eduHistory = _modelUnitOfWork.EducationalHistory;

                eduHistory.PersonalInformation = personalInfo;
                eduHistory.DegressTitle = eduhistorydto.degreeTitle;
                eduHistory.YearPassing = eduhistorydto.passingYear;
                eduHistory.Grade = String.IsNullOrEmpty(eduhistorydto.grade) ? String.Empty : eduhistorydto.grade;
                eduHistory.MajorSubject = eduhistorydto.majorSubject;

                _unitOfWork.EducationalHistoryrepo.Add(eduHistory);
            }
            _unitOfWork.Save();

            personalInformationDto.id = newPersonalInformation.PersonalInformationId;

            return personalInformationDto;
        }

        public List<PersonalInformationDto> GetAllEmployeeProfile()
        {
            var employeeProfiles = _unitOfWork.PersonalInforepo.GetAll().ToList();
            return PersonalInfoModelToDtoMapping(employeeProfiles);
        }
        private List<PersonalInformationDto> PersonalInfoModelToDtoMapping(List<PersonalInformation> personalInformations)
        {
            List<PersonalInformationDto> personalInformationDtos = new List<PersonalInformationDto>();
            foreach (var personalInformation in personalInformations)
            {
                personalInformationDtos.Add(new PersonalInformationDto
                {
                    id = personalInformation.PersonalInformationId,
                    fullName = personalInformation.FullName,
                    fatherName = personalInformation.FatherName,
                    nic = personalInformation.Nic,
                    contactNumber = personalInformation.ContactNumber,
                    mobileNumber = personalInformation.MobileNumber,
                    address = personalInformation.PermenantAddress,
                    religionid = personalInformation.ReligionId,
                    domocileid = personalInformation.DomocileId,
                    cvpath = personalInformation.CvPath,
                    educationalHistories = EducationalInfoModelToDtoMapping(personalInformation.EducationalHistories.ToList()).ToArray(),
                    employmentHistories = EmploymentInfoModelToDtoMapping(personalInformation.EmploymentHistories.ToList()).ToArray()
                });
            }
            return personalInformationDtos;
        }
        private List<EducationalHistoryDto> EducationalInfoModelToDtoMapping(List<EducationalHistory> educationalInformations)
        {
            List<EducationalHistoryDto> educationalInformationDtos = new List<EducationalHistoryDto>();
            foreach (var educationalInformation in educationalInformations)
            {
                educationalInformationDtos.Add(new EducationalHistoryDto
                {
                    degreeTitle = educationalInformation.DegressTitle,
                    grade = educationalInformation.Grade,
                    majorSubject = educationalInformation.MajorSubject,
                    passingYear = educationalInformation.YearPassing

                });
            }
            return educationalInformationDtos;
        }
        private List<EmploymentHistoryDto> EmploymentInfoModelToDtoMapping(List<EmploymentHistory> employmentInformations)
        {
            List<EmploymentHistoryDto> employmentInformationDtos = new List<EmploymentHistoryDto>();
            foreach (var employementInformation in employmentInformations)
            {
                employmentInformationDtos.Add(new EmploymentHistoryDto
                {
                    designation = employementInformation.Designation,
                    organisationName = employementInformation.Organization,
                    joiningDate = employementInformation.JoiningDate.ToShortDateString(),
                    endDate = employementInformation.EndDate?.ToShortDateString(),
                    isCurrentJob = employementInformation.IsCurrentJob,
                    salary = employementInformation.LastSalary
                });
            }
            return employmentInformationDtos;
        }
    }
}
