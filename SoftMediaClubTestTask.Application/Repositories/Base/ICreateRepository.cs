using System;
using System.Threading.Tasks;
using SoftMediaClubTestTask.Domain.Entities.Base;

namespace SoftMediaClubTestTask.Application.Repositories.Base
{
    public interface ICreateRepository<TEntity>
    {
        Task CreateAsync(TEntity entity);
    }
}
