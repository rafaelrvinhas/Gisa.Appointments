using Appointments.Domain.Interfaces;
using Appointments.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appointments.Infra.Data.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppointmentContext _context;

        public UnitOfWork(AppointmentContext context)
        {
            _context = context;
        }

        public bool Commit()
        {
            return _context.SaveChanges() > 0;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
