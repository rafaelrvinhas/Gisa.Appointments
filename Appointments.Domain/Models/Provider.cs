using Appointments.Domain.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appointments.Domain.Models
{
    [Table(name: "Provider", Schema = "dbo")]
    public class Provider : PlanLevel
    {
        public Provider()
        {
            Name = string.Empty;
            DocumentNumber = string.Empty;
            ProfessionalDocumentNumber = string.Empty;
            Email = string.Empty;
            Specialty = new Specialty();
            Partner = new Partner();
        }

        [Key]
        [Column(name: "Id", TypeName = "int")]
        public int Id { get; set; }

        [Column(name: "Name", TypeName = "varchar(100)")]
        public string Name { get; set; }

        [Column(name: "DocumentNumber", TypeName = "varchar(11)")]
        public string DocumentNumber { get; set; }

        [Column(name: "ProfessionalDocumentNumber", TypeName = "varchar(10)")]
        public string ProfessionalDocumentNumber { get; set; }

        [Column(name: "Email", TypeName = "varchar(50)")]
        public string Email { get; set; }

        [Column(name: "Birthdate", TypeName = "date")]
        public DateTime Birthdate { get; set; }

        [ForeignKey("SpecialtyId")]
        [Column(name: "SpecialtyId", TypeName = "int")]
        public int SpecialtyId { get; set; }
        public Specialty Specialty { get; set; }

        [ForeignKey("PartnerId")]
        [Column(name: "PartnerId", TypeName = "int")]
        public int PartnerId { get; set; }
        public Partner Partner { get; set; }
    }
}
