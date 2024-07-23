using Abp.Domain.Repositories;
using Abp.Domain.Services;
using Abp.Domain.Uow;
using Abp.Linq;
using Abp.UI;
using Abp.Zero;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RingoMedia.Departments
{
    /// <summary>
    /// Performs domain logic for Chart Of Accounts.
    /// </summary>
    public class DepartmentManager : DomainService
    {
        protected IRepository<Department, long> DepartmentRepository { get; private set; }

        public IAsyncQueryableExecuter AsyncQueryableExecuter { get; set; }

        public DepartmentManager(IRepository<Department, long> departmentRepository)
        {
            DepartmentRepository = departmentRepository;

            LocalizationSourceName = AbpZeroConsts.LocalizationSourceName;
            AsyncQueryableExecuter = NullAsyncQueryableExecuter.Instance;
        }

        public virtual async Task CreateAsync(Department department)
        {
            using (var uow = UnitOfWorkManager.Begin())
            {
                department.Code = await GetNextChildCodeAsync(department.ParentId);
                await ValidateOrganizationUnitAsync(department);
                await DepartmentRepository.InsertAsync(department);

                await uow.CompleteAsync();
            }
        }

        public virtual void Create(Department department)
        {
            using (var uow = UnitOfWorkManager.Begin())
            {
                department.Code = GetNextChildCode(department.ParentId);
                ValidateOrganizationUnit(department);
                DepartmentRepository.Insert(department);

                uow.Complete();
            }
        }

        public virtual async Task UpdateAsync(Department department)
        {
            await ValidateOrganizationUnitAsync(department);
            await DepartmentRepository.UpdateAsync(department);
        }

        public virtual void Update(Department department)
        {
            ValidateOrganizationUnit(department);
            DepartmentRepository.Update(department);
        }

        public virtual async Task<string> GetNextChildCodeAsync(long? parentId)
        {
            var lastChild = await GetLastChildOrNullAsync(parentId);
            if (lastChild == null)
            {
                var parentCode = parentId != null ? await GetCodeAsync(parentId.Value) : null;
                return Department.AppendCode(parentCode, Department.CreateCode(1));
            }

            return Department.CalculateNextCode(lastChild.Code);
        }

        public virtual string GetNextChildCode(long? parentId)
        {
            var lastChild = GetLastChildOrNull(parentId);
            if (lastChild == null)
            {
                var parentCode = parentId != null ? GetCode(parentId.Value) : null;
                return Department.AppendCode(parentCode, Department.CreateCode(1));
            }

            return Department.CalculateNextCode(lastChild.Code);
        }

        public virtual async Task<Department> GetLastChildOrNullAsync(long? parentId)
        {
            var query = DepartmentRepository.GetAll()
                .Where(ou => ou.ParentId == parentId)
                .OrderByDescending(ou => ou.Code);
            return await AsyncQueryableExecuter.FirstOrDefaultAsync(query);
        }

        public virtual Department GetLastChildOrNull(long? parentId)
        {
            var query = DepartmentRepository.GetAll()
                .Where(ou => ou.ParentId == parentId)
                .OrderByDescending(ou => ou.Code);
            return query.FirstOrDefault();
        }

        public virtual async Task<string> GetCodeAsync(long id)
        {
            return (await DepartmentRepository.GetAsync(id)).Code;
        }

        public virtual string GetCode(long id)
        {
            return (DepartmentRepository.Get(id)).Code;
        }

        public virtual async Task DeleteAsync(long id)
        {
            using (var uow = UnitOfWorkManager.Begin())
            {
                var children = await FindChildrenAsync(id, true);

                foreach (var child in children)
                {
                    await DepartmentRepository.DeleteAsync(child);
                }

                await DepartmentRepository.DeleteAsync(id);

                await uow.CompleteAsync();
            }
        }

        public virtual void Delete(long id)
        {
            using (var uow = UnitOfWorkManager.Begin())
            {
                var children = FindChildren(id, true);

                foreach (var child in children)
                {
                    DepartmentRepository.Delete(child);
                }

                DepartmentRepository.Delete(id);

                uow.Complete();
            }
        }

        public virtual async Task MoveAsync(long id, long? parentId)
        {
            using (var uow = UnitOfWorkManager.Begin())
            {
                var department = await DepartmentRepository.GetAsync(id);
                if (department.ParentId == parentId)
                {
                    await uow.CompleteAsync();
                    return;
                }

                //Should find children before Code change
                var children = await FindChildrenAsync(id, true);

                //Store old code of OU
                var oldCode = department.Code;

                //Move OU
                department.Code = await GetNextChildCodeAsync(parentId);
                department.ParentId = parentId;

                await ValidateOrganizationUnitAsync(department);

                //Update Children Codes
                foreach (var child in children)
                {
                    child.Code = Department.AppendCode(department.Code, Department.GetRelativeCode(child.Code, oldCode));
                }

                await uow.CompleteAsync();
            }
        }

        public virtual void Move(long id, long? parentId)
        {
            UnitOfWorkManager.WithUnitOfWork(() =>
            {
                var department = DepartmentRepository.Get(id);
                if (department.ParentId == parentId)
                {
                    return;
                }

                //Should find children before Code change
                var children = FindChildren(id, true);

                //Store old code of OU
                var oldCode = department.Code;

                //Move OU
                department.Code = GetNextChildCode(parentId);
                department.ParentId = parentId;

                ValidateOrganizationUnit(department);

                //Update Children Codes
                foreach (var child in children)
                {
                    child.Code = Department.AppendCode(department.Code, Department.GetRelativeCode(child.Code, oldCode));
                }
            });
        }

        public async Task<List<Department>> FindChildrenAsync(long? parentId, bool recursive = false, bool lastChild = false)
        {
            if (!recursive)
            {
                return await DepartmentRepository.GetAllListAsync(ou => ou.ParentId == parentId);
            }

            if (!parentId.HasValue)
            {
                return await DepartmentRepository.GetAllListAsync();
            }

            var code = await GetCodeAsync(parentId.Value);

            var result = await DepartmentRepository.GetAllListAsync(
                        ou => ou.Code.StartsWith(code) && ou.Id != parentId.Value
                    );

            if (lastChild)
            {
                var list = new List<Department>();

                foreach (var line in result)
                {
                    var test = await GetLastChildOrNullAsync(line.Id);

                    if (test == null)
                    {
                        list.Add(line);
                    }
                }

                return list;
            }

            return result;
        }

        public List<Department> FindChildren(long? parentId, bool recursive = false)
        {
            if (!recursive)
            {
                return DepartmentRepository.GetAllList(ou => ou.ParentId == parentId);
            }

            if (!parentId.HasValue)
            {
                return DepartmentRepository.GetAllList();
            }

            var code = GetCode(parentId.Value);

            return DepartmentRepository.GetAllList(
                ou => ou.Code.StartsWith(code) && ou.Id != parentId.Value
            );
        }

        public async Task<List<Department>> FindChildrenByCodeAsync(string parentCode, bool recursive = false, bool onlyLastChildren = false)
        {
            if (!recursive)
            {
                return await DepartmentRepository.GetAllListAsync(ou => ou.ParentFk.Code == parentCode);
            }

            if (parentCode == null)
            {
                return await DepartmentRepository.GetAllListAsync();
            }

            //var code = await GetCodeAsync(parentId.Value);

            var result = await DepartmentRepository.GetAllListAsync(
                ou => ou.Code.StartsWith(parentCode) //&& ou.Code != parentCode
            );

            if (onlyLastChildren)
            {
                var list = new List<Department>();

                foreach (var line in result)
                {
                    var test = await GetLastChildOrNullAsync(line.Id);

                    if (test == null)
                    {
                        list.Add(line);
                    }
                }

                return list;
            }

            return result;
        }



        protected virtual async Task ValidateOrganizationUnitAsync(Department department)
        {
            var siblings = (await FindChildrenAsync(department.ParentId))
                .Where(ou => ou.Id != department.Id)
                .ToList();

            if (siblings.Any(ou => ou.Name == department.Name))
            {
                throw new UserFriendlyException(L("OrganizationUnitDuplicateNameWarning", department.Name));
            }
        }

        protected virtual void ValidateOrganizationUnit(Department department)
        {
            var siblings = (FindChildren(department.ParentId))
                .Where(ou => ou.Id != department.Id)
                .ToList();

            if (siblings.Any(ou => ou.Name == department.Name))
            {
                throw new UserFriendlyException(L("OrganizationUnitDuplicateNameWarning", department.Name));
            }
        }
    }

}
