using Appointments.Domain.Commands.Appointment;
using Appointments.Domain.Interfaces;
using Appointments.Domain.Models;
using Appointments.Domain.Models.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appointments.Domain.CommandHandlers
{
    public class AppointmentCommandHandler : CommandHandler, IRequestHandler<SaveNewAppointmentRequestCommand, bool>
    {
        private readonly IAppointmentRepository _appointmentRepository;

        public AppointmentCommandHandler(IUnitOfWork uow, IAppointmentRepository appointmentRepository) : base(uow)
        {
            _appointmentRepository = appointmentRepository;
        }

        public async Task<bool> Handle(SaveNewAppointmentRequestCommand message, CancellationToken cancellationToken)
        {
            var appointment = new Appointment(
                message.AssociateId,
                message.PartnerId,
                message.ProviderId,
                message.ServiceId,
                message.DateAndTime);

            if (message.ServiceTypeId == (int)EServiceType.Consultation)
            {
                if (_appointmentRepository.GetProviderAppointments(appointment.ProviderId, appointment.DateAndTime))
                    _appointmentRepository.Add(appointment);
            }
            else
            {
                if (_appointmentRepository.GetServiceAppointments(appointment.ServiceId, appointment.PartnerId, appointment.DateAndTime))
                    _appointmentRepository.Add(appointment);
            }

            return Commit();
        }
    }
}
