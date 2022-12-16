using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShipingApisWithCodeFirstApprochEF6.Interfaces.Repositories
{
    public class UnitOfInterfacesRepository : IUnitOfInterfaces
    {
        private readonly ApplicationDbContext _con;
        public UnitOfInterfacesRepository(ApplicationDbContext conn)
        {
            _con = conn;
            ShipFromAddress = new ShipFromAddressRepository(_con);
            ShipToAddress = new ShipToAddressRepository(_con);
            Client = new ClientRepository(_con);
            ShipmentPackages = new ShipmentPackagesRepository(_con);
            Shipment = new ShipmentRepository(_con);
        }
        public IShipFromAddress ShipFromAddress { get;private set; }

        public IShipToAddress ShipToAddress { get;private set; }
        public IClient Client { get;private set; }

        public IShipmentPackages ShipmentPackages { get;private set; }

        public IShipment Shipment { get;private set; }

  
    }
}
