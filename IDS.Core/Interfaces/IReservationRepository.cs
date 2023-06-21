using IDS.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDS.Core.Interfaces
{
    public interface IReservationRepository : IRepository<Reservation>
    {

        Task<IEnumerable<Reservation>> GetAllWithReservationsAsync();
        Task<Reservation> GetWithReservationsByIdAsync(int id);
        Task<IEnumerable<Reservation>> GetAllWithReservationsByCompanyIdAsync(int id);
    }
}
