using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Repository.Data;
using Repository.Repositories.Interface;

namespace Repository.Repositories
{
    public class GroupRepository : BaseRepository<Group>, IGroupRepository
    {
        public GroupRepository(AppDbContext context) : base(context)
        {
            
        }

        public async Task<IEnumerable<Group>> GetAllWithStudentCountAsync()
        {
            return await _context.Groups.AsNoTracking().Include(m => m.StudentGroups).ToListAsync();

        }
    }
}
