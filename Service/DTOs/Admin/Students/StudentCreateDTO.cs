﻿namespace Service.DTOs.Admin.Students
{
    public class StudentCreateDTO
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public int Age { get; set; }
        public int GroupId { get; set; }
    }
}
