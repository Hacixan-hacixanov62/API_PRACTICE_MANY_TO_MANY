namespace Service.DTOs.Admin.Students
{
    public class STudentDTO
    {
        public int Id { get; set; }
        public string SurName { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        public List<StudentGroupsDTO> StudentGroups { get; set; }
    }
}
