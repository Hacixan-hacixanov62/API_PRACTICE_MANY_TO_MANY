using Service.DTOs.Admin.Groups;

namespace Service.Service.Interface
{
    public interface IGroupService
    {
        Task<IEnumerable<GroupDTO>> GetAllWithStudentCountAsync();
        Task CreateAsync(GroupCreateDTO model);
        Task<GroupDTO> GetByIdAsync(int? id);
        Task DeleteAsync(int? id);
        Task EditAsync(int id, GroupEditDTO model);
    }
}
