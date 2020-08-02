using Hospital.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital.Data.Repositories
{
    public class HospitalRepository : IHospitalRepository
    {
        public void Add(Entities.Models.Hospital author)
        {
            throw new NotImplementedException();
        }

        public Task<Entities.Models.Hospital> GetHospital(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Entities.Models.Hospital>> GetHospitals()
        {
            throw new NotImplementedException();
        }

        public void Remove(Entities.Models.Hospital author)
        {
            throw new NotImplementedException();
        }
    }
}
