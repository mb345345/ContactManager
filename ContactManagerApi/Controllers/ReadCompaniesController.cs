﻿using ContactManagerBll;
using ContactManagerBll.Interfaces;
using ContactManagerModel;
using Microsoft.AspNetCore.Mvc;

namespace ContactManagerApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReadCompaniesController : Controller
    {
        private readonly ICompanyManager companyManager;

        public ReadCompaniesController(ICompanyManager companyManager)
        {
            this.companyManager = companyManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public List<Company> Get()
        {
            var companies = companyManager.ReadCompanies();

            return companies;
        }
    }
}
