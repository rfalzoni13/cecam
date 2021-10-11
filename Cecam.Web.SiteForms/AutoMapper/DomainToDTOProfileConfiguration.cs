using AutoMapper;
using Cecam.Domain.Entities;
using Cecam.Web.SiteForms.DTO;

namespace Cecam.Web.SiteForms.AutoMapper
{
    public class DomainToDTOProfileConfiguration : Profile
    {
        public DomainToDTOProfileConfiguration()
        {
            CreateMap<Company, CompanyDTO>();
        }
    }
}