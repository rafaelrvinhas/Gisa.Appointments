using Appointments.Domain.Models.Base;
using Appointments.Domain.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appointments.Domain.Models
{
    [Table(name: "Service", Schema = "dbo")]
    public class Service : PlanLevel
    {
        [Key]
        [Column(name: "Id", TypeName = "int")]
        public int Id { get; set; }

        [Column(name: "Name", TypeName = "varchar(100)")]
        public string Name { get; set; }

        [Column(name: "ServiceTypeId", TypeName = "int")]
        public EServiceType ServiceType { get; set; }

        [Column(name: "ServiceDurationTime", TypeName = "int")]
        public int ServiceDurationTime { get; set; }

        public IEnumerable<PartnerService> ServicePartners { get; set; }
    }
}
