using AutoMapper;
using Cecam.Domain.Entities;
using Cecam.Web.SiteForms.DTO;

namespace Cecam.Web.SiteForms.AutoMapper
{
    public class DTOToDomainProfileConfiguration : Profile
    {
        public DTOToDomainProfileConfiguration()
        {
            CreateMap<CompanyDTO, Company>();
        }
    }
}