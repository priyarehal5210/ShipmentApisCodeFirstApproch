using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShipingApisWithCodeFirstApprochEF6.Interfaces
{
    public interface ISoftDelete
    {
        bool IssDeleted { get; set; }

    }
}
