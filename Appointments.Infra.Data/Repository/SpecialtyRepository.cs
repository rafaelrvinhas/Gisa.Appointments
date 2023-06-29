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
    public class SpecialtyRepository : Repository<Specialty>, ISpecialtyRepository
    {
        public SpecialtyRepository(AppointmentContext context) : base(context)
        { }

        public IEnumerable<Specialty> GetSpecialties(int planClassificationId, int planOptionId)
        {
            return DbSet.AsNoTracking().ToList()
                .Where(s =>
                    (int)s.PlanClassification == planClassificationId &&
                    (int)s.PlanOption == planOptionId);
        }
    }
}
