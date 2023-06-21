using AutoMapper;
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
    public class CompanyService : ICompanyService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public CompanyService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<Company> CreateCompany(Company newCompany)
        {
            await _unitOfWork.Companies.AddAsync(newCompany);
            await _unitOfWork.CommitAsync();
            return newCompany;
        }

     

        public async Task DeleteCompany(Company company)
        {
            _unitOfWork.Companies.Remove(company);
            await _unitOfWork.CommitAsync();
        }

     

        public async Task<IEnumerable<Company>> GetAllCompanies()
        {
            return await _unitOfWork.Companies
                .GetAllWithCompaniesAsync();
        }

        public Task<IEnumerable<Company>> GetAllWithCompany()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Company>> GetCompaniesByCompanyId(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Company> GetCompanyById(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateCompany(Company companyToBeUpdated, Company company)
        {
            throw new NotImplementedException();
        }
      

    }
}
