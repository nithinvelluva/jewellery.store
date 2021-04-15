using Jewellery.Store.DAL.Entity;
using System;
using System.Globalization;

namespace Jewellery.Store.ViewModels.Mapper
{
    public class AppointmentMapper : BaseMapper<AppointmentEntity, AppointmentViewModel>, IAppointmentMapper
    {
        private const string _inboundDateFormat = "yyyy-M-dTH:m:s";
        private const string _dateFormat = "yyyy-MM-ddTHH:mm:ss";
        public override AppointmentEntity Decode(AppointmentViewModel data) => new AppointmentEntity
        {
            id = data.Id,
            notes = data.Notes,
            pet_id = data.PetId,
            slot_from = DecodeDate(data.SlotFrom),
            slot_to = DecodeDate(data.SlotTo)
        };

        public override AppointmentViewModel Encode(AppointmentEntity data) =>
        new AppointmentViewModel
        {
            Id = data.id,
            Notes = data.notes,
            PetId = data.pet_id,
            SlotFrom = data.slot_from,
            SlotTo = data.slot_to,
            OwnerId = data.owner_id,
            Pet = new PetViewModel
            {
                Id = data?.pet_id ?? 0,
                Age = data?.pet_age ?? 0,
                Name = data?.pet_name ?? "",
                OwnerId = data.owner_id ?? 0,
                Type = data?.pet_type ?? ""
            },
            Owner = new OwnerViewModel
            {
                Id = data?.owner_id ?? 0,
                FirstName = data?.owner_first_name,
                LastName = data?.owner_last_name
            }
        };

        private string DecodeDate(string date) => DateTime.ParseExact(date, _inboundDateFormat, CultureInfo.InvariantCulture).ToString(_dateFormat);
    }

    public interface IAppointmentMapper : IMapper<AppointmentEntity, AppointmentViewModel> { }
}
