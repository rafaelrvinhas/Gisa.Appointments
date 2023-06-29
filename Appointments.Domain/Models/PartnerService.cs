using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appointments.Domain.Models
{
    public class PartnerService
    {
        public int PartnerId { get; set; }
        public Partner Partner { get; set; }

        public int ServiceId { get; set; }
        public Service Service { get; set; }
    }
}
