namespace Appointments.Application.ViewModels.Responses
{
    public class PartnerServiceViewModel
    {
        public int PartnerId { get; set; }
        public PartnerViewModel Partner { get; set; }

        public int ServiceId { get; set; }
        public ServiceViewModel Service { get; set; }
    }
}
