using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appointments.Application.ViewModels.Requests
{
    public class AssociatePlanInfoViewModel
    {
        public int AssociateId { get; set; }
        public int PlanId { get; set; }
        public int PlanClassificationId { get; set; }
        public int PlanOptionId { get; set; }
        public int PlanTypeId { get; set; }
        public DateTime PlanExpirationDate { get; set; }
    }
}
