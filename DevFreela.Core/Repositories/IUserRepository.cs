using DevFreela.Core.Entities;

namespace DevFreela.Core.Repositories
{
    public interface IUserRepository
    {
        Task<User> InsertUser(User user);

        Task InsertUserSkills(List<UserSkill> skills);


        Task<User> GetUserById(int Id);
    }
}
