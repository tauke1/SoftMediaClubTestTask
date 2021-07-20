using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoftMediaClubTestTask.API.Models
{
    /// <summary>
    /// Тип успеваемости
    /// </summary>
    public class AcademicPerformanceType
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Код
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// Описание
        /// </summary>
        public string Description { get; set; }
    }
}
