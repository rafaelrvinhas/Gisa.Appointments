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
            int? providerId,
            int serviceTypeId,
            int serviceId,
            DateTime dateAndTime)
        {
            AssociateId = associateId;
            PartnerId = partnerId;
            ProviderId = providerId;
            ServiceTypeId = serviceTypeId;
            ServiceId = serviceId;
            DateAndTime = dateAndTime;
        }
    }
}
