using SaudeAtendimentoVictor.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SaudeAtendimentoVictor.Controllers
{
    public class HomeController : Controller
    {

        public HomeController()
        {
           
        }
        public IActionResult Index()
        {
            return View();
        }

    }
}
