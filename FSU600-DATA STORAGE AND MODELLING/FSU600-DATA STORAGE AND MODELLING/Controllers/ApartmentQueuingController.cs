using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;

namespace FSU600_DATA_STORAGE_AND_MODELLING.Controllers
{
    public class ApartmentQueuingController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        // 
        //GET: /ApartmentQueuing/

        // 
        // GET: /ApartmentQueuing/Welcome/ 

        public string Welcome(string name, int numTimes = 1)
        {
            return HtmlEncoder.Default.Encode($"Hello {name}, NumTimes is: {numTimes}");
        }

    }
}
