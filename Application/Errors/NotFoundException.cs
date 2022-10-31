using System;

namespace Application.Errors
{
    public class NotFoundException : ApplicationException
    {
        private NotFoundException(Type entityType, int id) : base($"Entity of type { entityType.Name } with id: { id } not found")
        {
        }

        private NotFoundException(Type entityType) : base($"Entity of type { entityType.Name } not found")
        {
        }

        public static NotFoundException OfType<T>(int id)
        {
            return new NotFoundException(typeof(T), id);
        }

        public static NotFoundException OfType<T>()
        {
            return new NotFoundException(typeof(T));
        }
    }
}