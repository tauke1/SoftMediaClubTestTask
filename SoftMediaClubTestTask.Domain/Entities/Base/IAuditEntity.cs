using System;
namespace SoftMediaClubTestTask.Domain.Entities.Base
{
    public interface IAuditEntity
    {
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
    }

    public interface IAuditEntity<TKey> : IAuditEntity, IDeleteEntity<TKey>
    {
    }
}
