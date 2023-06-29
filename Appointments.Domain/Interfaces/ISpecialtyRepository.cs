using Appointments.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appointments.Domain.Interfaces
{
    public interface ISpecialtyRepository : IRepository<Specialty>
    {
        IEnumerable<Specialty> GetSpecialties(int planClassificationId, int planOptionId);
    }
}
