using System;
namespace SoftMediaClubTestTask.Domain.Entities.Base
{
    public class BaseEntity<T>
    {
        public T PrimaryKey { get; set; }
    }
}
