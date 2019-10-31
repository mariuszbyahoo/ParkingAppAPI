using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ParkingApp.API.Models;
using ParkingApp.API.ViewModel;

namespace ParkingApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SlotsController : Controller
    {
        private readonly SlotContext _context;

        public SlotsController(SlotContext context)
        {
            _context = context;
        }

        // Get the View of all of the slots.
        [Route("home")]
        [HttpGet(Name = "Gui")]
        public ViewResult Index()
        {
            var slotsListViewModel = new SlotsListViewModel()
            {
                Slots = _context.AllSlots()
            };

            return View(slotsListViewModel);
        }

        //// GET the JSON list of available slots
        [Route("json")]
        [HttpGet(Name = "GetSlots")]
        public ActionResult<IEnumerable<Slot>> Getslots()
        {
            var returnList = _context.Slots.ToList();
            returnList.Sort();
            return Ok(returnList);
        }

        // POST: api/Slots
        [HttpPost]
        public async Task<ActionResult<Slot>> PostSlot(Slot slot)
        {
            if (_context.Slots.Any(s => s.PosX == slot.PosX && s.PosY == slot.PosY))
                return BadRequest("Such a slot exists!");

            _context.Slots.Add(slot);
            
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSlots", new { id = slot.Id }, slot);
        }

        //PATCH: api/slots/{guid}
        [HttpPatch("{guid}")]
        public ActionResult UpdateSlot(Guid guid)
        {
            var result = _context.Slots.FirstOrDefault(s => s.Id == guid);
            if (result != null)
            {
                if (result.IsOccupied)
                {
                    result.IsOccupied = false;
                    _context.SaveChanges();
                    return Ok(result.Id);
                }
                else
                {
                    if (result != null)
                    {
                        result.IsOccupied = true;
                        _context.SaveChanges();
                    }
                    else
                    {
                        return NotFound("There is not such a slot like this. Select another one.");
                    }
                    return Ok(result.Id);
                }
            }
            else
            {
                return NotFound("Such a slot doesn't exists!");
            }
        }

        [HttpDelete("{guid}")]
        public ActionResult DeleteSlot(Guid guid)
        {
            var slot = _context.Slots.SingleOrDefault(s => s.Id == guid);

            if (slot == null) return NotFound();

            _context.Slots.Remove(slot);
            _context.SaveChanges();

            return Ok($"Succesfully deleted a slot with an ID: {guid}");
        }

        

        // PUT: api/Slots/0/0
        //[HttpPatch("{posX}/{posY}")]
        //public ActionResult UpdateSlot(int posX, int posY)
        //{ 
        //    var result = _context.Slots.FirstOrDefault(s => s.PosX == posX && s.PosY == posY);

        //    if (result != null)
        //    {
        //        if (result.IsOccupied)
        //        {
        //            result.IsOccupied = false;
        //            _context.SaveChanges();
        //            return Ok("Have a nice day!");
        //        }
        //        else
        //        {
        //            var response = _context.ticketFactory.GenerateTicket(posX, posY);

        //            if (result != null)
        //            {
        //                result.IsOccupied = true;
        //                _context.SaveChanges();
        //            }
        //            else
        //            {
        //                return NotFound("There is not such a slot like this. Select another one.");
        //            }
        //            return Ok(response);
        //        }
        //    }
        //    else
        //    {
        //        return NotFound("Such a slot doesn't exists!");
        //    }
        //}

        //[HttpDelete("{posX}/{posY}")]
        //public ActionResult DeleteSlot(int posX, int posY)
        //{
        //    var slot = _context.Slots.FirstOrDefault(s => s.PosX == posX && s.PosY == posY);

        //    if (slot == null) return NotFound();

        //    _context.Slots.Remove(slot);
        //    _context.SaveChanges();

        //    return Ok($"Succesfully deleted a slot: X = {posX} Y = {posY}");
        //}
    }
}
