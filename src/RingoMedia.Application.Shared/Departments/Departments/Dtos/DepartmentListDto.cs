using System;

using Abp.Application.Services.Dto;

namespace RingoMedia.Departments.Dtos
{
    public class DepartmentListDto : EntityDto<long>
    {

        public string Name { get; set; }

        public Guid? Logo { get; set; }

        public string LogoFileName { get; set; }

        public long? ParentId { get; set; }

        public string ParentName { get; set; }

        public DepartmentListDto()
        {

        }

    }
}