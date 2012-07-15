using Ogd.Virarium.Common.Layering.Business;

namespace Ogd.Virarium.Common.Layering.Presentation
{
    public interface IViewModel<T>
        where T : class, IIdentifiable, new()
    {
        int Id { get; set; }
    }
}
