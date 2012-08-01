namespace Ogd.Virarium.Common.Layering.Presentation
{
    using System;
    using System.Collections.Generic;
    using System.Web.Mvc;
    using AutoMapper;

    [Authorize]
    public abstract class BaseController : Controller
    {
        public void CreateMap<U, V>()
        {
            Mapper.CreateMap<U, V>();
        }

        public IEnumerable<V> Map<U, V>(IEnumerable<U> source)
        {
            if(source == null)
            {
                throw new ArgumentNullException("source");
            }

            CreateMap<U, V>();
            return Mapper.Map<IEnumerable<V>>(source);
        }

        public V Map<U, V>(U source)
        {
            if(source == null)
            {
                throw new ArgumentNullException("source");
            }

            CreateMap<U, V>();
            return Mapper.Map<V>(source);
        }
    }
}