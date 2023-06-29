using Appointments.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appointments.Domain.CommandHandlers
{
    public class CommandHandler
    {
        private readonly IUnitOfWork _uow;
        public CommandHandler(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public bool Commit()
        {
            if (_uow.Commit()) return true;

            return false;
        }
    }
}
