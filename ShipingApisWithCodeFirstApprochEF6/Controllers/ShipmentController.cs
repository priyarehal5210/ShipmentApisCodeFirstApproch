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
    [Route("api/shipment")]
    [ApiController]
    public class ShipmentController : Controller
    {
        private readonly IUnitOfInterfaces _unitOfInterfaces;
        public ShipmentController(IUnitOfInterfaces unitOfInterfaces)
        {
            _unitOfInterfaces = unitOfInterfaces;
        }
        [HttpGet]
        public IActionResult GetShipment()
        {
            var shipmentList = _unitOfInterfaces.Shipment.GetAll(IncludeProperties: "client,ShipFromAddress,shipToAddress");
            return Ok(shipmentList);
        }
        [HttpPost]
        public IActionResult AddShipment([FromBody] Shipment Shipment)
        {
            if (Shipment.Id== 0)
            {
                if (ModelState.IsValid)
                {
                    _unitOfInterfaces.Shipment.Add(Shipment);
                    _unitOfInterfaces.Shipment.Save();
                    return Ok(new { message = "Data Added Successfully." });
                }
            }
            return BadRequest(new { message = "something went wrong." });
        }
        [HttpPut]
        public IActionResult UpdateShipment([FromBody] Shipment Shipment)
        {
            if (Shipment.Id != 0)
            {
                if (ModelState.IsValid)
                {
                    _unitOfInterfaces.Shipment.Update(Shipment);
                    _unitOfInterfaces.Shipment.Save();
                    return Ok(new { message = "Data Updated Successfully." });
                }
            }
            return BadRequest(new { message = "something went wrong." });
        }
        [HttpDelete]
        public IActionResult DeleteShipment(int id)
        {
            var shipmentFromDb = _unitOfInterfaces.Shipment.Get(id);
            if (shipmentFromDb == null) return NotFound(new { message = "No Data Found" });
            else
            {
                shipmentFromDb.IssDeleted = false;
                _unitOfInterfaces.Shipment.Remove(shipmentFromDb);
                _unitOfInterfaces.Shipment.Save();
                return Ok(new { message = "Data Deleted Successfully." });
            }
        }
    }
}
