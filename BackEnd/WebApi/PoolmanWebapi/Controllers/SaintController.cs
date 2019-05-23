using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Poolman.Repository;

namespace PoolmanWebapi.Controllers
{
    //[Route("api/[controller]")]
    //[ApiController]
    [Produces("application/json")]
    [Route("odata/Saint")]
    [ApiController]
    [EnableCors("AllowOrigin")]
    [EnableQuery]
    public class SaintController : ODataController
    {
        private readonly CatholicFeedDataContext _context;

        public SaintController(CatholicFeedDataContext context)
        {
            _context = context;
        }

        // GET: api/Saint
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SaintDTO>>> GetSaints()
        {
            return await _context.Saints.ToListAsync();
        }

        // GET: api/Saint/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SaintDTO>> GetSaintDTO(int id)
        {
            var saintDTO = await _context.Saints.FindAsync(id);

            if (saintDTO == null)
            {
                return NotFound();
            }

            return saintDTO;
        }

        // PUT: api/Saint/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSaintDTO(int id, SaintDTO saintDTO)
        {
            if (id != saintDTO.Id)
            {
                return BadRequest();
            }

            _context.Entry(saintDTO).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SaintDTOExists(id))
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

        // POST: api/Saint
        [HttpPost]
        public async Task<ActionResult<SaintDTO>> PostSaintDTO(SaintDTO saintDTO)
        {
            _context.Saints.Add(saintDTO);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSaintDTO", new { id = saintDTO.Id }, saintDTO);
        }

        // DELETE: api/Saint/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<SaintDTO>> DeleteSaintDTO(int id)
        {
            var saintDTO = await _context.Saints.FindAsync(id);
            if (saintDTO == null)
            {
                return NotFound();
            }

            _context.Saints.Remove(saintDTO);
            await _context.SaveChangesAsync();

            return saintDTO;
        }

        private bool SaintDTOExists(int id)
        {
            return _context.Saints.Any(e => e.Id == id);
        }
    }
}
