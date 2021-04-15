using Jewellery.Store.ViewModels.Models;

namespace Jewellery.Store.ViewModels
{
    public class AppointmentViewModel : BaseViewModel
    {
        public long? OwnerId { get; set; }
        public long PetId { get; set; }

        public string SlotFrom { get; set; }
        public string SlotTo { get; set; }

        public string Notes { get; set; }

        public PetViewModel Pet { get; set; }
        public OwnerViewModel Owner { get; set; }
    }
}
