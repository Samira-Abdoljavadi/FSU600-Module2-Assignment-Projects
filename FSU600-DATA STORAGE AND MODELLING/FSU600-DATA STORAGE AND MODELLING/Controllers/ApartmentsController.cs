using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FSU600_DATA_STORAGE_AND_MODELLING.Models;
using FSU600_DATA_STORAGE_AND_MODELLING.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FSU600_DATA_STORAGE_AND_MODELLING.Controllers
{
    public class ApartmentsController : Controller
    {
        private readonly ApartmentsService _apartmentsService;

        public ApartmentsController(ApartmentsService apartmentsService)
        {
            _apartmentsService = apartmentsService;
        }

        // GET: ApartmentsController
        public ActionResult Index()
        {
            return View(_apartmentsService.Get());
        }

        // GET: ApartmentsController/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var apartments = _apartmentsService.Get(id);
            if (apartments == null)
            {
                return NotFound();
            }
            return View(apartments);
        }

        // GET: ApartmentsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ApartmentsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Apartments apartments)
        {
            if (ModelState.IsValid)
            {
                _apartmentsService.Create(apartments);
                return RedirectToAction(nameof(Index));
            }
            return View(apartments);
        }

        // GET: ApartmentsController/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var apartments = _apartmentsService.Get(id);
            if (apartments == null)
            {
                return NotFound();
            }
            return View(apartments);
        }

        // POST: ApartmentsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(string id, Apartments apartments)
        {
            if (id != apartments.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                _apartmentsService.Update(id, apartments);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(apartments);
            }
        }

        // GET: ApartmentsController/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var apartments = _apartmentsService.Get(id);
            if (apartments == null)
            {
                return NotFound();
            }
            return View(apartments);
        }

        // POST: ApartmentsController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            try
            {
                var apartments = _apartmentsService.Get(id);

                if (apartments == null)
                {
                    return NotFound();
                }

                _apartmentsService.Remove(apartments.Id);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

    }
}
