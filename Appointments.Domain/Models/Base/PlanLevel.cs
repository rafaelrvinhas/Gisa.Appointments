using Appointments.Domain.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appointments.Domain.Models.Base
{
    public abstract class PlanLevel
    {
        [Column(name: "PlanClassificationId", TypeName = "int")]
        public EPlanClassification PlanClassification { get; set; }

        [Column(name: "PlanOptionId", TypeName = "int")]
        public EPlanOption PlanOption { get; set; }
    }
}
