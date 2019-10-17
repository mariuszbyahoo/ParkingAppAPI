using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ParkingAppAPI.Models;

namespace ParkingAppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SlotsController : ControllerBase
    {
        private readonly SlotContext _context;

        public SlotsController(SlotContext context)
        {
            _context = context;
        }

        // GET: api/Slots
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Slot>>> Getslots()
        {
            return await _context.slots.ToListAsync();
        }

        // POST: api/Slots
        [HttpPost]
        public async Task<ActionResult<Slot>> PostSlot(Slot slot)
        {
            _context.slots.Add(slot);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSlot", new { id = slot.Id }, slot);
        }

        private bool SlotExists(Guid id)
        {
            return _context.slots.Any(e => e.Id == id);
        }
    }
}
