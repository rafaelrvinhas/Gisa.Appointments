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
    public class ServiceRepository : Repository<Service>, IServiceRepository
    {
        public ServiceRepository(AppointmentContext context) : base(context)
        { }

        public IEnumerable<Service> GetServices(int serviceTypeId, int planClassificationId, int planOptionId)
        {
            return DbSet.AsNoTracking().ToList()
                .Where(s => 
                    ((int)s.ServiceType) == serviceTypeId && 
                    (int)s.PlanClassification >= planClassificationId && 
                    (int)s.PlanOption == planOptionId);
        }
    }
}
