using Appointments.Domain.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appointments.Domain.Models
{
    public class Appointment
    {
        public Appointment(
            int associateId, 
            int partnerId, 
            int providerId,
            int serviceId,
            DateTime date,
            DateTime time)
        {
            ServiceProtocolNumber = GenerateServiceProtocolNumber();
            AssociateId = associateId;
            PartnerId = partnerId;
            ProviderId = providerId;
            ServiceId = serviceId;
            Status = EAppointmentStatus.Scheduled;
            Date = date;
            Time = time;
            CreationInstant = DateTime.Now;
        }

        public int Id { get; set; }
        public string? ServiceProtocolNumber { get; set; }
        public EAppointmentStatus Status { get; set; }
        public int AssociateId { get; set; }
        public int PartnerId { get; set; }
        public int ProviderId { get; set; }
        public int ServiceId { get; set; }
        public DateTime Date { get; set; }
        public DateTime Time { get; set; }
        public DateTime CreationInstant { get; set; }

        private string? GenerateServiceProtocolNumber()
        {
            return new Random().NextInt64(0, 999999999999999).ToString();
            //return string.Empty;
        }
    }
}
