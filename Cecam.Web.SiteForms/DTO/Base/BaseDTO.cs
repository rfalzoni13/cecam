using System;

namespace Cecam.Web.SiteForms.DTO.Base
{
    public class BaseDTO
    {
        public int Id { get; set; }

        public DateTime Created { get; set; }

        public DateTime? Modified { get; set; }

        public bool Active { get; set; }

    }
}