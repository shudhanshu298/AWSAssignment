using Microsoft.AspNetCore.Mvc;
using StoreDataInDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StoreDataInDB.Repository;

namespace StoreDataInDB.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {            
            return View();
        }

    }
}
