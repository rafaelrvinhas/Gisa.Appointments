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
    [Table(name: "Appointment", Schema = "dbo")]
    public class Appointment
    {
        public Appointment()
        {
            ServiceProtocolNumber = string.Empty;
            Partner = new Partner();
            Provider = new Provider();
            Service = new Service();
        }

        public Appointment(
            int associateId, 
            int partnerId, 
            int? providerId,
            int serviceId,
            DateTime dateAndTime)
        {
            ServiceProtocolNumber = GenerateServiceProtocolNumber();
            AssociateId = associateId;
            PartnerId = partnerId;
            ProviderId = providerId;
            ServiceId = serviceId;
            Status = EAppointmentStatus.Scheduled;
            DateAndTime = dateAndTime;
            CreationInstant = DateTime.Now;
        }

        [Key]
        [Column(name: "Id", TypeName = "int")]
        public int Id { get; set; }

        [Column(name: "ServiceProtocolNumber", TypeName = "varchar(15)")]
        public string ServiceProtocolNumber { get; set; }

        [Column(name: "Status", TypeName = "int")]
        public EAppointmentStatus Status { get; set; }

        //[ForeignKey("AssociateId")]
        //[Column(name: "AssociateId", TypeName = "int")]
        public int AssociateId { get; set; }
        //public AssociatePlanInfo AssociatePlanInfo { get; set; }

        [ForeignKey("PartnerId")]
        [Column(name: "PartnerId", TypeName = "int")]
        public int PartnerId { get; set; }
        public Partner Partner { get; set; }

        [ForeignKey("ProviderId")]
        [Column(name: "ProviderId", TypeName = "int")]
        public int? ProviderId { get; set; }
        public Provider Provider { get; set; }

        [ForeignKey("ServiceId")]
        [Column(name: "ServiceId", TypeName = "int")]
        public int ServiceId { get; set; }
        public Service Service { get; set; }

        [Column(name: "DateAndTime", TypeName = "datetime")]
        public DateTime DateAndTime { get; set; }

        [Column(name: "CreationInstant", TypeName = "datetime")]
        public DateTime CreationInstant { get; set; }

        private static string GenerateServiceProtocolNumber()
        {
            return new Random().NextInt64(0, 999999999999999).ToString();
        }
    }
}
