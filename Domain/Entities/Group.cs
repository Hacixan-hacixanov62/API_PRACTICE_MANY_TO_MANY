using CourseAPP.Models;

namespace Domain.Entities
{
    public class Group: BaseEntity
    {
        public string Name { get; set; }
        public int Capacity { get; set; }
    }
}
