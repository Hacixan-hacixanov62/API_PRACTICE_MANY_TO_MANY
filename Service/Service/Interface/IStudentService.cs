using Service.DTOs.Admin.Students;

namespace Service.Service.Interface
{
    public interface IStudentService
    {
        Task<IEnumerable<STudentDTO>> GetAllWithGroupsAsync();
        Task CreateAsync(StudentCreateDTO model);
        Task<STudentDTO> GetByIdAsync(int id);
        Task DeleteAsync(int id);
        Task EditAsync(int id, StudentEditDTO model);
    }
}
