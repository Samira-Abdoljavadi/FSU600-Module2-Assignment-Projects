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
    public class RequestsController : Controller
    {
        private readonly RequestsService _requestsService;

        public RequestsController(RequestsService requestsService)
        {
            _requestsService = requestsService;
        }
        // GET: RequestsController
        public ActionResult Index()
        {
            return View(_requestsService.Get());
        }

        // GET: RequestsController/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var requests = _requestsService.Get(id);
            if (requests == null)
            {
                return NotFound();
            }
            return View(requests);
        }

        // GET: RequestsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RequestsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Requests requests)
        {
            if (ModelState.IsValid)
            {
                _requestsService.Create(requests);
                return RedirectToAction(nameof(Index));
            }
            return View(requests);
        }

        // GET: RequestsController/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var requests = _requestsService.Get(id);
            if (requests == null)
            {
                return NotFound();
            }
            return View(requests);
        }

        // POST: RequestsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(string id, Requests requests)
        {
            if (id != requests.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                _requestsService.Update(id, requests);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(requests);
            }
        }

        // GET: RequestsController/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var requests = _requestsService.Get(id);
            if (requests == null)
            {
                return NotFound();
            }
            return View(requests);
        }

        // POST: RequestsController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            try
            {
                var requests = _requestsService.Get(id);

                if (requests == null)
                {
                    return NotFound();
                }

                _requestsService.Remove(requests.Id);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
