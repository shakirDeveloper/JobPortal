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
    public class ModelUnitOfWork //: IModelUnitOfWork
    {      
        PersonalInformation _personalInformation;
        EmploymentHistory _employmentHistory;
        EducationalHistory _educationalHistory;
        DomocileType _domocileType;
        ReligionType _religionType;

        public ModelUnitOfWork() 
        {
           
        } 

        public PersonalInformation PersonalInfomation
        {
            get 
            {
                if (_personalInformation == null) {
                    _personalInformation = new PersonalInformation();
                }
                return _personalInformation;
            }
        }
        public EmploymentHistory EmploymentHistory
        {
            get
            {
                if (_employmentHistory == null)
                {
                    _employmentHistory = new EmploymentHistory();
                }
                return _employmentHistory;
            }
        }
        public EducationalHistory EducationalHistory
        {
            get
            {
                if (_educationalHistory == null)
                {
                    _educationalHistory = new EducationalHistory();
                }
                return _educationalHistory;
            }
        }
        public DomocileType DomocileType
        {
            get
            {
                if (_domocileType == null)
                {
                    _domocileType = new DomocileType();
                }
                return _domocileType;
            }
        }
        public ReligionType ReligionType
        {
            get
            {
                if (_religionType == null)
                {
                    _religionType = new ReligionType();
                }
                return _religionType;
            }
        }
        
    }
}
