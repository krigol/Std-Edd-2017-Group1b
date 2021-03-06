﻿using AssignmentManager.Models;
using DataAccess.Entities;
using DataAccess.EntityFramework.Repositories;
using ServiceLayer;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AssignmentManager.Controllers
{
    public class AssignmentController : BaseController<Assignment, AssignmentViewModel, AssignmentListViewModel, AssignmentService>
    {
        public override BaseRepository<Assignment> GetRepository()
        {
            return new AssignmentRepository();
        }

        public override AssignmentViewModel GetViewModel()
        {
            return new AssignmentViewModel();
        }

        public override Assignment GetEntity()
        {
            return new Assignment();
        }

        public override void MapEntityToViewModel(Assignment entity, AssignmentViewModel viewModel)
        {
            viewModel.Id = entity.Id;
            viewModel.Title = entity.Title;
            viewModel.Description = entity.Description;
            viewModel.IsDone = entity.IsDone;
            viewModel.DueDate = entity.DueDate;
        }

        public override void MapViewModelToEntity(AssignmentViewModel viewModel, Assignment entity)
        {
            entity.Title = viewModel.Title;
            entity.Description = viewModel.Description;
            entity.IsDone = viewModel.IsDone;
            entity.DueDate = viewModel.DueDate;
        }

        public override string GetRedirectUrl(Assignment entity)
        {
            return "Index";
        }

        public override void OnBeforeList(AssignmentListViewModel viewModel, int? id)
        {
            viewModel.Title = "Assignment Manager List Screen";
        }

        public ActionResult Details(int id)
        {
            var service = new AssignmentService(new AssignmentRepository());
            var detailsDto = service.GetDetails(id);

            var viewModel = new AssignmentDetailsViewModel
            {
                DaysLeft = detailsDto.DaysLeft,
                DueDate = detailsDto.DueDate
            };

            return View(viewModel);
        }
    }
}