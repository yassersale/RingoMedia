using System;
using Abp.Application.Services.Dto;

using RingoMedia.Departments.Dtos;

namespace RingoMedia.Departments.Dtos
{
    public class DepartmentReport : EntityDto<long>
    {

        public string Name { get; set; }

        public Guid? Logo { get; set; }

        public string LogoFileName { get; set; }

        public long? ParentId { get; set; }

        public DepartmentReport Parent { get; set; }

        public DepartmentReport()
        {

        }

    }
}