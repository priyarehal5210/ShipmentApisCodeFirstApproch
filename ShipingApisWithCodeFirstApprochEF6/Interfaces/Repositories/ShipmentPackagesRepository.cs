using ShipingApisWithCodeFirstApprochEF6.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShipingApisWithCodeFirstApprochEF6.Interfaces.Repositories
{
    public class ShipmentPackagesRepository:GenericRepository<ShipmentPackage>,IShipmentPackages
    {
        private readonly ApplicationDbContext _con;
        public ShipmentPackagesRepository(ApplicationDbContext conn):base(conn)
        {
            _con = conn;
        }
    }
}
