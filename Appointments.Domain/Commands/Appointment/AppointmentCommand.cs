using Appointments.Domain.Core.Commands;
using Appointments.Domain.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appointments.Domain.Commands.Appointment
{
    public abstract class AppointmentCommand : Command
    {
        public EAppointmentStatus Status { get; set; }
        public int AssociateId { get; set; }
        public int PartnerId { get; set; }
        public int ProviderId { get; set; }
        public int ServiceId { get; set; }
        public DateTime Date { get; set; }
        public DateTime Time { get; set; }
    }
}
