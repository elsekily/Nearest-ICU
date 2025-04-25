using Hospital.Core;
using Hospital.Entities.Resources;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital.Data.Repositories
{
    public class HospitalRepository : IHospitalRepository
    {
        private readonly HospitalsDbContext context;
        public HospitalRepository(HospitalsDbContext context)
        {
            this.context = context; 
        }
        public async void Add(Entities.Models.Hospital hospital)
        {
            await context.Hospitals.AddAsync(hospital);
        }
        public Task<Entities.Models.Hospital> GetHospital(int id)
        {
            return context.Hospitals.Include(h => h.User).SingleOrDefaultAsync(h => h.Id == id);
        }

        public async Task<IEnumerable<Entities.Models.Hospital>> GetHospitals()
        {
            return await context.Hospitals.Include(h => h.User).ToListAsync();
        }
        public void Remove(Entities.Models.Hospital hospital)
        {
            context.Hospitals.Remove(hospital);
        }
        public HospitalDistanceResource GetNearestHospital(double userLatitude, double userLongitude)
        {
            return context.Hospitals
                .Select(x => new HospitalDistanceResource
                {
                    Name = x.Name,
                    Address = x.Address,
                    Longitude = x.Longitude,
                    Latitude = x.Latitude,
                    Distance = DbFunctions.Distance(userLatitude, userLongitude, x.Latitude, x.Longitude)
                })
                .OrderBy(d => d.Distance).FirstOrDefault(); 
        }
        
    }
}
