using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataAccess.Entities;
using DataAccess.EntityFramework.Repositories;

namespace AssignmentManager.Controllers
{
    public abstract class BaseController<T, Y, Z> : Controller
        where T : BaseEntity
        where Y : BaseViewModel
        where Z : BaseListViewModel
    {

        protected abstract Expression<Func<T, bool>> GetAllFilter { get; set; }

        protected abstract void MapEntityToModel(T entity, Y model);

        protected abstract void MapModelToEntity(Y model, T entity);

        protected abstract string GetRedirectPath(T entity);

        public ActionResult Index(int id)
        {
            List<T> comments = new List<T>();

            //string connectionString = ConfigurationManager.ConnectionStrings["AssignmentManagerDbConnectionString"].ConnectionString;

            BaseRepository<T> baseRepository = new BaseRepository<T>();

            comments = baseRepository.GetAll(getAllFilter);
            
            var model = new Z();

            foreach (var comment in comments)
            {
                var tempModel = new Y();

                MapEntityToModel(comment, tempModel);

                model.List.Add(tempModel);
            }

            return View(model);
        }

        [HttpGet]
        public ActionResult Insert()
        {
            var model = new Y();

            return View(model);
        }

        [HttpPost]
        public ActionResult Insert(Y model)
        {
            //string connectionString = ConfigurationManager.ConnectionStrings["AssignmentManagerDbConnectionString"].ConnectionString;

            BaseRepository<T> baseRepository = new BaseRepository<T>();

            var entity = new T();

            MapModelToEntity(model, entity);

            baseRepository.Insert(entity);

            return RedirectToAction(GetRedirectPath(entity));
        }

        [HttpGet]
        public ActionResult Update(int id)
        {
            //string connectionString = ConfigurationManager.ConnectionStrings["AssignmentManagerDbConnectionString"].ConnectionString;

            BaseRepository<T> baseRepository = new BaseRepository<T>();

            var entity = baseRepository.GetById(id);
            var model = new Y();

            MapEntityToModel(entity, model);

            return View(model);
        }

        [HttpPost]
        public ActionResult Update(CommentViewModel model)
        {
            //string connectionString = ConfigurationManager.ConnectionStrings["AssignmentManagerDbConnectionString"].ConnectionString;

            BaseRepository<T> baseRepository = new BaseRepository<T>();

            var entity = new T();
            entity.Id = model.Id;
            entity.Content = model.Content;
            entity.AssignmentId = model.AssignmentId;

            baseRepository.Update(entity);

            return RedirectToAction(GetRedirectPath(entity));
        }

        public ActionResult Delete(int id)
        {
            //string connectionString = ConfigurationManager.ConnectionStrings["AssignmentManagerDbConnectionString"].ConnectionString;

            BaseRepository<T> baseRepository = new BaseRepository<T>();

            var entity = baseRepository.GetById(id);
            baseRepository.Delete(entity);

            return RedirectToAction(GetRedirectPath(entity));
        }
    }
}