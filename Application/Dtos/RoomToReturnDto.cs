namespace Application.Dtos
{
    public class RoomToReturnDto
    {
        public int Id { get; set; }
        public int RoomNumber { get; set; }
        public string RoomName { get; set; }
        public string RoomMainImageUrl { get; set; }
        public decimal RoomPrice { get; set; }
        public string BookingStatus {get; set; }
        public string RoomType { get; set; }
        public int RoomCapacity { get; set; }
        public string RoomDescription { get; set; }
    }
}