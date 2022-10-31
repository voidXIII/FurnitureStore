
using Domain.Entities;

namespace Application.Specifications
{
    public class RoomWithFiltersForCountSpecification : BaseSpecification<Room>
    {
        public RoomWithFiltersForCountSpecification(ParamsSpecification paramsSpec) : base(x =>
        (string.IsNullOrEmpty(paramsSpec.Search) || x.RoomName.ToLower().Contains(paramsSpec.Search)) &&
        (!paramsSpec.StatusId.HasValue || x.BookingStatusId == paramsSpec.StatusId) &&
        (!paramsSpec.TypeId.HasValue || x.RoomTypeId == paramsSpec.TypeId))
        {

        }
    }
}