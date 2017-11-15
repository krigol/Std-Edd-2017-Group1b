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

            var model = new AssignmentListViewModel();
            model.Title = "Assignment Manager List Screen";
            
            foreach (var assignment in assignments)
            {
                var tempModel = new AssignmentViewModel();
                tempModel.Id = assignment.Id;
                tempModel.Title = assignment.Title;
                tempModel.Description = assignment.Description;
                tempModel.IsDone = assignment.IsDone;

                model.Assignments.Add(tempModel);
            }

            return View(model);
        }

        [HttpGet]
        public ActionResult Insert()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Insert(AssignmentViewModel model)
        {
            //USED FOR ADO.NET not needed for Entity Framework

            //string connectionString = ConfigurationManager.ConnectionStrings["AssignmentManagerDbConnectionString"].ConnectionString;

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            AssignmentRepository assignmentRepository = new AssignmentRepository();

            var entity = new Assignment();

            entity.Title = model.Title;
            entity.Description = model.Description;
            entity.IsDone = model.IsDone;
            
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

            var model = new AssignmentViewModel 
            {
                Id = entity.Id,
                Title = entity.Title,
                Description = entity.Description,
                IsDone = entity.IsDone
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult Update(AssignmentViewModel model)
        {
            //USED FOR ADO.NET not needed for Entity Framework

            //string connectionString = ConfigurationManager.ConnectionStrings["AssignmentManagerDbConnectionString"].ConnectionString;

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            AssignmentRepository assignmentRepository = new AssignmentRepository();

            var entity = assignmentRepository.GetById(model.Id);

            entity.Title = model.Title;
            entity.Description = model.Description;
            entity.IsDone = model.IsDone;
            
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