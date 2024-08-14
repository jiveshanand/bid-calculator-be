using System.Runtime.Serialization;

namespace BidCalculatorServices.DTOs.enums
{
    public enum VehicleType
    {
        [EnumMember(Value = "common")]
        Common,

        [EnumMember(Value = "luxury")]
        Luxury
    }
}