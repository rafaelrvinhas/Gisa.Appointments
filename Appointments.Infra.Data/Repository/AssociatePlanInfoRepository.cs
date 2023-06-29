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
    public class AssociatePlanInfoRepository : Repository<AssociatePlanInfo>, IAssociatePlanInfoRepository
    {
        public AssociatePlanInfoRepository(AppointmentContext context) : base(context)
        { }

        public AssociatePlanInfo GetAssociatePlanDetails(int associateId)
        {
            return DbSet.AsNoTracking().FirstOrDefault(a => a.AssociateId == associateId);
        }
    }
}
