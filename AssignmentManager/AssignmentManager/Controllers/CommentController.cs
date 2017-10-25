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

            return View(comments);
        }

        [HttpGet]
        public ActionResult Insert(int id)
        {
            var entity = new Comment();
            entity.AssignmentId = id;
            return View(entity);
        }

        [HttpPost]
        public ActionResult Insert(Comment entity)
        {
            //string connectionString = ConfigurationManager.ConnectionStrings["AssignmentManagerDbConnectionString"].ConnectionString;

            CommentRepository commentRepository = new CommentRepository();

            commentRepository.Insert(entity);

            return RedirectToAction("Index/"+ entity.AssignmentId);
        }

        [HttpGet]
        public ActionResult Update(int id)
        {
            //string connectionString = ConfigurationManager.ConnectionStrings["AssignmentManagerDbConnectionString"].ConnectionString;

            CommentRepository commentRepository = new CommentRepository();

            var entity = commentRepository.GetById(id);

            return View(entity);
        }

        [HttpPost]
        public ActionResult Update(Comment entity)
        {
            //string connectionString = ConfigurationManager.ConnectionStrings["AssignmentManagerDbConnectionString"].ConnectionString;

            CommentRepository commentRepository = new CommentRepository();

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