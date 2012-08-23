using Ogd.Virarium.Common.Layering.Business;

namespace Ogd.Virarium.Domain.Models
{
    public class NIC : IIdentifiable
    {
        public virtual int Id { get; set; }

        public virtual Connection Connection { get; set; }

        public virtual string MacAddress { get; set; }

        public virtual Machine Machine { get; set; }

        public virtual VLan VLan { get; set; }
    }
}
