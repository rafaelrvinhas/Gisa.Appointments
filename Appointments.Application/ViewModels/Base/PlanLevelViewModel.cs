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

        [JsonPropertyName("classificacao_plano")]
        public string PlanClassificationName
        {
            get
            {
                return PlanClassification switch
                {
                    EPlanClassificationViewModel.Nursery => "Enfermaria",
                    EPlanClassificationViewModel.Apartament => "Apartamento",
                    EPlanClassificationViewModel.Vip => "VIP",
                    _ => string.Empty
                };
            }
        }

        [JsonIgnore]
        public EPlanOptionViewModel PlanOption { get; set; }

        [JsonPropertyName("opcao_plano")]
        public string PlanOptionName
        {
            get
            {
                return PlanOption switch
                {
                    EPlanOptionViewModel.MedicalPlan => "Plano médico",
                    EPlanOptionViewModel.DentalMedicalPlan => "Plano médico-odontológico",
                    _ => string.Empty
                };
            }
        }
    }
}
