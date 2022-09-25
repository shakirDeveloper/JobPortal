using JobPortalDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortalBLL.Repository
{
    public class PersonalInformationRepo
    {
        fldbContext _fldbContext;
        public PersonalInformationRepo(fldbContext context) 
        {
            _fldbContext = context;
        }

        public PersonalInformation Add(PersonalInformation personalInformation)
        {
            var result = _fldbContext.PersonalInformations.Add(personalInformation);
            return personalInformation;
        }

        public IQueryable<PersonalInformation> GetAll() 
        {
            var result = _fldbContext.PersonalInformations;
            return result;
        }

        public void SaveChanges() 
        {
            _fldbContext.SaveChanges();
        }
    }
}
