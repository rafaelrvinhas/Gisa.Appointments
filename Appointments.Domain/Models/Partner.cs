using Appointments.Domain.Models.Base;
using Appointments.Domain.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appointments.Domain.Models
{
    [Table(name: "Partner", Schema = "dbo")]
    public class Partner : PlanLevel
    {
        public Partner()
        {
            Name = string.Empty;
            Providers = new List<Provider>();
            PartnerServices = new List<PartnerService>();
            PartnerSpecialties = new List<PartnerSpecialty>();
        }

        [Key]
        [Column(name: "Id", TypeName = "int")]
        public int Id { get; set; }

        [Column(name: "Name", TypeName = "varchar(250)")]
        public string Name { get; set; }

        [Column(name: "PartnerTypeId", TypeName = "int")]
        public EPartnerType PartnerType { get; set; }

        public IEnumerable<Provider> Providers { get; set; }
        public IEnumerable<PartnerService> PartnerServices { get; set; }
        public IEnumerable<PartnerSpecialty> PartnerSpecialties { get; set; }
    }
}
