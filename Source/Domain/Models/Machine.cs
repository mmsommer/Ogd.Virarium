using System.Collections.Generic;
using Ogd.Virarium.Common.Layering.Business;

namespace Ogd.Virarium.Domain.Models
{
    public class Machine : IIdentifiable
    {
        public virtual int Id { get; set; }

        public virtual string Name { get; set; }

        public virtual MachineType MachineType { get; set; }

        public virtual ICollection<Infection> Infections { get; set; }

        public virtual ICollection<NIC> NICs { get; set; }

        public virtual bool Archived { get; set; }
    }
}
