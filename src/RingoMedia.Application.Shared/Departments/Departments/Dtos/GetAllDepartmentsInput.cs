using Abp.Application.Services.Dto;

namespace RingoMedia.Departments.Dtos
{
    public class GetAllDepartmentsInput : PagedAndSortedResultRequestDto
    {
        public string Filter { get; set; }


    }
}