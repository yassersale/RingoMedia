using Abp.Application.Services.Dto;

namespace RingoMedia.Departments.Dtos
{
    public class GetAllDepartmentDepartmentForLookupTableInput : PagedAndSortedResultRequestDto
    {
        public string Filter { get; set; }
    }
}