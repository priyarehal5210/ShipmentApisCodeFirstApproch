using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ShipingApisWithCodeFirstApprochEF6.Model
{
    public class Client
    {
        [SwaggerSchema(ReadOnly = true)]
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsEnabled { get; set; }
        public bool IsDeleted { get; set; }
        public string Name { get; set; }
        [EmailAddress]
        public string EmailAddress { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public int Zip { get; set; }
        public string State { get; set; }
        public int CountryCode { get; set; }
    }
}
