using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftMediaClubTestTask.Domain.Exceptions
{
    public class EntityNotFoundException : Exception
    {
        private const string ERROR_MESSAGE = "Entity with type {0} and primary key {1} not found";
        public string EntityName { get; }
        public object EntityId { get; }
        public EntityNotFoundException(string entityName, object entityId)
        {
            if (entityName == null)
                throw new ArgumentNullException(nameof(entityName));

            if (entityId == null)
                throw new ArgumentNullException(nameof(entityId));

            EntityName = entityName;
            EntityId = entityId;
        }

        public override string Message
        {
            get { return string.Format(ERROR_MESSAGE, EntityName, EntityId);  }
        }
    }
}
