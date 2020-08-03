using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Hospital.Core;
using Hospital.Entities.Models;
using Hospital.Entities.Resources;
using Microsoft.AspNetCore.Authorization;
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
        public IActionResult NearestHospital(double userLatitude, double userLongitude)
        {
            var hospital = repository.GetNearestHospital(userLatitude, userLongitude);
            return Ok(hospital);
        }
        [Authorize(Policy = Policies.Moderator)]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetHospital(int id)
        {
            var hospital = await repository.GetHospital(id);
            var result = mapper.Map<Entities.Models.Hospital, HospitalResource>(hospital);
            return Ok(result);
        }
        [HttpGet]
        public async Task<IActionResult> GetHospitals(int id)
        {
            var hospitals = await repository.GetHospitals();
            var result = mapper.Map<IEnumerable<Entities.Models.Hospital>, 
                IEnumerable<HospitalResource>>(hospitals);
            return Ok(result);
        }
        [Authorize(Policy = Policies.Moderator)]
        [HttpPost]
        public async Task<IActionResult> CreateHospital([FromBody] HospitalSaveResource HospitalResource)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var hospital = mapper.Map<HospitalSaveResource, Entities.Models.Hospital>(HospitalResource);
            hospital.User = userManager.GetUserAsync(HttpContext.User).Result;
            
            repository.Add(hospital);
            await unitOfWork.CompleteAsync();

            hospital = await repository.GetHospital(hospital.Id);
            var result = mapper.Map<Entities.Models.Hospital, HospitalResource>(hospital);
            return Created(nameof(GetHospital), result);
        }
        [Authorize(Policy = Policies.Moderator)]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateHospital(int id, 
            [FromBody] HospitalSaveResource hospitalResource)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var hospital = await repository.GetHospital(id);

            var user = userManager.GetUserAsync(HttpContext.User);

            if (hospital.User.Id != user.Id || user.Id != 1)
                return Unauthorized();

            mapper.Map<HospitalSaveResource, Entities.Models.Hospital>(hospitalResource, hospital);

            await unitOfWork.CompleteAsync();

            hospital = await repository.GetHospital(hospital.Id);
            var result = mapper.Map<Entities.Models.Hospital, HospitalResource>(hospital);
            return Accepted(result);
        }
        [Authorize(Policy = Policies.Admin)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHospital(int id)
        {
            var hospital = await repository.GetHospital(id);

            if (hospital == null)
                return NotFound();

            repository.Remove(hospital);
            await unitOfWork.CompleteAsync();

            return Accepted();
        }
    }
}