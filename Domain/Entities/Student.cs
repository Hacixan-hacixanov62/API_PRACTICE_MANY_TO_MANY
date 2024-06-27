using CourseAPP.Models;

namespace Domain.Entities
{
    public class Student : BaseEntity
    {
        public string Name { get; set; }
        public string SurName { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
    }
}
