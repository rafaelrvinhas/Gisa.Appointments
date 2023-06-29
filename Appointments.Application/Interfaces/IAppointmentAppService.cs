using Appointments.Application.ViewModels.Requests;
using Appointments.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appointments.Application.Interfaces
{
    public interface IAppointmentAppService : IDisposable
    {
        IEnumerable<Appointment> GetProviderAppointments(int providerId);
        IEnumerable<Appointment> GetServiceAppointments(int serviceId, int partnerId);
        void RequestNewAppointment(NewAppointmentRequestViewModel newAppointmentRequest, int associateId);
    }
}
