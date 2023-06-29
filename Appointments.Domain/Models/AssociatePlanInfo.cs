using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appointments.Domain.Models
{
    [Table(name: "AssociatePlanInfo", Schema = "dbo")]
    public class AssociatePlanInfo
    {
        public AssociatePlanInfo(
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

        [Key]
        [Column(name: "AssociateId", TypeName = "int")]
        public int AssociateId { get; set; }

        [Column(name: "PlanId", TypeName = "int")]
        public int PlanId { get; set; }

        [Column(name: "PlanClassificationId", TypeName = "int")]
        public int PlanClassificationId { get; set; }

        [Column(name: "PlanOptionId", TypeName = "int")]
        public int PlanOptionId { get; set; }

        [Column(name: "PlanTypeId", TypeName = "int")]
        public int PlanTypeId { get; set; }

        //private string _formattedPlanExpirationDate;

        [Column(name: "PlanExpirationDate", TypeName = "date")]
        public DateTime PlanExpirationDate { get; set; }
    }
}
