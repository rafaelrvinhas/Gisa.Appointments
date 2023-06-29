using Appointments.Domain.Core.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appointments.Domain.Commands.AssociatePlanInfo
{
    public abstract class AssociatePlanInfoCommand : Command
    {
        public int AssociateId { get; set; }
        public int PlanId { get; set; }
        public int PlanClassificationId { get; set; }
        public int PlanOptionId { get; set; }
        public int PlanTypeId { get; set; }
        public DateTime PlanExpirationDate { get; set; }
    }
}
