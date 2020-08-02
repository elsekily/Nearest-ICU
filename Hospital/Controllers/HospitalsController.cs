using System.Threading.Tasks;
using AutoMapper;
using Hospital.Core;
using Hospital.Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.Controllers
{
    [Route("api/[controller]")]
    public class HospitalsController : Controller
    {
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;
        private readonly IHospitalRepository repository;
        private readonly UserManager<User> userManager;

        public HospitalsController(IMapper mapper, IUnitOfWork unitOfWork,
            IHospitalRepository repository, UserManager<User> userManager)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
            this.repository = repository;
            this.userManager = userManager;
        }
        [HttpGet("nearest")]
        public async Task<IActionResult> NearestHospital(double userLatitude, double userLongitude)
        {
            var hospital = await repository.GetNearestHospital(userLatitude, userLongitude);
            return Ok(hospital);
        }
    }
}
