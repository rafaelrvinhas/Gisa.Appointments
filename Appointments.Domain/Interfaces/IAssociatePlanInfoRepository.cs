using Appointments.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appointments.Domain.Interfaces
{
    public interface IAssociatePlanInfoRepository : IRepository<AssociatePlanInfo>
    {
        AssociatePlanInfo GetAssociatePlanDetails(int associateId);
    }
}
