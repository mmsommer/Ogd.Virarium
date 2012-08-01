using Ogd.Virarium.Common.Layering.Business;

namespace Ogd.Virarium.Domain.Models
{
    public class Connection : IIdentifiable
    {
        public virtual int Id { get; set; }

        public virtual NIC PeerA { get; set; }

        public virtual NIC PeerB { get; set; }
    }
}
