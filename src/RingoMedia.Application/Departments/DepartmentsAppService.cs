using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Extensions;
using Abp.Linq.Extensions;
using Abp.Threading;
using Abp.UI;
using Microsoft.EntityFrameworkCore;
using RingoMedia.Authorization;
using RingoMedia.Departments.Dtos;
using RingoMedia.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;

namespace RingoMedia.Departments
{
    [AbpAuthorize(AppPermissions.Pages_Departments)]
    public class DepartmentsAppService : RingoMediaAppServiceBase, IDepartmentsAppService
    {
        private readonly DepartmentManager _departmentManager;

        private readonly IRepository<Department, long> _departmentRepository;
        private readonly IRepository<Department, long> _lookup_departmentRepository;

        private readonly ITempFileCacheManager _tempFileCacheManager;
        private readonly IBinaryObjectManager _binaryObjectManager;

        public DepartmentsAppService(DepartmentManager departmentManager,
        IRepository<Department, long> departmentRepository, IRepository<Department, long> lookup_departmentRepository
        , ITempFileCacheManager tempFileCacheManager, IBinaryObjectManager binaryObjectManager)
        {
            _departmentManager = departmentManager;
            _departmentRepository = departmentRepository;

            _lookup_departmentRepository = lookup_departmentRepository;

            _tempFileCacheManager = tempFileCacheManager;
            _binaryObjectManager = binaryObjectManager;

        }

        // private void GetAll(GetAllTest2sInput input){}

        public async Task<PagedResultDto<ShowDepartmentList>> GetDepartments(GetAllDepartmentsInput input)
        {

            var filteredDepartments = _departmentRepository.GetAll()
                            .Include(e => e.ParentFk)

                            .WhereIf(!string.IsNullOrWhiteSpace(input.Filter), e => false || e.Name.Contains(input.Filter) || e.Code.Contains(input.Filter));


            var pagedAndFilteredDepartments = filteredDepartments
                .OrderBy(input.Sorting ?? "id asc")
                .PageBy(input);

            var departments = from department in pagedAndFilteredDepartments
                              join o1 in _lookup_departmentRepository.GetAll() on department.ParentId equals o1.Id into j1
                              from s1 in j1.DefaultIfEmpty()

                              select new
                              {
                                  department,
                                  ParentName = s1 == null || s1.Name == null ? "" : s1.Name.ToString()
                              };

            var totalCount = await filteredDepartments.CountAsync();

            var dbList = await departments.ToListAsync();
            var results = dbList.Select(u =>
                {
                    var department = ObjectMapper.Map<ShowDepartmentList>(u.department);

                    department.ParentName = u.ParentName;

                    department.LogoFileName = AsyncHelper.RunSync(() => GetBinaryFileName(department.Logo));


                    return department;

                }).ToList();

            return new PagedResultDto<ShowDepartmentList>(
                totalCount,
                results
            );

        }

        public async Task<List<ShowDepartmentList>> GetSubDepartmentsByDepartmentId(long id)
        {
            var department = await _departmentManager.FindChildrenAsync(id);

            var output = ObjectMapper.Map<List<ShowDepartmentList>>(department);



            return output;
        }
        public async Task<ShowDepartmentList> GetDepartmentById(long id)
        {
            var department = await _departmentRepository.GetAll()
                .Include(e => e.ParentFk)
            .Where(e => e.Id == id).FirstOrDefaultAsync();

            var output = ObjectMapper.Map<ShowDepartmentList>(department);

            if (output.ParentId != null)
            {
                output.ParentName = department?.ParentFk?.Name?.ToString();
            }

            output.LogoFileName = await GetBinaryFileName(department.Logo);

            return output;
        }

