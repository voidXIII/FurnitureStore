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
        public RoomsWithTypesAndBookingStatusesSpecification()
        {
            AddInclude(x => x.RoomType);
            AddInclude(x => x.BookingStatus);
        }

        public RoomsWithTypesAndBookingStatusesSpecification(int id) : base(x => x.Id == id)
        {
            AddInclude(x => x.RoomType);
            AddInclude(x => x.BookingStatus);
        }
    }
}