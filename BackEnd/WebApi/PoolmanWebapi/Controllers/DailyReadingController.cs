﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Poolman.Repository;

namespace PoolmanWebapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DailyReadingController : ControllerBase
    {
        private readonly CatholicFeedDataContext _context;

        public DailyReadingController(CatholicFeedDataContext context)
        {
            _context = context;
        }

        // GET: api/DailyReading
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RssFeedDto>>> GetRssFeeds()
        {
            return await _context.RssFeeds.ToListAsync();
        }

        // GET: api/DailyReading/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RssFeedDto>> GetRssFeedDto(string id)
        {
            var rssFeedDto = await _context.RssFeeds.FindAsync(id);

            if (rssFeedDto == null)
            {
                return NotFound();
            }

            return rssFeedDto;
        }

        // PUT: api/DailyReading/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRssFeedDto(string id, RssFeedDto rssFeedDto)
        {
            if (id != rssFeedDto.Id)
            {
                return BadRequest();
            }

            _context.Entry(rssFeedDto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RssFeedDtoExists(id))
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
        public async Task<ActionResult<RssFeedDto>> PostRssFeedDto(RssFeedDto rssFeedDto)
        {
            _context.RssFeeds.Add(rssFeedDto);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRssFeedDto", new { id = rssFeedDto.Id }, rssFeedDto);
        }

        // DELETE: api/DailyReading/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<RssFeedDto>> DeleteRssFeedDto(string id)
        {
            var rssFeedDto = await _context.RssFeeds.FindAsync(id);
            if (rssFeedDto == null)
            {
                return NotFound();
            }

            _context.RssFeeds.Remove(rssFeedDto);
            await _context.SaveChangesAsync();

            return rssFeedDto;
        }

        private bool RssFeedDtoExists(string id)
        {
            return _context.RssFeeds.Any(e => e.Id == id);
        }
    }
}