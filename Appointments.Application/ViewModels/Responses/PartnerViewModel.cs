using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Appointments.Application.ViewModels.Base;
using Appointments.Application.ViewModels.Enums;

namespace Appointments.Application.ViewModels.Responses
{
    public class PartnerViewModel : PlanLevelViewModel
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("Nome")]
        public string Name { get; set; }

        [JsonIgnore]
        public EPartnerTypeViewModel PartnerType { get; set; }

        [JsonPropertyName("tipo_conveniado")]
        public string PartnerTypeName
        {
            get
            {
                return PartnerType switch
                {
                    EPartnerTypeViewModel.Clinic => "Clínica",
                    EPartnerTypeViewModel.Hospital => "Hospital",
                    EPartnerTypeViewModel.Laboratory => "Laboratorio",
                    _ => string.Empty
                };
            }
        }
    }
}
