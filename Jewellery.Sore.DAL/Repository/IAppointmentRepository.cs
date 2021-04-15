using Jewellery.Store.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Jewellery.Store.DAL.Repository
{
  public interface IAppointmentRepository: IRepository<AppointmentEntity>
  {
    IEnumerable<AppointmentEntity> GetByDate(int year, int month, int date);
    Dictionary<DateTime, int> GetMonthlySummary(int year, int month);
  }
}
