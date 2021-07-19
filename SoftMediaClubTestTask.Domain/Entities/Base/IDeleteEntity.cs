using System;
namespace SoftMediaClubTestTask.Domain.Entities.Base
{
    public interface IDeleteEntity
    {
        public DateTime? DeleteDate { get; set; }
    }

    public interface IDeleteEntity<TKey> : IDeleteEntity, IEntityBase<TKey>
    {
    }
}
