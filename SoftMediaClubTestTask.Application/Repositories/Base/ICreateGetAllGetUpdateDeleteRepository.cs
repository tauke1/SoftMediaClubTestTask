using System;
namespace SoftMediaClubTestTask.Application.Repositories.Base
{
    public interface ICreateGetAllGetUpdateDeleteRepository<TEntity, TKey> : ICreateRepository<TEntity>, IUpdateRepository<TEntity>,
                        IDeleteRepository<TEntity>, IGetAllRepository<TEntity>, IGetRepository<TEntity, TKey> where TEntity : class
    {
    }
}
