using Appointments.Domain.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Appointments.Application.ViewModels.Requests
{
    public class NewAppointmentRequestViewModel
    {
        [JsonPropertyName("id_associado")]
        public int AssociateId { get; set; }

        [JsonPropertyName("id_conveniado")]
        public int PartnerId { get; set; }

        [JsonPropertyName("id_prestador")]
        public int? ProviderId { get; set; }

        [JsonPropertyName("id_servico")]
        public int ServiceId { get; set; }

        [JsonPropertyName("id_tipo_servico")]
        public int ServiceTypeId { get; set; }

        [JsonPropertyName("data")]
        public DateOnly Date { get; set; }

        [JsonPropertyName("hora")]
        public TimeOnly Time { get; set; }

        [JsonIgnore]
        public DateTime DateAndTime { get; set; }

        public void SetDateAndTime()
        {
            DateAndTime = new DateTime(Date.Year, Date.Month, Date.Day, Time.Hour, Time.Minute, Time.Second);
        }
    }
}
