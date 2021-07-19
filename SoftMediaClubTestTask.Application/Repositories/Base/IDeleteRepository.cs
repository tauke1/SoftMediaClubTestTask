using System;
using System.Threading.Tasks;

namespace SoftMediaClubTestTask.Application.Repositories.Base
{
    public interface IDeleteRepository<TEntity> where TEntity: class
    {
        Task DeleteAsync(TEntity entity);
    }
}
