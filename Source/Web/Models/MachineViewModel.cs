namespace Ogd.Virarium.Web.Models
{
    using System.Collections.Generic;
    using Ogd.Virarium.Common.Layering.Presentation;
    using Ogd.Virarium.Domain.Models;

    public class MachineViewModel : IViewModel<Machine>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public MachineType MachineType { get; set; }

        public IEnumerable<InfectionViewModel> Infections { get; set; }

        public IEnumerable<NICViewModel> NICs { get; set; }
    }
}