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
    public class AssignmentController : Controller
    {
        //
        // GET: /Assignment/
        public ActionResult Index()
        {
            List<Assignment> assignments = new List<Assignment>();
            
            //USED FOR ADO.NET not needed for Entity Framework

            //string connectionString = ConfigurationManager.ConnectionStrings["AssignmentManagerDbConnectionString"].ConnectionString;

            AssignmentRepository assignmentRepository = new AssignmentRepository();

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
            //USED FOR ADO.NET not needed for Entity Framework

            //string connectionString = ConfigurationManager.ConnectionStrings["AssignmentManagerDbConnectionString"].ConnectionString;

            AssignmentRepository assignmentRepository = new AssignmentRepository();

            assignmentRepository.Insert(entity); 

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Update(int id)
        {
            //USED FOR ADO.NET not needed for Entity Framework

            //string connectionString = ConfigurationManager.ConnectionStrings["AssignmentManagerDbConnectionString"].ConnectionString;

            AssignmentRepository assignmentRepository = new AssignmentRepository();

            var entity = assignmentRepository.GetById(id);

            return View(entity);
        }

        [HttpPost]
        public ActionResult Update(Assignment entity)
        {
            //USED FOR ADO.NET not needed for Entity Framework

            //string connectionString = ConfigurationManager.ConnectionStrings["AssignmentManagerDbConnectionString"].ConnectionString;

            AssignmentRepository assignmentRepository = new AssignmentRepository();

            assignmentRepository.Update(entity);

            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            //USED FOR ADO.NET not needed for Entity Framework

            //string connectionString = ConfigurationManager.ConnectionStrings["AssignmentManagerDbConnectionString"].ConnectionString;

            AssignmentRepository assignmentRepository = new AssignmentRepository();
            var entity = assignmentRepository.GetById(id);
            assignmentRepository.Delete(entity);

            return RedirectToAction("Index");
        }
	}
}