using Appointments.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appointments.Domain.Interfaces
{
    public interface IAppointmentRepository : IRepository<Appointment>
    {
        IEnumerable<Appointment> GetProviderAppointments(int providerId);
        IEnumerable<Appointment> GetServiceAppointments(int serviceId, int partnerId);
    }
}
