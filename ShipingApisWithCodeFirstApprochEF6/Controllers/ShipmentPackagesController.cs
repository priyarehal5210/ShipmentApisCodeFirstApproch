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
    [Route("api/shipmentpackages")]
    [ApiController]
    public class ShipmentPackagesController : Controller
    {
        private readonly IUnitOfInterfaces _unitOfInterfaces;
        public ShipmentPackagesController(IUnitOfInterfaces unitOfInterfaces)
        {
            _unitOfInterfaces = unitOfInterfaces;
        }
        [HttpGet]
        public IActionResult GetShipmentPackages()
        {
            var shipmentPackagesList = _unitOfInterfaces.ShipmentPackages.GetAll(IncludeProperties: "Shipment");
            return Ok(shipmentPackagesList);
        }
        [HttpPost]
        public IActionResult AddShipmentPackages([FromBody] ShipmentPackage ShipmentPackages)
        {
            if (ShipmentPackages.Id== 0)
            {
                if (ModelState.IsValid)
                {
                    _unitOfInterfaces.ShipmentPackages.Add(ShipmentPackages);
                    _unitOfInterfaces.ShipmentPackages.Save();
                    return Ok(new { message = "Data Added Successfully." });
                }
            }
            return BadRequest(new { message = "something went wrong." });
        }
        [HttpPut]
        public IActionResult UpdateShipmentPackages([FromBody] ShipmentPackage ShipmentPackages)
        {
            if (ShipmentPackages.Id != 0)
            {
                if (ModelState.IsValid)
                {
                    _unitOfInterfaces.ShipmentPackages.Update(ShipmentPackages);
                    _unitOfInterfaces.ShipmentPackages.Save();
                    return Ok(new { message = "Data Updated Successfully." });
                }
            }
            return BadRequest(new { message = "something went wrong." });
        }
        [HttpDelete]
        public IActionResult DeleteShipmentPackages(int id)
        {
            var shipmentPackagesFromDb = _unitOfInterfaces.ShipmentPackages.Get(id);
            if (shipmentPackagesFromDb == null) return NotFound(new { message = "No Data Found" });
            else
            {
                _unitOfInterfaces.ShipmentPackages.Remove(shipmentPackagesFromDb);
                _unitOfInterfaces.ShipmentPackages.Save();
                return Ok(new { message = "Data Deleted Successfully." });
            }
        }
    }
}
