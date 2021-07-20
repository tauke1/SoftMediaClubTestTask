using System;
using System.Threading.Tasks;
using SoftMediaClubTestTask.Domain.Entities.Base;

namespace SoftMediaClubTestTask.Application.Interfaces.Commands.Base
{
    public interface ICreateCommand<TEntity>
    {
        Task ExecuteAsync(TEntity entity);
    }
}
