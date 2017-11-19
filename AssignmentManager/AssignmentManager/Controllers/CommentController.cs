using AssignmentManager.Models;
using DataAccess.Entities;
using DataAccess.EntityFramework.Repositories;
using ServiceLayer;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;

namespace AssignmentManager.Controllers
{
    public class CommentController : BaseController<Comment, CommentViewModel, CommentListViewModel, CommentService>
    {
        public override void OnBeforeList(CommentListViewModel model, int? id)
        {
            if (id.HasValue)
            {
                model.AssignmentId = id.Value;
            }
        }

        public override Expression<Func<Comment, bool>> GetGetAllFilter(CommentListViewModel model)
        {
            return x => x.AssignmentId == model.AssignmentId;
        }

        public override void OnBeforeInsert(CommentViewModel viewModel, int? id)
        {
            if (id.HasValue)
            {
                viewModel.AssignmentId = id.Value;

            }
        }

        public override BaseRepository<Comment> GetRepository()
        {
            return new CommentRepository();
        }

        public override CommentViewModel GetViewModel()
        {
            return new CommentViewModel();
        }

        public override Comment GetEntity()
        {
            return new Comment();
        }

        public override void MapEntityToViewModel(Comment entity, CommentViewModel viewModel)
        {
            viewModel.Id = entity.Id;
            viewModel.AssignmentId = entity.AssignmentId;
            viewModel.Content = entity.Content;
        }

        public override void MapViewModelToEntity(CommentViewModel viewModel, Comment entity)
        {
            entity.Content = viewModel.Content;
            entity.AssignmentId = viewModel.AssignmentId;
        }

        public override string GetRedirectUrl(Comment entity)
        {
            return string.Format("Index/{0}", entity.AssignmentId);
        }
    }
}