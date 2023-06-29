using Appointments.Domain.Models.Base;
using Appointments.Domain.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appointments.Domain.Models
{
    public class Specialty : PlanLevel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<PartnerSpecialty> SpecialtyPartners { get; set; }
    }
}
