using IDS.Core.Interfaces;
using IDS.Core.Models;
using IDS.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDS.Services
{
    public class ReservationService : IReservationService
    {
        private readonly IUnitOfWork _unitOfWork;
        public ReservationService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<Reservation> CreateReservation(Reservation newReservation)
        {
            await _unitOfWork.Reservations.AddAsync(newReservation);
            await _unitOfWork.CommitAsync();
            return newReservation;
        }

      

        public async Task DeleteReservation(Reservation reservation )
        {
            _unitOfWork.Reservations.Remove(reservation);
            await _unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<Reservation>> GetAllReservations()
        {
            return await _unitOfWork.Reservations
                .GetAllWithReservationsAsync();
        }

        public Task<IEnumerable<Reservation>> GetReservationsByReservationId(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Reservation> GetReservationById(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateReservation(Reservation reservationToBeUpdated, Reservation reservation)
        {
            throw new NotImplementedException();
        }

        Task<Reservation> IReservationService.GetReservationById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Reservation>> GetUsersByUserId(int id)
        {
            throw new NotImplementedException();
        }

     
        public Task UpdateReservation(Reservation reservationToBeUpdated, Role reservation)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Reservation>> GetAllWithReservation()
        {
            throw new NotImplementedException();
        }
    }
}
