using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftMediaClubTestTask.Application.Interfaces.Queries.Base
{
    public interface IGetListOfEntitiesQuery<TEntity>
    {
        Task<IList<TEntity>> ExecuteAsync();
    }
}
