using Cecam.Domain.Entities;
using Cecam.Domain.Interfaces.Service;
using Cecam.Infra.Data.Context;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Data.Entity;

namespace Cecam.Tests.Service.Service
{
    /// <summary>
    /// Descrição resumida para CompanyServiceTest
    /// </summary>
    [TestClass]
    public class CompanyServiceTest
    {
        private Mock<ICompanyService> _companyService;
        private Company _company;

        [TestInitialize]
        public void InitializeTest()
        {            
            _companyService = new Mock<ICompanyService>();

            _company = new Company
            {
                Id = 1,
                CompanyName = "Empresa de teste ltda.",
                DocumentNumber = "45.228.074/0001-86",
                Created = DateTime.Now,
                Active = true,
                PhoneNumber = "(11) 3622-4552"
            };

            _companyService.Setup(x => x.GetById(It.IsAny<int>())).Returns(_company);
            
            _companyService.Setup(x => x.Add(_company)).Verifiable();
            _companyService.Setup(x => x.Update(_company.Id, _company)).Verifiable();
            _companyService.Setup(x => x.Delete(_company)).Verifiable();
        }

        [TestMethod]
        public void GetCompanyById_ReturnSuccess()
        {
            int id = 1;

            var company = _companyService.Object.GetById(id);

            Assert.AreEqual(_company, company);
            Assert.AreEqual(_company.Id, id);
            Assert.AreNotEqual(_company, null);
        }

        [TestMethod]
        public void GetCompanyById_ReturnNotFound()
        {
            int id = 1;

            _company = new Company
            {
                Id = 2,
                CompanyName = "Empresa de teste ME.",
                DocumentNumber = "92.552.474/0001-55",
                Created = DateTime.Now,
                Active = false,
                PhoneNumber = "(21) 4532-1215"
            };

            var company = _companyService.Object.GetById(id);

            Assert.AreNotEqual(_company, company);
            Assert.AreNotEqual(_company.Id, id);
            Assert.AreEqual(_company.Id, 2);
            
        }

        [TestMethod]
        public void InsertCompany_Success()
        {
            var company = _company;

            _companyService.Object.Add(company);

            _companyService.Verify(x => x.Add(It.Is<Company>(y => y == _company)));
            _companyService.Verify(x => x.Add(It.Is<Company>(y => y != new Company())));
        }

        [TestMethod]
        public void InsertCompany_Error()
        {
            var company = new Company();

            _companyService.Object.Add(company);

            _companyService.Verify(x => x.Add(It.Is<Company>(y => y != _company)));
            _companyService.Verify(x => x.Add(It.Is<Company>(y => y == company)));
        }

        [TestMethod]
        public void UpdateCompany_Success()
        {
            var company = new Company
            {
                Id = 1,
                CompanyName = "Empresa de teste SA.",
                DocumentNumber = "55.942.313/0001-20",
                Created = DateTime.Now,
                Modified = DateTime.Now,
                Active = false,
                PhoneNumber = "(21) 4532-1215"
            };

            _companyService.Object.Update(_company.Id, company);

            _companyService.Verify(x => x.Update(It.IsAny<int>(), It.Is<Company>(y => y == company)));
            _companyService.Verify(x => x.Update(It.IsAny<int>(), It.Is<Company>(y => y != _company)));
            _companyService.Verify(x => x.Update(It.IsAny<int>(), It.Is<Company>(y => y != new Company())));
        }

        [TestMethod]
        public void UpdateCompany_Error()
        {
            var company = new Company();

            _companyService.Object.Update(2, _company);

            _companyService.Verify(x => x.Update(It.IsAny<int>(), It.Is<Company>(y => y == _company)));
            _companyService.Verify(x => x.Update(It.IsAny<int>(), It.Is<Company>(y => y != company)));
        }

        [TestMethod]
        public void DeleteCompany_Success()
        {
            var company = _company;

            _companyService.Object.Delete(company);

            _companyService.Verify(x => x.Delete(It.Is<Company>(y => y == _company)));
            _companyService.Verify(x => x.Delete(It.Is<Company>(y => y != new Company())));
        }

        [TestMethod]
        public void DeleteCompany_Error()
        {
            var company = new Company();

            _companyService.Object.Delete(company);

            _companyService.Verify(x => x.Delete(It.Is<Company>(y => y != _company)));
            _companyService.Verify(x => x.Delete(It.Is<Company>(y => y == company)));
        }
    }
}
