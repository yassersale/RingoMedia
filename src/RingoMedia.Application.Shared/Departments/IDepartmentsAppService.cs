using Abp.Application.Services;
using Abp.Application.Services.Dto;
using RingoMedia.Departments.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RingoMedia.Departments
{
    public interface IDepartmentsAppService : IApplicationService
    {
        Task<PagedResultDto<ShowDepartmentList>> GetDepartments(GetAllDepartmentsInput input);

        Task<ShowDepartmentList> GetDepartmentById(long id);

        Task<List<ShowDepartmentList>> GetSubDepartmentsByDepartmentId(long id);

        Task<GetDepartmentForEditOutput> GetDepartmentForEdit(EntityDto<long> input);

        Task<ShowDepartmentList> CreateOrEditDepartment(CreateOrEditDepartmentDto input);

        Task DeleteDepartment(EntityDto<long> input);

        Task RemoveLogoFile(EntityDto<long> input);

    }
}