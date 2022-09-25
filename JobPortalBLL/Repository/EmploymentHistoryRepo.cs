using JobPortalDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortalBLL.Repository
{
    public class EmploymentHistoryRepo
    {
        fldbContext _fldbContext;
        public EmploymentHistoryRepo(fldbContext context)
        {
            _fldbContext = context;
        }

        public EmploymentHistory Add(EmploymentHistory employmenthistory)
        {
            var result = _fldbContext.EmploymentHistories.Add(employmenthistory);
            return employmenthistory;
        }

        public IQueryable<EmploymentHistory> GetAll()
        {
            var result = _fldbContext.EmploymentHistories;
            return result;
        }

        public void SaveChanges()
        {
            _fldbContext.SaveChanges();
        }
    }
}
