namespace Ogd.Virarium.Web.Models
{
    using System;
    using Ogd.Virarium.Common.Layering.Presentation;
    using Ogd.Virarium.Domain.Models;

    public class InfectionViewModel : IViewModel<Infection>
    {
        public int Id { get; set; }

        public MachineViewModel Machine { get; set; }

        public VirusViewModel Virus { get; set; }

        public DateTime Start { get; set; }

        public DateTime? End { get; set; }
    }
}
