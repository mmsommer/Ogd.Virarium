namespace Ogd.Virarium.Common.Layering.Presentation
{
    using Ogd.Virarium.Common.Layering.Business;

    public interface IViewModel<T>
          where T : class, IIdentifiable, new()
    {
        int Id { get; set; }
    }
}
