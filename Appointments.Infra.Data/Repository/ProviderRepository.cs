using Appointments.Domain.Interfaces;
using Appointments.Domain.Models;
using Appointments.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appointments.Infra.Data.Repository
{
    public class ProviderRepository : Repository<Provider>, IProviderRepository
    {
        public ProviderRepository(AppointmentContext context) : base(context)
        { }

        public IEnumerable<Provider> GetProvidersByPartner(int partnerId, int planClassificationId, int planOptionId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Provider> GetProvidersBySpecialty(int specialtyId, int planClassificationId, int planOptionId)
        {
            throw new NotImplementedException();
        }
    }
}
