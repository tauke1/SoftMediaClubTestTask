using System;
namespace SoftMediaClubTestTask.Domain.Entities.Base
{
    public class DeleteEntity<TKey> : BaseEntity<TKey>, IDeleteEntity<TKey>
    {
        public DateTime? DeleteDate { get; set; }
    }
}
