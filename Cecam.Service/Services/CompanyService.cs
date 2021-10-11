using Cecam.Domain.Entities;
using Cecam.Domain.Interfaces.Repository;
using Cecam.Domain.Interfaces.Service;
using Cecam.Service.Services.Base;

namespace Cecam.Service.Services
{
    public class CompanyService : ServiceBase<Company>, ICompanyService
    {
        private readonly ICompanyRepository _companyRepository;

        public CompanyService(ICompanyRepository companyRepository)
            :base(companyRepository)
        {
            _companyRepository = companyRepository;
        }
    }
}
