using Appointments.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appointments.Domain.Interfaces
{
    public interface IPartnerRepository : IRepository<Partner>
    {
        IEnumerable<Partner> GetPartners(int planClassificationId, int planOptionId);
    }
}
