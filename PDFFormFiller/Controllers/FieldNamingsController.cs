using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PDFFormFiller.Models;

namespace PDFFormFiller.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FieldNamingsController : ControllerBase
    {
        private readonly DBContext _context;

        public FieldNamingsController(DBContext context)
            => _context = context;

        // GET: api/FieldNamings?page=1
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FieldNaming>>> GetFieldNaming(int page = 0)
        {
            return await _context.FieldNaming.Where(item => page > 0 ? item.Page == page : true).OrderBy(item => item.Page).ThenBy(item => item.ModelFieldName).ToListAsync();
        }

        // GET: api/FieldNamings/ReferralOrganizationName
        [HttpGet("{id}")]
        public async Task<ActionResult<FieldNaming>> GetFieldNaming(string id)
        {
            var fieldNaming = await _context.FieldNaming.FindAsync(id);

            if (fieldNaming == null)
            {
                return NotFound();
            }

            return fieldNaming;
        }

        // PUT: api/FieldNamings/ReferralOrganizationName
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFieldNaming(string id, FieldNaming fieldNaming)
        {
            if (!FieldNamingExists(id))
                return NotFound();

            if (id != fieldNaming.ModelFieldName)
                return BadRequest();

            _context.Entry(fieldNaming).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FieldNamingExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/FieldNamings
        [HttpPost]
        public async Task<ActionResult<FieldNaming>> PostFieldNaming(FieldNaming fieldNaming)
        {
            _context.FieldNaming.Add(fieldNaming);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (FieldNamingExists(fieldNaming.ModelFieldName))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetFieldNaming", new { id = fieldNaming.ModelFieldName }, fieldNaming);
        }

        // DELETE: api/FieldNamings/ReferralOrganizationName
        [HttpDelete("{id}")]
        public async Task<ActionResult<FieldNaming>> DeleteFieldNaming(string id)
        {
            var fieldNaming = await _context.FieldNaming.FindAsync(id);
            if (fieldNaming == null)
                return NotFound();

            _context.FieldNaming.Remove(fieldNaming);
            await _context.SaveChangesAsync();

            return Ok(fieldNaming);
        }

        private bool FieldNamingExists(string id)
        {
            return _context.FieldNaming.Any(e => e.ModelFieldName == id);
        }
    }
}
