using DevFreela.Application.Models;
using DevFreela.Core.Entities;
using DevFreela.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace DevFreela.Application.Services
{
    public class ProjectService : IProjectService
    {
        private readonly DevFreelaDbContext _context;
        public ProjectService(DevFreelaDbContext context)
        {
            _context = context;
        }



        public ResultViewModel Complete(int id)
        {
            var project = _context.Projects.SingleOrDefault(p => p.Id == id);

            if (project is null)
            {
                return ResultViewModel.Error("Projeto não existe.");
            }
            project.Complete();
            _context.Projects.Update(project);
            _context.SaveChanges();
            return ResultViewModel.Sucess();
        }

        public ResultViewModel Delete(int id)
        {
            var project = _context.Projects.SingleOrDefault(p => p.Id == id);
            if(project is null)
            {
                return ResultViewModel.Error("Projeto não existe.");
            }
            project.SetAsDeleted();
            _context.Projects.Update(project);
            _context.SaveChanges();
            return ResultViewModel.Sucess();

        }

        public ResultViewModel<List<ProjectItemViewModel>> GetAll(string search = "", int page = 0, int size = 3)
        {

            var projects = _context.Projects
              .Include(p => p.Client)
              .Include(p => p.Freelancer)
              .Where(p => !p.IsDeleted &&
                (search == "" ||
                p.Title.Contains(search) ||
                p.Description.Contains(search) ||
                (p.Title.Contains(search) && p.Description.Contains(search))))
              .Skip(page * size)
              .Take(size)
              .ToList();
            var model = projects.Select(ProjectItemViewModel.FromEntity).ToList();
            return ResultViewModel<List<ProjectItemViewModel>>.Sucess(model);
        }

        public ResultViewModel<ProjectViewModel> GetById(int id)
        {
            var project = _context.Projects
                         .Include(p => p.Client)
                         .Include(p => p.Freelancer)
                         .Include(p => p.Comments)
                         .SingleOrDefault(o => o.Id == id);

            if (project is null)
            {
                return ResultViewModel<ProjectViewModel>.Error("Projeto não existe.");
            }


            var model = ProjectViewModel.FromEntity(project);
            return ResultViewModel<ProjectViewModel>.Sucess(model);

        }

        public ResultViewModel<int> Insert(CreateProjectInputModel model)
        {
            var project = model.ToEntity();
            _context.Projects.Add(project);
            _context.SaveChanges();
            return ResultViewModel<int>.Sucess(project.Id);
        }

        public ResultViewModel InsertComment(int id, CreateProjectCommentInputModel model)
        {
            var project = _context.Projects.SingleOrDefault(p => p.Id == id);
            if (project is null)
            {
                return ResultViewModel.Error("Projeto não existe.");
            }
            var comment = new ProjectComment(model.Content, model.IdProject, model.IdUser);
            _context.ProjectComments.Add(comment);
            _context.SaveChanges();
            return ResultViewModel.Sucess();
        }

        public ResultViewModel Start(int id)
        {
            var project = _context.Projects.SingleOrDefault(p => p.Id == id);

            if (project is null)
            {
                return ResultViewModel.Error("Projeto não existe.");
            }
            project.Start();
            _context.Projects.Update(project);
            _context.SaveChanges();
            return ResultViewModel.Sucess();
        }

        public ResultViewModel Update(UpdateProjectInputModel model)
        {
            var project = _context.Projects.SingleOrDefault(p => p.Id == model.Id);
            if (project is null)
            {
                return ResultViewModel.Error("Projeto não existe.");
            }
            project.Update(model.Title, model.Description, model.TotalCost);
            _context.Projects.Update(project);
            _context.SaveChanges();
            return ResultViewModel.Sucess();
        }
    }
}
