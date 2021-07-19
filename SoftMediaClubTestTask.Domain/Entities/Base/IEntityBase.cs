using System;
namespace SoftMediaClubTestTask.Domain.Entities.Base
{
    public interface IEntityBase<TKey>
    {
        public TKey Id { get; set; }
    }
}
