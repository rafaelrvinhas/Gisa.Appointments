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
    [Table(name: "Specialty", Schema = "dbo")]
    public class Specialty : PlanLevel
    {
        [Key]
        [Column(name: "Id", TypeName = "int")]
        public int Id { get; set; }

        [Column(name: "Name", TypeName = "varchar(100)")]
        public string Name { get; set; }

        public IEnumerable<PartnerSpecialty> SpecialtyPartners { get; set; }
    }
}
