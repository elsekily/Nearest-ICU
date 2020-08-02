using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Hospital.Core;
using Hospital.Data;
using Hospital.Entities.Models;
using Hospital.Entities.Resources;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Hospital.Controllers
{
    [Route("api/[controller]")]
    public class HospitalsController : Controller
    {
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;
        private readonly IHospitalRepository repository;
        private readonly UserManager<User> userManager;
        private readonly HospitalsDbContext context;

        public HospitalsController(IMapper mapper, IUnitOfWork unitOfWork,
            IHospitalRepository repository, UserManager<User> userManager, HospitalsDbContext context)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
            this.repository = repository;
            this.userManager = userManager;
            this.context = context;
        }
        [HttpGet("nearest")]
        public IActionResult NearestHospital(double userLatitude, double userLongitude)
        {
            var hospital = repository.GetNearestHospital(userLatitude, userLongitude);
            return Ok(hospital);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetHospital(int id)
        {
            var hospital = await repository.GetHospital(id);
            return Ok(hospital);
        }
    }
}
