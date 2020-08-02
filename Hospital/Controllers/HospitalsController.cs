﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Hospital.Core;
using Hospital.Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.Controllers
{
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
    }
}