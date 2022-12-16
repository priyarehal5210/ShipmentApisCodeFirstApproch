using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShipingApisWithCodeFirstApprochEF6.Model
{
    public class ShipmentPackage
    {
        [SwaggerSchema(ReadOnly = true)]

        public int Id { get; set; }
        public int ShipmentId { get; set; }
        public Shipment Shipment { get; set; }
        public int Length { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
    }
}
