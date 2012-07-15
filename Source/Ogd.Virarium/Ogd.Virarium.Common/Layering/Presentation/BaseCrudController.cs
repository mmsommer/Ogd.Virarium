using System.Linq;
using System.Web.Mvc;
using Ogd.Virarium.Common.Layering.Business;
using Ogd.Virarium.Common.Layering.Service;

namespace Ogd.Virarium.Common.Layering.Presentation
{
    public abstract class BaseCrudController<TEntity, TViewModel> : BaseController
        where TEntity : class, IIdentifiable, new()
        where TViewModel : class, IViewModel<TEntity>, new()
    {
        public IService<TEntity> Service { get; protected set; }

        protected virtual void FillViewBag() { }

        protected virtual void CreateMaps() { }

        [HttpGet]
        public virtual ActionResult Index()
        {
            CreateMaps();
            var viewModel = Map<TEntity, TViewModel>(Service.GetAll().ToArray());

            return View(viewModel);
        }

        [HttpGet]
        public virtual ActionResult Details(int id)
        {
            CreateMaps();
            var viewModel = Map<TEntity, TViewModel>(Service.Find(id));

            return View(viewModel);
        }

        [HttpGet]
        public PartialViewResult DetailsRow(int id)
        {
            CreateMaps();
            var viewModel = Map<TEntity, TViewModel>(Service.Find(id));

            return PartialView(viewModel);
        }

        [HttpGet]
        public virtual ActionResult Create()
        {
            CreateMaps();
            var viewModel = Map<TEntity, TViewModel>(new TEntity());
            FillViewBag();

            return View(viewModel);
        }

        [HttpPost]
        public virtual ActionResult Create(TViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                CreateMaps();
                var entity = Map<TViewModel, TEntity>(viewModel);
                Service.Create(entity);

                return RedirectToAction("Details", new { id = entity.Id });
            }
            else
            {
                FillViewBag();
                return View(viewModel);
            }
        }

        [HttpGet]
        public virtual ActionResult Edit(int id)
        {
            CreateMaps();
            var viewModel = Map<TEntity, TViewModel>(Service.Find(id));
            FillViewBag();

            return View(viewModel);
        }

        [HttpPost]
        public virtual ActionResult Edit(TViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                CreateMaps();
                var model = Map<TViewModel, TEntity>(viewModel);
                Service.Update(model);

                return RedirectToAction("Details", new { id = model.Id });
            }
            else
            {
                FillViewBag();
                return View(viewModel);
            }
        }

        [HttpGet]
        public virtual ActionResult Delete(int id)
        {
            CreateMaps();
            var viewModel = Map<TEntity, TViewModel>(Service.Find(id));

            return View(viewModel);
        }

        [HttpPost]
        public virtual ActionResult Delete(TViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                CreateMaps();
                var model = Map<TViewModel, TEntity>(viewModel);
                Service.Delete(model);

                return RedirectToAction("Index");
            }
            else
            {
                return View(viewModel);
            }
        }

        [HttpGet]
        public virtual PartialViewResult DetailsRow()
        {
            CreateMaps();
            var viewModel = Map<TEntity, TViewModel>(Service.GetAll());
            FillViewBag();

            return PartialView(viewModel);
        }

        [HttpGet]
        public virtual PartialViewResult EditRow()
        {
            CreateMaps();
            var viewModel = Map<TEntity, TViewModel>(Service.GetAll());
            FillViewBag();

            return PartialView(viewModel);
        }
    }
}
