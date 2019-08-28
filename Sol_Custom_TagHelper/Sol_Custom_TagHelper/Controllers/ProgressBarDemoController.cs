using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Sol_Custom_TagHelper.Models;

namespace Sol_Custom_TagHelper.Controllers
{
    public class ProgressBarDemoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ModelExpressionDemoIndex()
        {

            var progressBarModel = new ProgressBarModel()
            {
                ProgressBarValue = 50,
                ProgressBarMax = 100,
                ProgressBarMin = 0

            };

            return View(progressBarModel);
        }
    }
}