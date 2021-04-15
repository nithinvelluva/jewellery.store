using Jewellery.Store.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Jewellery.Store.DAL.DBContext;
using Microsoft.EntityFrameworkCore;

namespace Jewellery.Store.DAL.Repository
{
  public class AppointmentRepository : BaseRepository<AppointmentEntity>, IAppointmentRepository
  {
    public AppointmentRepository(MainDbContext dbContext) : base(dbContext)
    {
    }

    public override Task<long> DeleteAsync(long id)
    {
      throw new NotImplementedException();
    }

    public override IEnumerable<AppointmentEntity> GetAsync()
    {
      throw new NotImplementedException();
    }

    public override AppointmentEntity GetAsync(long id)
    {
      throw new NotImplementedException();
    }
    public override async Task<long> InsertAsync(AppointmentEntity data)
    {
      if (data == null) return 0;
      var appointment = new AppointmentEntity
      {
        pet_id = data.pet_id,
        slot_from = data.slot_from,
        slot_to = data.slot_to,
        notes = data.notes
      };
      _dbContext.Appointments.Add(appointment);
      await _dbContext.SaveChangesAsync();
      return appointment.id;
    }

    public override async Task<bool> UpdateAsync(AppointmentEntity data)
    {
      if (data == null) return false;
      var appointment = _dbContext.Appointments.Find(data.id);
      if (appointment != null)
      {
        appointment.pet_id = data.pet_id;
        appointment.slot_from = data.slot_from;
        appointment.slot_to = data.slot_to;
        appointment.notes = data.notes;
      }
      await _dbContext.SaveChangesAsync();
      return true;
    }

    public IEnumerable<AppointmentEntity> GetByDate(int year, int month, int date)
    {
      var dateVal = $"{ year }-{ PadZero(month)}-{ PadZero(date)}";
      var appointments = from app in _dbContext.Appointments
                          join pet in _dbContext.Pets on app.pet_id equals pet.id
                          join owner in _dbContext.Owners on pet.owner_id equals owner.id
                          where EF.Functions.Like(app.slot_from, dateVal)
                          select new AppointmentEntity
                          {
                            pet_id = pet.id,
                            pet_type = pet.type,
                            pet_name = pet.name,
                            pet_age = pet.age,

                            owner_id = owner.id,
                            owner_first_name = owner.first_name,
                            owner_last_name = owner.last_name

                          };

      return appointments.ToList();
    }

    public Dictionary<DateTime, int> GetMonthlySummary(int year, int month)
    {
      var startDate = new DateTime(year, month + 1, 1);
      var endDate = new DateTime(year, month + 1, DateTime.DaysInMonth(year, month + 1));

      var start = Convert.ToDateTime(startDate.ToString("yyyy-MM-dd"));
      var end = Convert.ToDateTime(endDate.ToString("yyyy-MM-dd"));

      var result = _dbContext.Appointments
                         .GroupBy(a => a.slot_from.Substring(0, 10))
                         .Select(g => new
                         {
                           g.Key,
                           Value = g.Count()
                         })                         
                         .OrderBy(g => g.Value)
                         .ToList();
      var data = new Dictionary<DateTime, int>();
      if (result != null)
      {
        foreach (var g in result)
        {
          var date = Convert.ToDateTime(g.Key);
          if (date >= start && date <= end)
          {
            data.Add(date, g.Value);
          }
        }
      }
      return data;
    }

    private string PadZero(int number) => number.ToString("D2");
  }
}
