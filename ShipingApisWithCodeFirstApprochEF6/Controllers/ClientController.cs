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
    [Route("api/client")]
    [ApiController]
    public class ClientController : Controller
    {
        private readonly IUnitOfInterfaces _unitOfInterfaces;
        public ClientController(IUnitOfInterfaces unitOfInterfaces)
        {
            _unitOfInterfaces = unitOfInterfaces;
        }
        [HttpGet]
        public IActionResult GetClient()
        {
            var clientList = _unitOfInterfaces.Client.GetAll();
            return Ok(clientList);
        }
        [HttpPost]
        public IActionResult AddClient([FromBody] Client Client)
        {
            if (Client.Id== 0)
            {
                if (ModelState.IsValid)
                {
                    _unitOfInterfaces.Client.Add(Client);
                    _unitOfInterfaces.Client.Save();
                    return Ok(new { message = "Data Added Successfully." });
                }
            }
            return BadRequest(new { message = "something went wrong." });
        }
        [HttpPut]
        public IActionResult UpdateClient([FromBody] Client Client)
        {
            if (Client.Id != 0)
            {
                if (ModelState.IsValid)
                {
                    _unitOfInterfaces.Client.Update(Client);
                    _unitOfInterfaces.Client.Save();
                    return Ok(new { message = "Data Updated Successfully." });
                }
            }
            return BadRequest(new { message = "something went wrong." });
        }
        [HttpDelete]
        public IActionResult DeleteClient(int id)
        {
            var clientFromDb = _unitOfInterfaces.Client.Get(id);
            if (clientFromDb == null) return NotFound(new { message = "No Data Found" });
            else
            {
                _unitOfInterfaces.Client.Remove(clientFromDb);
                _unitOfInterfaces.Client.Save();
                return Ok(new { message = "Data Deleted Successfully." });
            }
        }
    }
}
