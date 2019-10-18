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
            var result = _context.slots.SingleOrDefault(s => s.posX == posX && s.posY == posY);

            if (result.IsOccupied)
            {
                result.IsOccupied = false;
                _context.SaveChanges();
                return Ok("Have a nice day!");
            }
            else
            {
                var response = _context.ticketFactory.GenerateTicket(posX, posY);

                if (result != null)
                {
                    result.IsOccupied = true;
                    _context.SaveChanges();
                }
                else
                {
                    return NotFound("There is not such a slot like this. Select another one.");
                }
                return Ok(response);
            }
        }

        [HttpDelete("{posX}/{posY}")]
        public ActionResult DeleteSlot(int posX, int posY)
        {
            var slot = _context.slots.SingleOrDefault(s => s.posX == posX && s.posY == posY);

            if (slot == null) return NotFound();

            _context.slots.Remove(slot);
            _context.SaveChanges();

            return Ok($"Succesfully deleted a slot: X = {posX} Y = {posY}");
        }
    }
}
