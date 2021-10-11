using Cecam.Web.SiteForms.DTO.Base;

namespace Cecam.Web.SiteForms.DTO
{
    public class CompanyDTO : BaseDTO
    {
        public string CompanyName { get; set; }

        public string DocumentNumber { get; set; }

        public string PhoneNumber { get; set; }
    }
}