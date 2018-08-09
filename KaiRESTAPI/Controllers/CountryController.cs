using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KaiRESTAPI.Models.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KaiRESTAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private StaffyloContext context;

        public CountryController(StaffyloContext context)
        {
            this.context = context;
        }

        // GET: api/Countries
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "Enter country code" };
        }

        // GET: api/Country/SE (for Sweden)
        [HttpGet("{code}")]
        public IActionResult Get(string countryCode)
        {
            Country country = Country.ReadDB(context, countryCode);

            if (country != null)
            {
                return Ok(country);
            }
            return NotFound("Country by country code not found");
        }

        // POST: api/Country
        [HttpPost]
        public IActionResult Post([FromBody] Country country)
        {
            if (country == null)
            {
                return BadRequest("No information was provided");
            }
            else if (Country.AddCountry(context, country))
            {
                return CreatedAtRoute("Country successfully added!", new { Code = country.Code }, country);
            }
            else
            {
                return BadRequest("Conflicting with similar country code.Please enter different code");
            }
        }

        // PUT: api/Country/5
        [HttpPut]
        public IActionResult Put([FromBody] Country country)
        {
            if (country == null)
            {
                return BadRequest("No information was provided");
            }
            else if (Country.UpdateCountry(context, country))
            {
                return new NoContentResult();
            }
            return NotFound("Country not found!");
            
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete]
        public IActionResult Delete([FromBody] string countryCode)
        {
            if (Country.DeleteCountry(context, countryCode))
            {
                return Ok("Deleted country");
            }

            return NotFound("Country was not found to be deleted");
        }
    }
}
