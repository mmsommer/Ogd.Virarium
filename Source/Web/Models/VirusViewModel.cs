namespace Ogd.Virarium.Web.Models
{
    using System.Collections.Generic;
    using Ogd.Virarium.Common.Layering.Presentation;
    using Ogd.Virarium.Domain.Models;

    public class VirusViewModel : IViewModel<Virus>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public IEnumerable<Infection> Infections { get; set; }
    }
}
