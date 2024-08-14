using BidCalculatorServices.DTOs.enums;

namespace BidCalculatorServices.DTOs
{
    public class BidCalculationRequestDto
    {
        public decimal BasePrice { get; set; }
        public VehicleType VehicleType { get; set; }
    }
}
