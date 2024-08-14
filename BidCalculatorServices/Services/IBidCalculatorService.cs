using BidCalculatorServices.DTOs;

namespace BidCalculatorServices.Services
{
    public interface IBidCalculatorService
    {
        BidCalculationResponseDto CalculateTotal(BidCalculationRequestDto request);
    }
}