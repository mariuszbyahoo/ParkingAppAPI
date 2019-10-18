using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.JsonPatch;
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
        [HttpGet(Name = "GetSlots")]
        public ActionResult<IEnumerable<Slot>> Getslots()
        {
            var returnList = _context.slots.ToList();
            returnList.Sort();
            return Ok(returnList);
        }

        // POST: api/Slots
        [HttpPost]
        public async Task<ActionResult<Slot>> PostSlot(Slot slot)
        {
            _context.slots.Add(slot);
            
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSlots", new { id = slot.Id }, slot);
        }

        // PUT: api/Slots/0/0
        [HttpPatch("{posX}/{posY}")]
        public ActionResult UpdateSlot(int posX, int posY)
        {
            var response = _context.ticketFactory.GenerateTicket(posX, posY);

                var result = _context.slots.SingleOrDefault(s => s.posX == posX && s.posY == posY);

                if (result != null)
                {
                    if (result.IsOccupied) result.IsOccupied = false;
                    else result.IsOccupied = true;
                    _context.SaveChanges();
                }
                return Ok(response);
        }
    }
}
