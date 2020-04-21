using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VJ.MyAirport.EF;

namespace MyAirportApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VolsController : ControllerBase
    {
        private readonly MyAirportContext _context;

        public VolsController(MyAirportContext context)
        {
            _context = context;
        }

        // GET: api/Vols
        /// <summary>
        /// get a vol
        /// </summary>
        /// <returns>return all vols</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Vol>>> GetVols()
        {
            return await _context.Vols.ToListAsync();
        }


        // GET: api/Vol/5
        /// <summary>
        /// get a specific vol
        /// </summary>
        /// <returns>error if needed else return vol asked</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Vol>> GetVol(int id, [FromQuery] bool bags = false)
        {

            Vol volsRes;

            if (bags)
            {
                volsRes = await _context.Vols.Include(v => v.Bagages).FirstAsync(v => v.VolId == id);
            }
            else
            {
                volsRes = await _context.Vols.FindAsync(id); //Bagages[] == null
            }
            if (volsRes == null)
            {
                return NotFound();
            }
            return volsRes;

        }

        // PUT: api/Vols/5
        /// <summary>
        /// put a vol
        /// </summary>
        /// <returns>Error if needed else nothing</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVol(int id, Vol vol)
        {
            if (id != vol.VolId)
            {
                return BadRequest();
            }

            _context.Entry(vol).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VolExists(id))
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

        // POST: api/Vols
        /// <summary>
        /// add a new vol
        /// </summary>
        /// <returns>error if needed else the vol just added</returns>
        [HttpPost]
        public async Task<ActionResult<Vol>> PostVol(Vol vol)
        {
            _context.Vols.Add(vol);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVol", new { id = vol.VolId }, vol);
        }

        // DELETE: api/Vols/5
        /// <summary>
        /// delete a specific vol
        /// </summary>
        /// <returns>error if needed else the vol just deleted</returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult<Vol>> DeleteVol(int id)
        {
            var vol = await _context.Vols.FindAsync(id);
            if (vol == null)
            {
                return NotFound();
            }

            _context.Vols.Remove(vol);
            await _context.SaveChangesAsync();

            return vol;
        }

        private bool VolExists(int id)
        {
            return _context.Vols.Any(e => e.VolId == id);
        }
    }
}
