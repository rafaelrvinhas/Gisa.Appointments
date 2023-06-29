using Appointments.Domain.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appointments.Domain.Commands.Appointment
{
    public class SaveNewAppointmentRequestCommand : AppointmentCommand
    {
        public SaveNewAppointmentRequestCommand(
            int associateId,
            int partnerId,
            int providerId,
            int serviceId,
            //EAppointmentStatus status,
            DateTime date,
            DateTime time)
        {
            AssociateId = associateId;
            PartnerId = partnerId;
            ProviderId = providerId;
            ServiceId = serviceId;
            //Status = status;
            Date = date;
            Time = time;
        }
    }
}
