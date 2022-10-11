using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Specifications
{
    public class RoomsWithTypesAndBookingStatusesSpecification : BaseSpecification<Room>
    {
        public RoomsWithTypesAndBookingStatusesSpecification(ParamsSpecification paramsSpec)
            : base (x =>
                (string.IsNullOrEmpty(paramsSpec.Search) || x.RoomName.ToLower().Contains(paramsSpec.Search.ToLower())) &&
                (!paramsSpec.StatusId.HasValue || x.BookingStatusId == paramsSpec.StatusId) &&  
                (!paramsSpec.TypeId.HasValue || x.RoomTypeId == paramsSpec.TypeId)        
            )
        {
            AddInclude(x => x.RoomType);
            AddInclude(x => x.BookingStatus);
            AddOrderBy(x => x.RoomName);
            ApplyPaging(paramsSpec.PageSize * (paramsSpec.PageIndex - 1), paramsSpec.PageSize);

            if(!string.IsNullOrEmpty(paramsSpec.Sort))
            {
                switch(paramsSpec.Sort)
                {
                    case "priceAsc":
                        AddOrderBy(p => p.RoomPrice);
                        break;
                    case "priceDesc":
                        AddOrderByDescending(p => p.RoomPrice);
                        break;
                    default:
                        AddOrderBy(n => n.RoomName);
                        break;
                }
            }
        }

        public RoomsWithTypesAndBookingStatusesSpecification(int id) : base(x => x.Id == id)
        {
            AddInclude(x => x.RoomType);
            AddInclude(x => x.BookingStatus);
        }
    }
}