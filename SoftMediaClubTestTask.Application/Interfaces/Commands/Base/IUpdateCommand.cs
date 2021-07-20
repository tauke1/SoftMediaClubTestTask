using System;
using System.Threading.Tasks;

namespace SoftMediaClubTestTask.Application.Interfaces.Commands.Base
{
    public interface IUpdateCommand<TEntity>
    {
        Task ExecuteAsync(TEntity entity);
    }
}
