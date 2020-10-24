using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FSU600_DATA_STORAGE_AND_MODELLING.Services;
using FSU600_DATA_STORAGE_AND_MODELLING.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FSU600_DATA_STORAGE_AND_MODELLING.Controllers
{
    public class ApplicantsController : Controller
    {
        private readonly ApplicantsService _applicantsService;

        public ApplicantsController(ApplicantsService applicantsService)
        {
            _applicantsService = applicantsService;
        }

        // GET: ApplicantsController
        public ActionResult Index()
        {
            return View(_applicantsService.Get());
        }

        // GET: ApplicantsController/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var applicants = _applicantsService.Get(id);
            if (applicants == null)
            {
                return NotFound();
            }
            return View(applicants);
        }

        // GET: ApplicantsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ApplicantsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Applicants applicants)
        {
            if (ModelState.IsValid)
            {
                _applicantsService.Create(applicants);
                return RedirectToAction(nameof(Index));
            }
            return View(applicants);
        }

        // GET: ApplicantsController/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var applicants = _applicantsService.Get(id);
            if (applicants == null)
            {
                return NotFound();
            }
            return View(applicants);
        }

        // POST: ApplicantsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(string id, Applicants applicants)
        {
            if (id != applicants.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                _applicantsService.Update(id, applicants);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(applicants);
            }
        }

        // GET: ApplicantsController/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var applicants = _applicantsService.Get(id);
            if (applicants == null)
            {
                return NotFound();
            }
            return View(applicants);
        }

        // POST: ApplicantsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            try
            {
                var applicants = _applicantsService.Get(id);

                if (applicants == null)
                {
                    return NotFound();
                }

                _applicantsService.Remove(applicants.Id);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
