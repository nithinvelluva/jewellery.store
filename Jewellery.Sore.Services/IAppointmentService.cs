using Jewellery.Store.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Jewellery.Store.Services
{
  public interface IAppointmentService
    {
    IEnumerable<AppointmentViewModel> GetByDate(int year, int month, int date);
    IEnumerable<AppointmentViewModel> GetMonthSummary(int year, int month);
    Task<AppointmentViewModel> Save(AppointmentViewModel appointment);
    Task<AppointmentViewModel> GetById(int id);
    Task<bool> DeleteAsync(long id);
  }
}
