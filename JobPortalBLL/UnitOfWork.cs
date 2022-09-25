using JobPortal.Interface;
using JobPortalBLL.Repository;
using JobPortalDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortalBLL
{
    public class UnitOfWork //: IUnitOfWork
    {
        fldbContext fldbContext;
        PersonalInformationRepo _personalInformationRepo;
        EmploymentHistoryRepo _employmentHistoryRepo;
        EducationalHistoryRepo _educationalHistoryRepo;
        LookupRepo _lookupRepo;

        public UnitOfWork() 
        {
            fldbContext = new fldbContext();
        } 

        public PersonalInformationRepo PersonalInforepo 
        {
            get 
            {
                if (_personalInformationRepo == null) {
                    _personalInformationRepo = new PersonalInformationRepo(fldbContext);
                }
                return _personalInformationRepo;
            }
        }
        public EmploymentHistoryRepo EmploymentHistoryrepo
        {
            get
            {
                if (_employmentHistoryRepo == null)
                {
                    _employmentHistoryRepo = new EmploymentHistoryRepo(fldbContext);
                }
                return _employmentHistoryRepo;
            }
        }
        public EducationalHistoryRepo EducationalHistoryrepo
        {
            get
            {
                if (_educationalHistoryRepo == null)
                {
                    _educationalHistoryRepo = new EducationalHistoryRepo(fldbContext);
                }
                return _educationalHistoryRepo;
            }
        }
        public LookupRepo Lookuprepo
        {
            get
            {
                if (_lookupRepo == null)
                {
                    _lookupRepo = new LookupRepo(fldbContext);
                }
                return _lookupRepo;
            }
        }
        public void Save() 
        {
            fldbContext.SaveChanges();
        }
    }
}
