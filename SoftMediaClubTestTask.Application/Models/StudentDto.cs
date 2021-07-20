using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftMediaClubTestTask.Application.Models
{
    public class StudentDto
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Middlename { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int AcademicPerformanceTypeId { get; set; }
    }
}
