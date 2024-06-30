using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Repository.Data;
using Repository.Repositories.Interface;

namespace Repository.Repositories
{
    public class StudentRepository:BaseRepository<Student>, IStudentRepository
    {
        public StudentRepository(AppDbContext context) : base(context) { }

        public async Task<IEnumerable<Student>> GetAllWithGroupAsync()
        {
            return await _context.Students.AsNoTracking().Include(m=>m.StudentGroups).ThenInclude(m=>m.Group).ToListAsync();
        }
    }
}
