using System;
using System.Threading.Tasks;

namespace SoftMediaClubTestTask.Application.Repositories.Base
{
    public interface IGetRepository<TEntity, TKey> where TEntity: class
    {
        Task<TEntity> GetAsync(TKey id);
    }
}
