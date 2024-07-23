using Abp.Application.Services.Dto;
using System;
using System.ComponentModel.DataAnnotations;

namespace RingoMedia.Departments.Dtos
{
    public class GetDepartmentsInput : PagedAndSortedResultRequestDto
    {
        [Range(1, long.MaxValue)]
        public long Id { get; set; }

        public string Filter { get; set; }

    }
}