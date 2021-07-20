using System;
namespace SoftMediaClubTestTask.Domain.Entities.Base
{
    public class BaseEntity<T>
    {
        public T Id { get; set; }
    }
}
