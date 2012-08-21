namespace Ogd.Virarium.Web.Models.Home
{
    using System.Collections.Generic;

    public class IndexViewModel
    {
        public IEnumerable<MachineViewModel> Machines { get; set; }
    }
}