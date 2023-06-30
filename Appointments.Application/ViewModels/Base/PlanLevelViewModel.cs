using Appointments.Application.ViewModels.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Appointments.Application.ViewModels.Base
{
    public abstract class PlanLevelViewModel
    {
        [JsonIgnore]
        public EPlanClassificationViewModel PlanClassification { get; set; }

        [JsonIgnore]
        public EPlanOptionViewModel PlanOption { get; set; }
    }
}
