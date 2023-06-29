using Appointments.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appointments.Domain.Interfaces
{
    public interface IProviderRepository : IRepository<Provider>
    {
        IEnumerable<Provider> GetProvidersByPartner(int partnerId, int planClassificationId, int planOptionId);
        IEnumerable<Provider> GetProvidersBySpecialty(int specialtyId, int planClassificationId, int planOptionId);
    }
}
