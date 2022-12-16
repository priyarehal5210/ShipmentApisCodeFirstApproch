using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShipingApisWithCodeFirstApprochEF6.Model
{
    public class ShipToAddress
    {
        [SwaggerSchema(ReadOnly = true)]
        public int Id { get; set; }
        public string AddressName { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public int Zip { get; set; }
        public string State { get; set; }
        public int CountryCode { get; set; }
    }
}
