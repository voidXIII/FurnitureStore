using System.Runtime.Serialization;

namespace Domain.Entities
{
    public enum OrderStatus
    {
        [EnumMember(Value = "In Progress")]
        InProgress,

        [EnumMember(Value = "Payment Received")]
        PaymentRecevied,
        
        [EnumMember(Value = "Payment Failed")]
        PaymentFailed
    }
}