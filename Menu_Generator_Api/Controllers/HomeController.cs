﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Menu_Generator_Api.Models;
using Menu_Generator.Core;
using Menu_Generator_Api.Service;

namespace Menu_Generator_Api.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View(new IndexVM());
        }

        [HttpPost]
        public IActionResult Index(IndexVM param)
        {
            //mapping
            GetMenuRequest request = new GetMenuRequest()
            {
                CH = param.CarboHydrate,
                Protein = param.Protein,
                Fat = param.Fat,
                CHFlexibility = param.CarboHydrateFlexibility,
                ProteinFlexibility = param.ProteinFlexibility,
                FatFlexibility = param.FatFlexibility,
                IsMenuIncluded = false,
                Day = DayOfWeek.Tuesday,
                CategoriesFilters = new List<CategoriesFilter>()
                {
                    new CategoriesFilter()
                    {
                        Category = Categories.Breakfast,
                        AmountAtLeast = 1,
                        AmountFlexible_Plus = 4
                    },
                    new CategoriesFilter()
                    {
                        Category = Categories.Soup,
                        AmountAtLeast = 1,
                        AmountFlexible_Plus = 2
                    },
                    new CategoriesFilter()
                    {
                        Category = Categories.Freshschnitzel,
                        AmountAtLeast = 2,
                        AmountFlexible_Plus = 6
                    },
                    new CategoriesFilter()
                    {
                        Category = Categories.Dish,
                        AmountAtLeast = 2,
                        AmountFlexible_Plus = 6
                    }
                }
            };

            //Use DI
            MenuGeneratorService menuGenerator = new MenuGeneratorService();
            List<IEnumerable<ProductWrapper>> result = menuGenerator.GetMenu(request);
            param.Menus = result;
            return View(param);
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}
