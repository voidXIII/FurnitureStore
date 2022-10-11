using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace API.Errors
{
    public class EntityAlreadyExistsException : ApplicationException
    {
        private EntityAlreadyExistsException(Type entityType, int firstId, int secondId) 
            : base($"Entity of type { entityType.Name } with unique {firstId} and {secondId} already exist!")
        {
        }

        public static EntityAlreadyExistsException OfType<T>(int firstId, int secondId)
        {
            return new EntityAlreadyExistsException(typeof(T), firstId, secondId);
        }
    }
}