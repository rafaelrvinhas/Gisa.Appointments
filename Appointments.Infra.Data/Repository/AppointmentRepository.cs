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
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Appointments.Infra.Data.Repository
{
    public class AppointmentRepository : Repository<Appointment>, IAppointmentRepository
    {
        public AppointmentRepository(AppointmentContext context) : base(context)
        { }

        public bool GetProviderAppointments(int? providerId, DateTime dateAndTime)
        {
            return DbSet.AsNoTracking()
                .Where(a =>
                    a.ProviderId == providerId &&
                    a.DateAndTime == dateAndTime &&
                    a.Status == EAppointmentStatus.Scheduled)
                .ToList().Count == 0;
        }

        public bool GetServiceAppointments(int? serviceId, int partnerId, DateTime dateAndTime)
        {
            return DbSet.AsNoTracking()
                .Where(a =>
                    a.ServiceId == serviceId &&
                    a.PartnerId == partnerId &&
                    a.DateAndTime == dateAndTime &&
                    a.Status == EAppointmentStatus.Scheduled)
                .ToList().Count == 0;
        }

        public IEnumerable<Appointment> GetAppointments(int associateId)
        {
            return DbSet.AsNoTracking()
                .Where(a => 
                    a.AssociateId == associateId &&
                    a.Status == EAppointmentStatus.Scheduled)
                .Include(a => a.Partner)
                .Include(a => a.Provider)
                .Include(a => a.Provider.Specialty)
                .Include(a => a.Service)
                .ToList();
        }
    }
}
