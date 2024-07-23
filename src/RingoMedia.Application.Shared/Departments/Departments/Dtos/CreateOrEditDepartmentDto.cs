using System;
using Abp.Application.Services.Dto;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RingoMedia.Departments.Dtos
{
    public class CreateOrEditDepartmentDto : EntityDto<long?>
    {

        [Required]
        [StringLength(DepartmentConsts.MaxNameLength)]
        public string Name { get; set; }

        public Guid? Logo { get; set; }

        public string LogoToken { get; set; }

        public long? ParentId { get; set; }

        public CreateOrEditDepartmentDto()
        {

        }

    }
}