using BidCalculatorServices.DTOs;
using BidCalculatorServices.DTOs.enums;

namespace BidCalculatorServices.Services
{
    public class BidCalculatorService : IBidCalculatorService
    {
        private const decimal FixedStorageFee = 100;

        public BidCalculationResponseDto CalculateTotal(BidCalculationRequestDto request)
        {
            var basicBuyerFee = CalculateBasicBuyerFee(request.BasePrice, request.VehicleType);
            var specialFee = CalculateSpecialFee(request.BasePrice, request.VehicleType);
            var associationFee = CalculateAssociationFee(request.BasePrice);

            var response = new BidCalculationResponseDto
            {
                BasicBuyerFee = basicBuyerFee,
                SpecialFee = specialFee,
                AssociationFee = associationFee,
                StorageFee = FixedStorageFee,
                TotalCost = request.BasePrice + basicBuyerFee + specialFee + associationFee + FixedStorageFee
            };

            return response;
        }

        private decimal CalculateBasicBuyerFee(decimal basePrice, VehicleType vehicleType)
        {
            var fee = basePrice * 0.1m;
            return vehicleType == VehicleType.Common
                ? Math.Min(Math.Max(fee, 10), 50)
                : Math.Min(Math.Max(fee, 25), 200);
        }

        private decimal CalculateSpecialFee(decimal basePrice, VehicleType vehicleType)
        {
            return vehicleType == VehicleType.Common ? basePrice * 0.02m : basePrice * 0.04m;
        }

        private decimal CalculateAssociationFee(decimal basePrice)
        {
            return basePrice switch
            {
                <= 500 => 5,
                <= 1000 => 10,
                <= 3000 => 15,
                _ => 20
            };
        }
    }
}
