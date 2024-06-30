using AutoMapper;
using Domain.Entities;
using Microsoft.Extensions.Logging;
using Repository.Repositories.Interface;
using Service.DTOs.Admin.Groups;
using Service.Service.Interface;

namespace Service.Service
{
    public class GroupService : IGroupService
    {
        private readonly IGroupRepository _groupRepo;
        private readonly IStudentRepository _studentRepo;
        private readonly IMapper _mapper;
        private readonly ILogger<GroupService> _logger;

        public GroupService(IMapper mapper,
                            IStudentRepository studentRepo,
                            IGroupRepository groupRepo,
                            ILogger<GroupService> logger)
        {
            _mapper = mapper;
            _studentRepo = studentRepo;
            _groupRepo = groupRepo;
            _logger = logger;
            
        }

        public async Task CreateAsync(GroupCreateDTO model)
        {
            if (model == null) throw new ArgumentNullException();

            await _groupRepo.CreateAsync(_mapper.Map<Group>(model));

        }

        public async Task DeleteAsync(int? id)
        {
            if (id == null)
            {
                _logger.LogWarning("Id is null");
                throw new ArgumentNullException();
            }
            var data = await _groupRepo.GetById((int)id);
            await _groupRepo.DeleteAsync(data);
        }

        public async Task EditAsync(int id, GroupEditDTO model)
        {

            if (model == null) throw new ArgumentNullException();
            var data = await _groupRepo.GetById(id);

            if (data is null) throw new ArgumentNullException();

            var editData = _mapper.Map(model, data);
            await _groupRepo.EditAsync(editData);
        }

        public async Task<IEnumerable<GroupDTO>> GetAllWithStudentCountAsync()
        {

            return _mapper.Map<IEnumerable<GroupDTO>>(await _groupRepo.GetAllWithStudentCountAsync());

        }

        public async Task<GroupDTO> GetByIdAsync(int? id)
        {
            var data = _groupRepo.FindBy(m => m.Id == id, m => m.StudentGroups);

            return _mapper.Map<GroupDTO>(data.FirstOrDefault());

        }
    }
}
