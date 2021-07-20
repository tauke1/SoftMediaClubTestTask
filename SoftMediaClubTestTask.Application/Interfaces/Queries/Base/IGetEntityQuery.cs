using SoftMediaClubTestTask.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftMediaClubTestTask.Application.Interfaces.Queries.Base
{
    public interface IGetEntityQuery<TEntity, TKey> where TEntity: BaseEntity<TKey>
    {
        Task<TEntity> ExecuteAsync(TKey id);
    }
}
