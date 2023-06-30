using Appointments.Application.Interfaces;
using Appointments.Application.ViewModels.Requests;
using Appointments.Application.ViewModels.Responses;
using Appointments.Domain.Commands.Appointment;
using Appointments.Domain.Core.Bus;
using Appointments.Domain.Interfaces;
using Appointments.Domain.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appointments.Application.Services
{
    public class AppointmentAppService : IAppointmentAppService
    {
        private readonly IMapper _mapper;
        private readonly IAppointmentRepository _appointmentRepository;
        private readonly IMediatorHandler Bus;

        public AppointmentAppService(
            IMapper mapper,
            IAppointmentRepository appointmentRepository,
            IMediatorHandler bus)
        {
            _mapper = mapper;
            _appointmentRepository = appointmentRepository;
            Bus = bus;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public IEnumerable<AppointmentViewModel> GetProviderAppointments(int providerId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<AppointmentViewModel> GetServiceAppointments(int serviceId, int partnerId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<AppointmentViewModel> GetAppointments(int associateId)
        {
            return _mapper.Map<IEnumerable<AppointmentViewModel>>(_appointmentRepository.GetAppointments(associateId));
        }

        public async void RequestNewAppointment(NewAppointmentRequestViewModel newAppointmentRequest, int associateId)
        {
            newAppointmentRequest.AssociateId = associateId;

            var command = _mapper.Map<SaveNewAppointmentRequestCommand>(newAppointmentRequest);
            await Bus.SendCommand(command);
        }
    }
}
