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
	}
}