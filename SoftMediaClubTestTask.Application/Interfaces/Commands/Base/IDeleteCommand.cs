using SoftMediaClubTestTask.Domain.Entities.Base;
using System;
using System.Threading.Tasks;

namespace SoftMediaClubTestTask.Application.Interfaces.Commands.Base
{
    public interface IDeleteCommand<TEntity, TKey> where TEntity : BaseEntity<TKey>
    {
        Task ExecuteAsync(TEntity entity);
    }
}
