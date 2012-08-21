namespace Ogd.Virarium.Web.Models
{
    using Ogd.Virarium.Common.Layering.Presentation;
    using Ogd.Virarium.Domain.Models;

    public class ConnectionViewModel : IViewModel<Connection>
    {
        public int Id { get; set; }

        public NICViewModel PeerA { get; set; }

        public NICViewModel PeerB { get; set; }
    }
}
