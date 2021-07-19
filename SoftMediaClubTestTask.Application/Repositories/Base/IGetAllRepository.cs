using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SoftMediaClubTestTask.Application.Repositories.Base
{
    public interface IGetAllRepository<TEntity> where TEntity : class
    {
        Task<IList<TEntity>> GetAllAsync();
    }
}
