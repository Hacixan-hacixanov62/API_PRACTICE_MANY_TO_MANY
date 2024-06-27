using FluentValidation;

namespace Service.DTOs.Admin.Groups
{
    public class GroupCreateDTO
    {
        public string Name { get; set; }
        public int Capacity { get; set; }

        public class GroupCreateDTOValidator : AbstractValidator<GroupCreateDTO>
        {
            public GroupCreateDTOValidator()
            {
                RuleFor(m => m.Name).NotNull().WithMessage("Title PB-101 is required");
            }
        }
    }
}
