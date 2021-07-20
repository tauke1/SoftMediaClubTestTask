using System;
using System.Collections.Generic;
using SoftMediaClubTestTask.Domain.Entities.Base;

namespace SoftMediaClubTestTask.Domain.Entities
{
    public class AcademicPerformanceType : BaseEntity<int>
    {
        public string Code { get; set; }
        public string Description { get; set; }
        public IList<Student> Students { get; set; }
    }
}
