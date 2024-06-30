using Domain.Entities;

namespace Repository.Repositories.Interface
{
    public interface IGroupRepository:IBaseRepository<Group>
    {
        Task<IEnumerable<Group>> GetAllWithStudentCountAsync();
    }
}
