using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShipingApisWithCodeFirstApprochEF6.Interfaces;
using ShipingApisWithCodeFirstApprochEF6.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShipingApisWithCodeFirstApprochEF6.Controllers
{
    [Route("api/ShipToAddress")]
    [ApiController]
    public class ShipToAddressController : Controller
    {
        private readonly IUnitOfInterfaces _unitOfInterfaces;
        public ShipToAddressController(IUnitOfInterfaces unitOfInterfaces)
        {
            _unitOfInterfaces = unitOfInterfaces;
        }
        [HttpGet]
        public IActionResult GetShipToAddress()
        {
            var shipFromAddressList = _unitOfInterfaces.ShipToAddress.GetAll();
            return Ok(shipFromAddressList);
        }
        [HttpPost]
        public IActionResult AddShipToAddress([FromBody] ShipToAddress ShipToAddress)
        {
            if (ShipToAddress.Id == 0)
            {
                if (ModelState.IsValid)
                {
                    _unitOfInterfaces.ShipToAddress.Add(ShipToAddress);
                    _unitOfInterfaces.ShipToAddress.Save();
                    return Ok(new { message = "Data Added Successfully." });
                }
            }
            return BadRequest(new { message = "something went wrong." });
        }
        [HttpPut]
        public IActionResult UpdateShipToAddress([FromBody] ShipToAddress ShipToAddress)
        {
            if (ShipToAddress.Id != 0)
            {
                if (ModelState.IsValid)
                {
                    _unitOfInterfaces.ShipToAddress.Update(ShipToAddress);
                    _unitOfInterfaces.ShipToAddress.Save();
                    return Ok(new { message = "Data Updated Successfully." });
                }
            }
            return BadRequest(new { message = "something went wrong." });
        }
        [HttpDelete]
        public IActionResult DeleteShipToAddress(int id)
        {
            var shipToAddressFromDb = _unitOfInterfaces.ShipToAddress.Get(id);
            if (shipToAddressFromDb == null) return NotFound(new { message = "No Data Found" });
            else
            {
                _unitOfInterfaces.ShipToAddress.Remove(shipToAddressFromDb);
                _unitOfInterfaces.ShipToAddress.Save();
                return Ok(new { message = "Data Deleted Successfully." });
            }
        }
    }
}
