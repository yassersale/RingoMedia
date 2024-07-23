using System;
using Abp.Application.Services.Dto;
using System.ComponentModel.DataAnnotations;

namespace RingoMedia.Departments.Dtos
{
    public class GetDepartmentForEditOutput
    {
        public CreateOrEditDepartmentDto Department { get; set; }

        public string ParentName { get; set; }

        public string LogoFileName { get; set; }

    }
}