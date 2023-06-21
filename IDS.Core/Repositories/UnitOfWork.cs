using IDS.Core.Interfaces;
using IDS.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDS.Core.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDSbookingSystemContext _context;
        private CompanyRepository _companyRepository;
   
        public UnitOfWork(IDSbookingSystemContext context)
        {
            this._context = context;
        }

        public ICompanyRepository Companies => _companyRepository = _companyRepository ?? new CompanyRepository(_context);

        public ICompanyRepository Musics => throw new NotImplementedException();

        public IReservationRepository Reservations => throw new NotImplementedException();

        public IRoleRepository Roles => throw new NotImplementedException();

        public IRoomRepository Rooms => throw new NotImplementedException();

        public IUserRepository Users => throw new NotImplementedException();

        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}