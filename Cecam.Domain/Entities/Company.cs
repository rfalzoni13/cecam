using Cecam.Domain.Entities.Base;

namespace Cecam.Domain.Entities
{
    public class Company : EntityBase
    {
        public string CompanyName { get; set; }

        public string DocumentNumber { get; set; }

        public string PhoneNumber { get; set; }
    }
}
