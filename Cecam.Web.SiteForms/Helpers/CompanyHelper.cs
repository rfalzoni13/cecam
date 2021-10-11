using AutoMapper;
using Cecam.Domain.Entities;
using Cecam.Domain.Interfaces.Service;
using Cecam.Web.SiteForms.AutoMapper;
using Cecam.Web.SiteForms.DTO;
using System;
using System.Collections.Generic;

namespace Cecam.Web.SiteForms.Helpers
{
    public static class CompanyHelper
    {
        private static IMapper Mapper = AutoMapperConfiguration.RegisterMappings();

        public static IEnumerable<CompanyDTO> ListCompanies(ICompanyService companyService)
        {
            var companies = companyService.GetAll();

            var companiesDTO = Mapper.Map<IEnumerable<Company>, IEnumerable<CompanyDTO>>(companies);

            return companiesDTO;
        }

        public static CompanyDTO GetCompanyById(ICompanyService companyService, int id)
        {
            var company = companyService.GetById(id);

            var companyDTO = Mapper.Map<Company, CompanyDTO>(company);

            return companyDTO;
        }

        public static void AddLineGridView(ICompanyService companyService, CompanyDTO companyDTO)
        {
            var company = VerifyAndMapperCompany(companyDTO);

            companyService.Add(company);
        }

        public static void UpdateLineGridView(ICompanyService companyService, CompanyDTO companyDTO)
        {
            var company = VerifyAndMapperCompany(companyDTO);
            if (company.Id > 0)
            {
                //Caso seja uma atualização, a data de criação não poderá ser alterada, neste caso será repassado
                //a data para o novo objeto!
                var oldCompany = companyService.GetById(company.Id);
                company.Created = oldCompany.Created;
            }

            //Devido a um problema com Attach Object, foi feita uma "adaptação" para fazer a pesquisa do objeto e atualizá-lo
            //no repositório
            companyService.Update(company.Id, company);
        }

        public static void DeleteLineGridView(ICompanyService companyService, int id)
        {
            var company = companyService.GetById(id);

            companyService.Delete(company);
        }

        private static Company VerifyAndMapperCompany(CompanyDTO companyDTO)
        {
            if (companyDTO == null)
            {
                throw new ArgumentNullException("O objeto está vazio!");
            }

            var company = Mapper.Map<CompanyDTO, Company>(companyDTO);

            return company;
        }
    }
}