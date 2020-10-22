using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FSU600_DATA_STORAGE_AND_MODELLING.Models;
using FSU600_DATA_STORAGE_AND_MODELLING.Services;
using Microsoft.AspNetCore.Mvc;

namespace FSU600_DATA_STORAGE_AND_MODELLING.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ApartmentsController : ControllerBase
    {
        private readonly ApartmentsService _apartmentsService;

        public ApartmentsController(ApartmentsService apartmentsService)
        {
            _apartmentsService = apartmentsService;
        }

        [HttpGet]
        public ActionResult<List<Apartments>> Get() =>
            _apartmentsService.Get();

        [HttpGet("{id:length(24)}", Name = "GetApartment")]
        public ActionResult<Apartments> Get(string id)
        {
            var apartment = _apartmentsService.Get(id);

            if (apartment == null)
            {
                return NotFound();
            }

            return apartment;
        }

        [HttpPost]
        public ActionResult<Apartments> Create(Apartments apartment)
        {
            _apartmentsService.Create(apartment);

            return CreatedAtRoute("GetApartment", new { id = apartment.Id.ToString() }, apartment);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, Apartments apartmentIn)
        {
            var apartment = _apartmentsService.Get(id);

            if (apartment == null)
            {
                return NotFound();
            }

            _apartmentsService.Update(id, apartmentIn);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var apartment = _apartmentsService.Get(id);

            if (apartment == null)
            {
                return NotFound();
            }

            _apartmentsService.Remove(apartment.Id);

            return NoContent();
        }
    }
}
