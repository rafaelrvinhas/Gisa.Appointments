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

        public IEnumerable<Partner> GetPartners(int planClassificationId, int planOptionId)
        {
            return DbSet.AsNoTracking().ToList()
                .Where(p =>
                    (int)p.PlanClassification == planClassificationId &&
                    (int)p.PlanOption == planOptionId);
        }
    }
}
