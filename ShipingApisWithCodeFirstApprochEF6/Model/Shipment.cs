using ShipingApisWithCodeFirstApprochEF6.Interfaces;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShipingApisWithCodeFirstApprochEF6.Model
{
    public class Shipment:ISoftDelete
    {
        [SwaggerSchema(ReadOnly = true)]

        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime AlteredDate { get; set; }
        public int ClientID { get; set; }
        public Client client { get; set; }
        public int ServiceId { get; set; }
        public int ShipFromAddressId { get; set; }
        public ShipFromAddress ShipFromAddress { get; set; }
        public int ShipToAddressId { get; set; }
        public ShipToAddress shipToAddress { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsPending { get; set; }
        public bool IsShipped { get; set; }
        public bool IssDeleted { get; set; }
    }
}
