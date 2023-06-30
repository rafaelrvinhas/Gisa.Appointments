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
        bool GetProviderAppointments(int? providerId, DateTime dateAndTime);
        bool GetServiceAppointments(int? serviceId, int partnerId, DateTime dateAndTime);
        IEnumerable<Appointment> GetAppointments(int associateId);
    }
}
