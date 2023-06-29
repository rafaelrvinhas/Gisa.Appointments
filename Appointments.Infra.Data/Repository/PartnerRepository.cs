using Appointments.Domain.Interfaces;
using Appointments.Domain.Models;
using Appointments.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appointments.Infra.Data.Repository
{
    public class PartnerRepository : Repository<Partner>, IPartnerRepository
    {
        public PartnerRepository(AppointmentContext context) : base(context)
        { }

        public IEnumerable<Partner> GetPartnersByService(int serviceId, int planClassificationId, int planOptionId)
        {
            return DbSet.AsNoTracking().ToList()
                .Where(p =>
                    (int)p.PlanClassification == planClassificationId &&
                    (int)p.PlanOption == planOptionId);
        }

        public IEnumerable<Partner> GetPartnersBySpecialty(int specialtyId, int planClassificationId, int planOptionId)
        {
            throw new NotImplementedException();
        }
    }
}
