using Appointments.Application.ViewModels.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Appointments.Application.ViewModels.Responses
{
    public class AppointmentViewModel
    {
        [JsonPropertyName("numero_protocolo")]
        public string ServiceProtocolNumber { get; set; }

        [JsonIgnore]
        public EAppointmentStatusViewModel Status { get; set; }

        [JsonPropertyName("status")]
        public string StatusName 
        {
            get
            {
                return Status switch
                {
                    EAppointmentStatusViewModel.Scheduled => "Agendado",
                    EAppointmentStatusViewModel.Accomplished => "Realizado",
                    EAppointmentStatusViewModel.Cancelled => "Cancelado",
                    _ => string.Empty
                };
            }
        }

        [JsonIgnore]
        public int AssociateId { get; set; }

        [JsonIgnore]
        public int PartnerId { get; set; }

        [JsonPropertyName("conveniado")]
        public PartnerViewModel Partner { get; set; }

        [JsonIgnore]
        public int ProviderId { get; set; }

        [JsonPropertyName("prestador")]
        public ProviderViewModel Provider { get; set; }

        [JsonIgnore]
        public int ServiceId { get; set; }

        [JsonPropertyName("servico")]
        public ServiceViewModel Service { get; set; }

        [JsonPropertyName("data")]
        public string Date 
        { 
            get { return DateAndTime.ToString("d"); } 
        }

        [JsonPropertyName("hora")]
        public string Time 
        {
            get { return DateAndTime.ToString("t"); }
        }

        [JsonIgnore]
        public DateTime DateAndTime { get; set; }
    }
}
