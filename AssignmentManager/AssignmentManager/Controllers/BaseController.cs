using AssignmentManager.Models;
using DataAccess.Entities;
using DataAccess.EntityFramework.Repositories;
using ServiceLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;

namespace AssignmentManager.Controllers
{
    public abstract class BaseController<TEntity, TViewModel, TListViewModel, TService> : Controller
        where TEntity : BaseEntity
        where TViewModel : BaseViewModel
        where TListViewModel : BaseListViewModel<TViewModel>, new()
        where TService : BaseService<TEntity>
    {
        private BaseService<TEntity> _service;

        public BaseController()
        {
            _service = new BaseService<TEntity>(GetRepository());
        }

        public BaseController(BaseService<TEntity> service)
        {
            _service = service;
        }

        public abstract BaseRepository<TEntity> GetRepository();

        public abstract TViewModel GetViewModel();

        public abstract TEntity GetEntity();

        public abstract void MapEntityToViewModel(TEntity entity, TViewModel viewModel);

        public abstract void MapViewModelToEntity(TViewModel viewModel, TEntity entity);

        public abstract string GetRedirectUrl(TEntity entity);

        public virtual void OnBeforeList(TListViewModel model, int? id) { }

        public virtual void OnBeforeInsert(TViewModel viewModel, int? id) { }

        public virtual Expression<Func<TEntity, bool>> GetGetAllFilter(TListViewModel viewModel)
        {
            return x => true;
        }

        public ActionResult Index(int? id)
        {
            var entityList = new List<TEntity>();

            //USED FOR ADO.NET not needed for Entity Framework

            //string connectionString = ConfigurationManager.ConnectionStrings["AssignmentManagerDbConnectionString"].ConnectionString;

            var listViewModel = new TListViewModel();

            OnBeforeList(listViewModel, id);

            entityList = _service.GetAll(GetGetAllFilter(listViewModel));

            foreach (var entity in entityList)
            {
                var viewModel = GetViewModel();

                MapEntityToViewModel(entity, viewModel);

                listViewModel.EntryList.Add(viewModel);
            }

            return View(listViewModel);
        }

        [HttpGet]
        public ActionResult Insert(int? id)
        {
            var viewModel = GetViewModel();

            OnBeforeInsert(viewModel, id);

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Insert(TViewModel model)
        {
            //USED FOR ADO.NET not needed for Entity Framework

            //string connectionString = ConfigurationManager.ConnectionStrings["AssignmentManagerDbConnectionString"].ConnectionString;

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var entity = GetEntity();

            MapViewModelToEntity(model, entity);

            _service.Save(entity);

            return RedirectToAction(GetRedirectUrl(entity));
        }

        [HttpGet]
        public ActionResult Update(int id)
        {
            //USED FOR ADO.NET not needed for Entity Framework

            //string connectionString = ConfigurationManager.ConnectionStrings["AssignmentManagerDbConnectionString"].ConnectionString;

            var entity = _service.GetById(id);

            var viewModel = GetViewModel();

            MapEntityToViewModel(entity, viewModel);

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Update(TViewModel viewModel)
        {
            //USED FOR ADO.NET not needed for Entity Framework

            //string connectionString = ConfigurationManager.ConnectionStrings["AssignmentManagerDbConnectionString"].ConnectionString;

            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            var entity = _service.GetById(viewModel.Id);

            MapViewModelToEntity(viewModel, entity);

            _service.Save(entity);

            return RedirectToAction(GetRedirectUrl(entity));
        }

        public ActionResult Delete(int id)
        {
            //USED FOR ADO.NET not needed for Entity Framework

            //string connectionString = ConfigurationManager.ConnectionStrings["AssignmentManagerDbConnectionString"].ConnectionString;

            var entity = _service.GetById(id);
            _service.Delete(entity);

            return RedirectToAction(GetRedirectUrl(entity));
        }
	}
}