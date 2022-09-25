using JobPortalDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortalBLL.Repository
{
    public class EducationalHistoryRepo
    {
        fldbContext _fldbContext;
        public EducationalHistoryRepo(fldbContext context)
        {
            _fldbContext = context;
        }

        public EducationalHistory Add(EducationalHistory educationalHistory)
        {
            var result = _fldbContext.EducationalHistories.Add(educationalHistory);
            return educationalHistory;
        }

        public IQueryable<EducationalHistory> GetAll()
        {
            var result = _fldbContext.EducationalHistories;
            return result;
        }

        public void SaveChanges()
        {
            _fldbContext.SaveChanges();
        }
    }
}
