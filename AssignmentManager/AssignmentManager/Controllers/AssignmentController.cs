using DataAccess.Entities;
using DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AssignmentManager.Controllers
{
    public class AssignmentController : Controller
    {
        //
        // GET: /Assignment/
        public ActionResult Index()
        {
            List<Assignment> assignments = new List<Assignment>();

            string connectionString = ConfigurationManager.ConnectionStrings["AssignmentManagerDbConnectionString"].ConnectionString;

            AssignmentRepository assignmentRepository = new AssignmentRepository(connectionString);

            assignments = assignmentRepository.GetAll();

            return View(assignments);
        }

        [HttpGet]
        public ActionResult Insert()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Insert(Assignment entity)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["AssignmentManagerDbConnectionString"].ConnectionString;

            AssignmentRepository assignmentRepository = new AssignmentRepository(connectionString);

            assignmentRepository.Insert(entity); 

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Update(int id)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["AssignmentManagerDbConnectionString"].ConnectionString;

            AssignmentRepository assignmentRepository = new AssignmentRepository(connectionString);

            var entity = assignmentRepository.GetById(id);

            return View(entity);
        }

        [HttpPost]
        public ActionResult Update(Assignment entity)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["AssignmentManagerDbConnectionString"].ConnectionString;

            AssignmentRepository assignmentRepository = new AssignmentRepository(connectionString);

            assignmentRepository.Update(entity);

            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["AssignmentManagerDbConnectionString"].ConnectionString;

            AssignmentRepository assignmentRepository = new AssignmentRepository(connectionString);

            assignmentRepository.Delete(id);

            return RedirectToAction("Index");
        }
	}
}