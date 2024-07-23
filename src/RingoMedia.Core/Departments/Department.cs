﻿using Abp.Collections.Extensions;
using Abp.Domain.Entities.Auditing;
using Abp.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace RingoMedia.Departments
{
    [Table("Departments")]
    public class Department : FullAuditedEntity<long>
    {

        public virtual long? ParentId { get; set; }

        [Required]
        [StringLength(DepartmentConsts.MaxNameLength)]
        public virtual string Name { get; set; }

        public virtual Guid? Logo { get; set; } //File, (BinaryObjectId)

        [Required]
        [StringLength(DepartmentConsts.MaxCodeLength)]
        public virtual string Code { get; set; }

        [ForeignKey("ParentId")]
        public Department ParentFk { get; set; }

        public virtual ICollection<Department> SubDepartments { get; set; }


        public Department()
        {

        }

        public Department(long? parentId, string name, Guid? logo = null)
        {

            ParentId = parentId;

            Name = name;
            Logo = logo;

        }


        /// <summary>
        /// Creates code for given numbers. Example: if numbers are 4,2 then returns "00004.00002";
        /// </summary>
        /// <param name="numbers">Numbers</param>
        public static string CreateCode(params int[] numbers)
        {
            if (numbers.IsNullOrEmpty())
            {
                return null;
            }

            return numbers.Select(number => number.ToString(new string('0', DepartmentConsts.CodeUnitLength))).JoinAsString(".");
        }

        /// <summary>
        /// Appends a child code to a parent code.  Example: if parentCode = "00001", childCode = "00042" then returns
        /// "00001.00042".
        /// </summary>
        /// <param name="parentCode">Parent code. Can be null or empty if parent is a root.</param>
        /// <param name="childCode">Child code.</param>
        public static string AppendCode(string parentCode, string childCode)
        {
            if (childCode.IsNullOrEmpty())
            {
                throw new ArgumentNullException(nameof(childCode), "childCode can not be null or empty.");
            }

            if (parentCode.IsNullOrEmpty())
            {
                return childCode;
            }

            return parentCode + "." + childCode;
        }

        /// <summary>
        /// Gets relative code to the parent. Example: if code = "00019.00055.00001" and parentCode = "00019" then
        /// returns "00055.00001".
        /// </summary>
        /// <param name="code">The code.</param>
        /// <param name="parentCode">The parent code.</param>
        public static string GetRelativeCode(string code, string parentCode)
        {
            if (code.IsNullOrEmpty())
            {
                throw new ArgumentNullException(nameof(code), "code can not be null or empty.");
            }

            if (parentCode.IsNullOrEmpty())
            {
                return code;
            }

            if (code.Length == parentCode.Length)
            {
                return null;
            }

            return code.Substring(parentCode.Length + 1);
        }

        /// <summary>
        /// Calculates next code for given code. Example: if code = "00019.00055.00001" returns "00019.00055.00002".
        /// </summary>
        /// <param name="code">The code.</param>
        public static string CalculateNextCode(string code)
        {
            if (code.IsNullOrEmpty())
            {
                throw new ArgumentNullException(nameof(code), "code can not be null or empty.");
            }

            var parentCode = GetParentCode(code);
            var lastUnitCode = GetLastUnitCode(code);

            return AppendCode(parentCode, CreateCode(Convert.ToInt32(lastUnitCode) + 1));
        }

        /// <summary>
        /// Gets the last unit code. Example: if code = "00019.00055.00001" returns "00001".
        /// </summary>
        /// <param name="code">The code.</param>
        public static string GetLastUnitCode(string code)
        {
            if (code.IsNullOrEmpty())
            {
                throw new ArgumentNullException(nameof(code), "code can not be null or empty.");
            }

            var splittedCode = code.Split('.');
            return splittedCode[splittedCode.Length - 1];
        }

        /// <summary>
        /// Gets parent code. Example: if code = "00019.00055.00001" returns "00019.00055".
        /// </summary>
        /// <param name="code">The code.</param>
        public static string GetParentCode(string code)
        {
            if (code.IsNullOrEmpty())
            {
                throw new ArgumentNullException(nameof(code), "code can not be null or empty.");
            }

            var splittedCode = code.Split('.');
            if (splittedCode.Length == 1)
            {
                return null;
            }

            return splittedCode.Take(splittedCode.Length - 1).JoinAsString(".");
        }

    }
}