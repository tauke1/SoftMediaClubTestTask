using System;
namespace SoftMediaClubTestTask.Domain.Entities.Base
{
    public class AuditEntity<TKey> : DeleteEntity<TKey>, IAuditEntity<TKey>
    {
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}
