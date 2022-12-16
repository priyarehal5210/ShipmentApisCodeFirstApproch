using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ShipingApisWithCodeFirstApprochEF6.Interfaces;
using ShipingApisWithCodeFirstApprochEF6.Model;

namespace ShipingApisWithCodeFirstApprochEF6.Controllers
{
    [Route("api/ShipFromAddress")]
    [ApiController]
    public class ShipFromAddressController : Controller
    {
        private readonly IUnitOfInterfaces _unitOfInterfaces;
        public ShipFromAddressController(IUnitOfInterfaces unitOfInterfaces)
        {
            _unitOfInterfaces = unitOfInterfaces;
        }
        [HttpGet]
        public IActionResult GetShipFromAddress()
        {
           var shipFromAddressList= _unitOfInterfaces.ShipFromAddress.GetAll();
           return Ok(shipFromAddressList);
        }
        [HttpPost]
        public IActionResult AddShipFromAddress([FromBody] ShipFromAddress shipFromAddress)
        {
            if (shipFromAddress.Id == 0)
            {
                if (ModelState.IsValid)
                {
                    _unitOfInterfaces.ShipFromAddress.Add(shipFromAddress);
                    _unitOfInterfaces.ShipFromAddress.Save();
                    return Ok(new { message = "Data Added Successfully." });
                }
            }
            return BadRequest(new { message = "something went wrong." });
        }
        [HttpPut]
        public IActionResult UpdateShipFromAddress([FromBody] ShipFromAddress shipFromAddress)
        {
            if (shipFromAddress.Id != 0)
            {
                if (ModelState.IsValid)
                {
                    _unitOfInterfaces.ShipFromAddress.Update(shipFromAddress);
                    _unitOfInterfaces.ShipFromAddress.Save();
                    return Ok(new { message = "Data Updated Successfully." });
                }
            }
            return BadRequest(new { message = "something went wrong." });
        }
        [HttpDelete]
        public IActionResult DeleteShipFromAddress(int id)
        {
            var shipFromAddressFromDb = _unitOfInterfaces.ShipFromAddress.Get(id);
            if (shipFromAddressFromDb == null) return NotFound(new { message = "No Data Found" });
            else
            {
                _unitOfInterfaces.ShipFromAddress.Remove(shipFromAddressFromDb);
                _unitOfInterfaces.ShipFromAddress.Save();
                return Ok(new { message = "Data Deleted Successfully." });
            }
        }
    }
}
