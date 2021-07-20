using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SoftMediaClubTestTask.API.Models
{
    /// <summary>
    /// Сущность студена
    /// </summary>
    public class Student
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Имя
        /// </summary>
        public string Firstname { get; set; }

        /// <summary>
        /// Фамилия
        /// </summary>
        public string Lastname { get; set; }

        /// <summary>
        /// Отчество
        /// </summary>
        public string Middlename { get; set; }

        /// <summary>
        /// Дата рождения
        /// </summary>
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        /// <summary>
        /// Идентификатор типа успеваемости
        /// </summary>
        public int AcademicPerformanceTypeId { get; set; }
    }
}
