namespace Ogd.Virarium.Web.Models
{
    using Ogd.Virarium.Common.Layering.Presentation;
    using Ogd.Virarium.Domain.Models;

    public class NICViewModel : IViewModel<NIC>
    {
        public int Id { get; set; }

        public ConnectionViewModel Connection { get; set; }

        public string MacAddress { get; set; }

        public MachineViewModel Machine { get; set; }

        public VLanViewModel VLan { get; set; }
    }
}
