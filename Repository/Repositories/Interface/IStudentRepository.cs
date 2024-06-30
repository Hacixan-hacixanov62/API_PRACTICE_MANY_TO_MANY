using Domain.Entities;

namespace Repository.Repositories.Interface
{
    public interface IStudentRepository:IBaseRepository<Student>
    {
        Task<IEnumerable<Student>> GetAllWithGroupAsync();
         
    }
}
