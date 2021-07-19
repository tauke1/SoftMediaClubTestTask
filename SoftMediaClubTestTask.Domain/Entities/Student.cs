using System;
using SoftMediaClubTestTask.Domain.Entities.Base;

namespace SoftMediaClubTestTask.Domain.Entities
{
    public class Student : AuditEntity<int>
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Middlename { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int AcademicPerformanceTypeId { get; set; }
        public AcademicPerformanceType AcademicPerformanceType { get; set; }
    }
}
