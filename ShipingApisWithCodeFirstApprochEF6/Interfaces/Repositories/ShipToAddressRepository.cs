using ShipingApisWithCodeFirstApprochEF6.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShipingApisWithCodeFirstApprochEF6.Interfaces.Repositories
{
    public class ShipToAddressRepository:GenericRepository<ShipToAddress>,IShipToAddress
    {
        private readonly ApplicationDbContext _con;
        public ShipToAddressRepository(ApplicationDbContext conn):base(conn)
        {
            _con = conn;
        }
    }
}
