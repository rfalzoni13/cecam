using System;

namespace Cecam.Domain.Entities.Base
{
    //Entidade base, pode-se utilizar para futuras inclusões
    public class EntityBase
    {
        public int Id { get; set; }

        public DateTime Created { get; set; }

        public DateTime? Modified { get; set; }

        public bool Active { get; set; }
    }
}