        public async Task<DepartmentReport> GetDepartmentForReport(long id)
        {

            var department = await _departmentRepository.GetAll()

                            .Include(e => e.ParentFk)

                    .Where(e => e.Id == id).FirstOrDefaultAsync();

            var output = ObjectMapper.Map<DepartmentReport>(department);

            if (output.ParentId != null)
            {

                output.Parent = ObjectMapper.Map<DepartmentReport>(department.ParentFk);
            }

            output.LogoFileName = await GetBinaryFileName(department.Logo);

            return output;
        }

        [AbpAuthorize(AppPermissions.Pages_Departments_Edit)]
        public async Task<GetDepartmentForEditOutput> GetDepartmentForEdit(EntityDto<long> input)
        {
            var department = await _departmentRepository.FirstOrDefaultAsync(input.Id);

            var output = new GetDepartmentForEditOutput { Department = ObjectMapper.Map<CreateOrEditDepartmentDto>(department) };

            if (output.Department.ParentId != null)
            {
                var _lookupDepartment = await _lookup_departmentRepository.FirstOrDefaultAsync((long)output.Department.ParentId);
                output.ParentName = _lookupDepartment?.Name?.ToString();
            }

            output.LogoFileName = await GetBinaryFileName(department.Logo);

            return output;
        }

        public async Task<ShowDepartmentList> CreateOrEditDepartment(CreateOrEditDepartmentDto input)
        {
            if (input.Id == null || input.Id == 0)
            {
                return await CreateDepartment(input);


            }
            else
            {
                return await UpdateDepartment(input);
            }

        }

        [AbpAuthorize(AppPermissions.Pages_Departments_Create)]
        protected virtual async Task<ShowDepartmentList> CreateDepartment(CreateOrEditDepartmentDto input)
        {
            var department = new Department(input.ParentId, input.Name);

            department.Logo = await GetBinaryObjectFromCache(input.LogoToken);


            await _departmentManager.CreateAsync(department);



            await CurrentUnitOfWork.SaveChangesAsync();

            return ObjectMapper.Map<ShowDepartmentList>(department);
        }

        [AbpAuthorize(AppPermissions.Pages_Departments_Edit)]

        protected virtual async Task<ShowDepartmentList> UpdateDepartment(CreateOrEditDepartmentDto input)
        {
            var department = await _departmentRepository.GetAsync((long)input.Id);

            department.Name = input.Name;
            department.Logo = await GetBinaryObjectFromCache(input.LogoToken);


            await _departmentManager.UpdateAsync(department);



            return ObjectMapper.Map<ShowDepartmentList>(department);
        }




        [AbpAuthorize(AppPermissions.Pages_Departments_Delete)]
        public async Task DeleteDepartment(EntityDto<long> input)
        {
            await _departmentRepository.DeleteAsync(input.Id);
        }

        private async Task<Guid?> GetBinaryObjectFromCache(string fileToken)
        {
            if (fileToken.IsNullOrWhiteSpace())
            {
                return null;
            }

            var fileCache = _tempFileCacheManager.GetFileInfo(fileToken);

            if (fileCache == null)
            {
                throw new UserFriendlyException("There is no such file with the token: " + fileToken);
            }

            var storedFile = new BinaryObject(AbpSession.TenantId, fileCache.File, fileCache.FileName);
            await _binaryObjectManager.SaveAsync(storedFile);

            return storedFile.Id;
        }

        private async Task<string> GetBinaryFileName(Guid? fileId)
        {
            if (!fileId.HasValue)
            {
                return null;
            }

            var file = await _binaryObjectManager.GetOrNullAsync(fileId.Value);
            return file?.Description;
        }

        [AbpAuthorize(AppPermissions.Pages_Departments_Edit)]
        public async Task RemoveLogoFile(EntityDto<long> input)
        {
            var department = await _departmentRepository.FirstOrDefaultAsync(input.Id);
            if (department == null)
            {
                throw new UserFriendlyException(L("EntityNotFound"));
            }

            if (!department.Logo.HasValue)
            {
                throw new UserFriendlyException(L("FileNotFound"));
            }

            await _binaryObjectManager.DeleteAsync(department.Logo.Value);
            department.Logo = null;
        }

    }
}