[assembly: WebActivator.PreApplicationStartMethod(typeof(Ogd.Virarium.Web.App_Start.ElmahMvc), "Start")]
namespace Ogd.Virarium.Web.App_Start
{
    public class ElmahMvc
    {
        public static void Start()
        {
            Elmah.Mvc.Bootstrap.Initialize();
        }
    }
}