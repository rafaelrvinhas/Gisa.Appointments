using Appointments.Application.ViewModels.Requests;
using Appointments.Application.ViewModels.Responses;
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
        IEnumerable<AppointmentViewModel> GetProviderAppointments(int providerId);
        IEnumerable<AppointmentViewModel> GetServiceAppointments(int serviceId, int partnerId);
        IEnumerable<AppointmentViewModel> GetAppointments(int associateId);
        void RequestNewAppointment(NewAppointmentRequestViewModel newAppointmentRequest, int associateId);
    }
}
