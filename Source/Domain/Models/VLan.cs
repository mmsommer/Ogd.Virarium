namespace Ogd.Virarium.Domain.Models
{
    using System.Collections.Generic;
    using Ogd.Virarium.Common.Layering.Business;

    public class VLan : IIdentifiable
    {
        public virtual int Id { get; set; }

        public virtual string Name { get; set; }

        public virtual ICollection<NIC> NICs { get; set; }
    }
}
