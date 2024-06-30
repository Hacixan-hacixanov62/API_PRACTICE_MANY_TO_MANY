using AutoMapper;
using Domain.Entities;
using Microsoft.Extensions.Logging;
using Repository.Repositories.Interface;
using Service.DTOs.Admin.Students;
using Service.Helpers.Exceptions;
using Service.Service.Interface;

namespace Service.Service
{
    public class StudentService:IStudentService
    {

        private readonly IGroupRepository _groupRepo;
        private readonly IStudentRepository _studentRepo;
        private readonly IMapper _mapper;
        private readonly ILogger<StudentService> _logger;

        public StudentService(IGroupRepository groupRepo,
                              IStudentRepository studentRepo,
                              IMapper mapper,
                               ILogger<StudentService> logger)
        {
            _groupRepo = groupRepo;
            _studentRepo = studentRepo;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task CreateAsync(StudentCreateDTO model)
        {
            var existGroup = await _groupRepo.GetById(model.GroupId);
            if (existGroup is null)
            {
                _logger.LogWarning($"Group is not found -{model.GroupId + "-" + DateTime.Now.ToString()}");
                throw new NotFoundException($"id-{model.GroupId} Group not found");
            }
            if (model == null) throw new ArgumentNullException();


            Student student = _mapper.Map<Student>(model);
            student.StudentGroups.Add(new StudentGroup
            {
                GroupId = model.GroupId,
                StudentId = student.Id
            }) ;

            await _studentRepo.CreateAsync(student);

        }

        public async Task DeleteAsync(int id)
        {
            if (id == null)
            {
                _logger.LogWarning("Id is null");
                throw new ArgumentNullException();
            }
            var data = await _studentRepo.GetById((int)id);
            await _studentRepo.DeleteAsync(data);
        }

        public async Task EditAsync(int id, StudentEditDTO model)
        {
            if (model == null) throw new ArgumentNullException();
            var data = await _studentRepo.GetById(id);

            if (data is null) throw new ArgumentNullException();

            var editData = _mapper.Map(model, data);

            await _studentRepo.EditAsync(editData);
        }

        public async Task<IEnumerable<STudentDTO>> GetAllWithGroupsAsync()
        {
            return _mapper.Map<IEnumerable<STudentDTO>>(await _studentRepo.GetAllWithGroupAsync());

        }

        public async  Task<STudentDTO> GetByIdAsync(int id)
        {
            var data = _studentRepo.FindBy(m => m.Id == id, m => m.StudentGroups);

            return _mapper.Map<STudentDTO>(data.FirstOrDefault());

        }
    }
}
