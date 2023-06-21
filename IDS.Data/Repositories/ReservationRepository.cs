using IDS.Core.Interfaces;
using IDS.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace IDS.Data.Repositories
{
    public class ReservationRepository : Repository<Company>, IReservationRepository
    {
        public ReservationRepository(IDSDbContext context)
            : base(context)
        { }

        public async Task<IEnumerable<Reservation>> GetAllWithReservationAsync()
        {
            return await IDSDbContext.Reservations
                //.Include(m => m.Company)
                .ToListAsync();
        }

        public async Task<Reservation> GetWithReservationByIdAsync(int id)
        {
            return await IDSDbContext.Reservations
                //.Include(m => m.Company)
                .SingleOrDefaultAsync(m => m.Id == id); ;
        }

        public async Task<IEnumerable<Reservation>> GetAllWithReservationByReservationIdAsync(int reservationId)
        {
            return await IDSDbContext.Reservations
                //.Include(m => m.Company)
                //   .Where(m => m.CompanyId == companyId)
                .ToListAsync();
        }

        public Task<IEnumerable<Reservation>> GetAllWithReservationsAsync()
        {
            throw new NotImplementedException();
        }



        public Task<IEnumerable<Company>> GetAllWithCompaniesByCompanyIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Reservation>> GetAllWithReservationsByCompanyIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        ValueTask<Reservation> IRepository<Reservation>.GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<Reservation>> IRepository<Reservation>.GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Reservation> Find(Expression<Func<Reservation, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<Reservation> SingleOrDefaultAsync(Expression<Func<Reservation, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task AddAsync(Reservation entity)
        {
            throw new NotImplementedException();
        }

        public Task AddRangeAsync(IEnumerable<Reservation> entities)
        {
            throw new NotImplementedException();
        }

        public void Remove(Reservation entity)
        {
            throw new NotImplementedException();
        }

        public void RemoveRange(IEnumerable<Reservation> entities)
        {
            throw new NotImplementedException();
        }

        public Task<Reservation> GetWithReservationsByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        private IDSDbContext IDSDbContext
        {
            get { return Context as IDSDbContext; }
        }
    }
}
