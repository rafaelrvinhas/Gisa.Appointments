using Appointments.Application.ViewModels.Base;
using Appointments.Application.ViewModels.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appointments.Application.ViewModels.Responses
{
    public class ProviderViewModel : PlanLevelViewModel
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
