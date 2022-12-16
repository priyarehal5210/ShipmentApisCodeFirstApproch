using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShipingApisWithCodeFirstApprochEF6.Interfaces
{
    public interface IUnitOfInterfaces
    {
        IShipFromAddress ShipFromAddress { get; }
        IShipToAddress ShipToAddress { get; }
        IClient Client { get; }
        IShipmentPackages ShipmentPackages { get; }
        IShipment Shipment { get; }
    }
}
