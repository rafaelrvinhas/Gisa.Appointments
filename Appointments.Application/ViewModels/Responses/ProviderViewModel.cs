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
    public class ProviderViewModel : PlanLevelViewModel
    {
        [JsonIgnore]
        public int Id { get; set; }

        [JsonPropertyName("nome")]
        public string Name { get; set; }

        [JsonIgnore]
        public string DocumentNumber { get; set; }

        [JsonPropertyName("crm")]
        public string ProfessionalDocumentNumber { get; set; }

        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonIgnore]
        public string Birthdate { get; set; }

        [JsonIgnore]
        public int SpecialtyId { get; set; }

        [JsonPropertyName("especialidade")]
        public SpecialtyViewModel Specialty { get; set; }

        [JsonIgnore]
        public int PartnerId { get; set; }
    }
}
