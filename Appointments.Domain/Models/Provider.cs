using Appointments.Domain.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appointments.Domain.Models
{
    public class Provider : PlanLevel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string DocumentNumber { get; set; }
        public string ProfessionalDocumentNumber { get; set; }
        public string Email { get; set; }
        public string Birthdate { get; set; }
        public int SpecialtyId { get; set; }
        public int PartnerId { get; set; }
    }
}
