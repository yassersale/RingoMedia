using System;
using Abp.Application.Services.Dto;
using System.ComponentModel.DataAnnotations;
using RingoMedia.Departments.Dtos;

namespace RingoMedia.Departments.Dtos
{
    public class GetDepartmentForReportOutput
    {
        public CreateOrEditDepartmentDto Department { get; set; }

        public CreateOrEditDepartmentDto Parent { get; set; }

        public string LogoFileName { get; set; }

    }
}