//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using ShipingApisWithCodeFirstApprochEF6.Model;

//namespace ShipingApisWithCodeFirstApprochEF6.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class testController : ControllerBase
//    {
//        private readonly ApplicationDbContext _context;

//        public testController(ApplicationDbContext context)
//        {
//            _context = context;
//        }

//        // GET: api/test
//        [HttpGet]
//        public async Task<ActionResult<IEnumerable<ShipFromAddress>>> GetShipFromAddress()
//        {
//            return await _context.ShipFromAddress.ToListAsync();
//        }

//        // GET: api/test/5
//        [HttpGet("{id}")]
//        public async Task<ActionResult<ShipFromAddress>> GetShipFromAddress(int id)
//        {
//            var shipFromAddress = await _context.ShipFromAddress.FindAsync(id);

//            if (shipFromAddress == null)
//            {
//                return NotFound();
//            }

//            return shipFromAddress;
//        }

//        // PUT: api/test/5
//        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
//        [HttpPut("{id}")]
//        public async Task<IActionResult> PutShipFromAddress(int id, ShipFromAddress shipFromAddress)
//        {
//            if (id != shipFromAddress.Id)
//            {
//                return BadRequest();
//            }

//            _context.Entry(shipFromAddress).State = EntityState.Modified;

//            try
//            {
//                await _context.SaveChangesAsync();
//            }
//            catch (DbUpdateConcurrencyException)
//            {
//                if (!ShipFromAddressExists(id))
//                {
//                    return NotFound();
//                }
//                else
//                {
//                    throw;
//                }
//            }

//            return NoContent();
//        }

//        // POST: api/test
//        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
//        [HttpPost]
//        public async Task<ActionResult<ShipFromAddress>> PostShipFromAddress(ShipFromAddress shipFromAddress)
//        {
//            _context.ShipFromAddress.Add(shipFromAddress);
//            await _context.SaveChangesAsync();

//            return CreatedAtAction("GetShipFromAddress", new { id = shipFromAddress.ID }, shipFromAddress);
//        }

//        // DELETE: api/test/5
//        [HttpDelete("{id}")]
//        public async Task<IActionResult> DeleteShipFromAddress(int id)
//        {
//            var shipFromAddress = await _context.ShipFromAddress.FindAsync(id);
//            if (shipFromAddress == null)
//            {
//                return NotFound();
//            }

//            _context.ShipFromAddress.Remove(shipFromAddress);
//            await _context.SaveChangesAsync();

//            return NoContent();
//        }

//        private bool ShipFromAddressExists(int id)
//        {
//            return _context.ShipFromAddress.Any(e => e.ID == id);
//        }
//    }
//}
