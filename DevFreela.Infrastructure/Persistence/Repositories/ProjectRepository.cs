using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DevFreela.Infrastructure.Persistence.Repositories
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly DevFreelaDbContext _context;

        public ProjectRepository(DevFreelaDbContext context)
        {
            _context = context;
        }

        public async Task<int> Add(Project project)
        {
            await _context.Projects.AddAsync(project);
            await _context.SaveChangesAsync();
            return project.Id;
        }

        public async Task AddComment(ProjectComment comment)
        {

            await _context.ProjectComments.AddAsync(comment);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> Exists(int id)
        {
            return await _context.Projects.AnyAsync(p => p.Id == id);
        }

        public async Task<List<Project>> GetAll(string search = "", int page = 0, int size = 3)
        {
            var projects = await _context.Projects
                 .Include(p => p.Client)
                 .Include(p => p.Freelancer)
                 .Where(p => !p.IsDeleted &&
                   (search == "" ||
                   p.Title.Contains(search) ||
                   p.Description.Contains(search) ||
                   (p.Title.Contains(search) && p.Description.Contains(search))))
                 .Skip(page * size)
                 .Take(size)
                 .ToListAsync();
            return projects;
        }

        public async Task<Project?> GetById(int id)
        {
            return await _context.Projects
                    .SingleOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Project?> GetDetailsById(int id)
        {
            var project = await _context.Projects
                   .Include(p => p.Client)
                   .Include(p => p.Freelancer)
                   .Include(p => p.Comments)
                   .SingleOrDefaultAsync(o => o.Id == id);
            return project;
        }

        public async Task Update(Project project)
        {
            _context.Projects.Update(project);
            await _context.SaveChangesAsync();
        }
    }
}
