using JobPortalDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortalBLL.Repository
{
    public class LookupRepo
    {
        fldbContext _fldbContext;
        public LookupRepo(fldbContext context)
        {
            _fldbContext = context;
        }
       
        public IQueryable<DomocileType> GetAllDomocile() 
        {
            var result = _fldbContext.DomocileTypes;
            return result;
        }
        public IQueryable<ReligionType> GetAllReligion()
        {
            var result = _fldbContext.ReligionTypes;
            return result;
        }
    }
}
