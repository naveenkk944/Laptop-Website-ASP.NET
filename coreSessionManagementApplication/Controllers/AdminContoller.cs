using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace coreSessionManagementApplication.Controllers
{
    public class AdminContoller : Controller
    {

        public IActionResult Index()
        {
            return View();
        }
    }
}
