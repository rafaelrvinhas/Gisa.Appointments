using Appointments.Application.ViewModels.Base;
using Appointments.Application.ViewModels.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Appointments.Application.ViewModels.Responses
{
    public class SpecialtyViewModel : PlanLevelViewModel
    {
        [JsonIgnore]
        public int Id { get; set; }

        [JsonPropertyName("nome")]
        public string Name { get; set; }
    }
}
