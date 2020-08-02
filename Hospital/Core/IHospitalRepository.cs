using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hospital.Core
{
    public interface IHospitalRepository
    {
        Task<IEnumerable<Entities.Models.Hospital>> GetHospitals();
        Task<Entities.Models.Hospital> GetHospital(int id);
        void Add(Entities.Models.Hospital author);
        void Remove(Entities.Models.Hospital author);
    }
}
