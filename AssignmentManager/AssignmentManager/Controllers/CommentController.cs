using AssignmentManager.Models;
using DataAccess.Entities;
using DataAccess.EntityFramework.Repositories;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AssignmentManager.Controllers
{
    public class CommentController : Controller
    {
        //
        // GET: /Comment/
        public ActionResult Index(int id)
        {
            List<Comment> comments = new List<Comment>();

            //string connectionString = ConfigurationManager.ConnectionStrings["AssignmentManagerDbConnectionString"].ConnectionString;

            CommentRepository commentRepository = new CommentRepository();

            comments = commentRepository.GetAll(comment => comment.AssignmentId == id);

            ViewBag.AssignmentId = id;

            var model = new CommentListViewModel();

            foreach (var comment in comments)
            {
                var tempModel = new CommentViewModel();
                tempModel.Id = comment.Id;
                tempModel.Content = comment.Content;
                tempModel.AssignmentId = comment.AssignmentId;

                model.Comments.Add(tempModel);
            }

            return View(model);
        }

        [HttpGet]
        public ActionResult Insert(int id)
        {
            var model = new CommentViewModel();
            model.AssignmentId = id;
            return View(model);
        }

        [HttpPost]
        public ActionResult Insert(CommentViewModel model)
        {
            //string connectionString = ConfigurationManager.ConnectionStrings["AssignmentManagerDbConnectionString"].ConnectionString;

            CommentRepository commentRepository = new CommentRepository();

            var entity = new Comment();
            entity.Id = model.Id;
            entity.Content = model.Content;
            entity.AssignmentId = model.AssignmentId;

            commentRepository.Insert(entity);

            return RedirectToAction("Index/"+ entity.AssignmentId);
        }

        [HttpGet]
        public ActionResult Update(int id)
        {
            //string connectionString = ConfigurationManager.ConnectionStrings["AssignmentManagerDbConnectionString"].ConnectionString;

            CommentRepository commentRepository = new CommentRepository();

            var entity = commentRepository.GetById(id);
            var model = new CommentViewModel();
            model.Id = entity.Id;
            model.Content = entity.Content;
            model.AssignmentId = entity.AssignmentId;

            return View(model);
        }

        [HttpPost]
        public ActionResult Update(CommentViewModel model)
        {
            //string connectionString = ConfigurationManager.ConnectionStrings["AssignmentManagerDbConnectionString"].ConnectionString;

            CommentRepository commentRepository = new CommentRepository();

            var entity = new Comment();
            entity.Id = model.Id;
            entity.Content = model.Content;
            entity.AssignmentId = model.AssignmentId;

            commentRepository.Update(entity);

            return RedirectToAction("Index/"+entity.AssignmentId);
        }

        public ActionResult Delete(int id)
        {
            //string connectionString = ConfigurationManager.ConnectionStrings["AssignmentManagerDbConnectionString"].ConnectionString;

            CommentRepository commentRepository = new CommentRepository();

            var entity = commentRepository.GetById(id);
            commentRepository.Delete(entity);

            return RedirectToAction("Index/" + entity.AssignmentId);
        }
	}
}