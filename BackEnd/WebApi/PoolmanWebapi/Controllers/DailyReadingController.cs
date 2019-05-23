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

    [Produces("application/json")]
    [Route("odata/DailyReading")]
    [ApiController]
    [EnableCors("AllowOrigin")]
   
    public class DailyReadingController : ODataController
    {
        private readonly CatholicFeedDataContext _context;

        public DailyReadingController(CatholicFeedDataContext context)
        {
            _context = context;
        }

        // GET: api/DailyReading
        [HttpGet]
        [EnableQuery]
        public IQueryable<DailyReadingDTO> GetDailyReadings()
        {
            return  _context.DailyReadings.AsQueryable();
        }

        //[HttpGet]
        //[EnableQuery]
        //public async Task<ActionResult<IEnumerable<DailyReadingDTO>>> GetDailyReadings([FromODataUri] DateTime publishDate)
        //{
        //    return await _context.DailyReadings.Where(r=>r.publishdate == publishDate).ToListAsync();
        //}

        // GET: api/DailyReading/5
        [HttpGet("{id}")]
        [EnableQuery]
        public async Task<ActionResult<DailyReadingDTO>> GetDailyReadingDTO(int id)
        {
            var dailyReadingDTO = await _context.DailyReadings.FindAsync(id);

            if (dailyReadingDTO == null)
            {
                return NotFound();
            }

            return dailyReadingDTO;
        }

        // PUT: api/DailyReading/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDailyReadingDTO(int id, DailyReadingDTO dailyReadingDTO)
        {
            if (id != dailyReadingDTO.Id)
            {
                return BadRequest();
            }

            _context.Entry(dailyReadingDTO).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DailyReadingDTOExists(id))
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

        // POST: api/DailyReading
        [HttpPost]
        public async Task<ActionResult<DailyReadingDTO>> PostDailyReadingDTO(DailyReadingDTO dailyReadingDTO)
        {
            _context.DailyReadings.Add(dailyReadingDTO);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDailyReadingDTO", new { id = dailyReadingDTO.Id }, dailyReadingDTO);
        }

        // DELETE: api/DailyReading/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<DailyReadingDTO>> DeleteDailyReadingDTO(int id)
        {
            var dailyReadingDTO = await _context.DailyReadings.FindAsync(id);
            if (dailyReadingDTO == null)
            {
                return NotFound();
            }

            _context.DailyReadings.Remove(dailyReadingDTO);
            await _context.SaveChangesAsync();

            return dailyReadingDTO;
        }

        private bool DailyReadingDTOExists(int id)
        {
            return _context.DailyReadings.Any(e => e.Id == id);
        }
    }
}
