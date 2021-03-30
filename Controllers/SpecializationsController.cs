using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SpecilizationAPI.Models;
using SpecilizationAPI.Repository;

namespace SpecilizationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpecializationsController : ControllerBase
    {
        private readonly ISpecializationRepo _context;

        public SpecializationsController(ISpecializationRepo context)
        {
            _context = context;
        }

        // GET: api/Specializations
        [HttpGet]
        public  IEnumerable<SpecializationTable> GetSpecializations()
        {
            return  _context.GetAllSpecialization();
        }

        

       

        // POST: api/Specializations
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SpecializationTable>> PostSpecialization(SpecializationTable specialization)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
           var addedSpecilization = await _context.PostSpecialization(specialization);

            return Ok(addedSpecilization);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserServiceInfo(string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var deletedSpecilization = await _context.RemoveSpecialization(id);

            return Ok(deletedSpecilization);
        }




    }
}
