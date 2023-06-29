using Appointments.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appointments.Domain.Interfaces
{
    public interface IServiceRepository : IRepository<Service>
    {
        IEnumerable<Service> GetServices(int serviceTypeId, int planClassificationId, int planOptionId);
    }
}
