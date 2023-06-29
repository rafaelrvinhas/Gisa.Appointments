using Appointments.Domain.Interfaces;
using Appointments.Domain.Models;
using Appointments.Domain.Models.Enums;
using Appointments.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appointments.Infra.Data.Repository
{
    public class AppointmentRepository : Repository<Appointment>, IAppointmentRepository
    {
        public AppointmentRepository(AppointmentContext context) : base(context)
        { }

        public IEnumerable<Appointment> GetProviderAppointments(int providerId)
        {
            return DbSet.AsNoTracking().ToList()
                .Where(a => 
                    a.ProviderId == providerId &&
                    a.Status == EAppointmentStatus.Scheduled);
        }

        public IEnumerable<Appointment> GetServiceAppointments(int serviceId, int partnerId)
        {
            return DbSet.AsNoTracking().ToList()
                .Where(a =>
                    a.ServiceId == serviceId &&
                    a.PartnerId == partnerId &&
                    a.Status == EAppointmentStatus.Scheduled);
        }
    }
}
