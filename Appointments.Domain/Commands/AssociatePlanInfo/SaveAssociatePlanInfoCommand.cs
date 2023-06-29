using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appointments.Domain.Commands.AssociatePlanInfo
{
    public class SaveAssociatePlanInfoCommand : AssociatePlanInfoCommand
    {
        public SaveAssociatePlanInfoCommand(
            int associateId,
            int planId,
            int planClassificationId,
            int planOptionId,
            int planTypeId,
            DateTime planExpirationDate)
        {
            AssociateId = associateId;
            PlanId = planId;
            PlanClassificationId = planClassificationId;
            PlanOptionId = planOptionId;
            PlanTypeId = planTypeId;
            PlanExpirationDate = planExpirationDate;
        }
    }
}
