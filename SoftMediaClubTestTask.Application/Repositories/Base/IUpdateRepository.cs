using System;
using System.Threading.Tasks;

namespace SoftMediaClubTestTask.Application.Repositories.Base
{
    public interface IUpdateRepository<TEntity>
    {
        Task UpdateAsync(TEntity entity);
    }
}
