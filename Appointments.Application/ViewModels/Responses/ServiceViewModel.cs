using Appointments.Application.ViewModels.Base;
using Appointments.Application.ViewModels.Enums;
using System.Text.Json.Serialization;

namespace Appointments.Application.ViewModels.Responses
{
    public class ServiceViewModel : PlanLevelViewModel
    {
        [JsonIgnore]
        public int Id { get; set; }

        [JsonPropertyName("nome")]
        public string Name { get; set; }

        [JsonIgnore]
        public EServiceTypeViewModel ServiceType { get; set; }

        [JsonPropertyName("tipo_servico")]
        public string ServiceTypeName
        {
            get
            {
                return ServiceType switch
                {
                    EServiceTypeViewModel.Consultation => "Consulta",
                    EServiceTypeViewModel.Exam => "Exame",
                    EServiceTypeViewModel.Therapy => "Terapia",
                    _ => string.Empty
                };
            }
        }

        [JsonPropertyName("service_duration_time")]
        public int ServiceDurationTime { get; set; }

        public IEnumerable<PartnerServiceViewModel> PartnerServices { get; set; }
    }
}
