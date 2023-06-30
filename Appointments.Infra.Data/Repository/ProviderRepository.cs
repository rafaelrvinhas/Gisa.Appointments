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
    public class ProviderRepository : Repository<Provider>, IProviderRepository
    {
        public ProviderRepository(AppointmentContext context) : base(context)
        { }

        public IEnumerable<Provider> GetProvidersByPartner(int partnerId, int planClassificationId, int planOptionId)
        {
            return DbSet.AsNoTracking()
                .Where(p =>
                    (int)p.PlanClassification == planClassificationId &&
                    (int)p.PlanOption == planOptionId &&
                    p.PartnerId == partnerId)
                .Include(p => p.Specialty)
                .ToList();
        }

        public IEnumerable<Provider> GetProvidersBySpecialty(int specialtyId, int planClassificationId, int planOptionId)
        {
            return DbSet.AsNoTracking()
                .Where(p => 
                    (int)p.PlanClassification == planClassificationId &&
                    (int)p.PlanOption == planOptionId &&
                    p.SpecialtyId == specialtyId)
                .Include(p => p.Specialty)
                .ToList();
        }
    }
}
