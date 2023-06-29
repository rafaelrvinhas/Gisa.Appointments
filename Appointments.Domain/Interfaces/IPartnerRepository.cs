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
        IEnumerable<Partner> GetPartnersByService(int serviceId, int planClassificationId, int planOptionId);
        IEnumerable<Partner> GetPartnersBySpecialty(int specialtyId, int planClassificationId, int planOptionId);
    }
}
