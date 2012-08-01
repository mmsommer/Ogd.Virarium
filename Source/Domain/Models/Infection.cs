using System;
using Ogd.Virarium.Common.Layering.Business;

namespace Ogd.Virarium.Domain.Models
{
    public class Infection : IIdentifiable
    {
        public virtual int Id { get; set; }

        public virtual Machine Machine { get; set; }

        public virtual Virus Virus { get; set; }

        public virtual DateTime Start { get; set; }

        public virtual DateTime? End { get; set; }
    }
}
