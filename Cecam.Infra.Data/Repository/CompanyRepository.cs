using Cecam.Domain.Entities;
using Cecam.Domain.Interfaces.Repository;
using Cecam.Infra.Data.Repository.Base;

namespace Cecam.Infra.Data.Repository
{
    public class CompanyRepository : RepositoryBase<Company>, ICompanyRepository
    {
    }
}
