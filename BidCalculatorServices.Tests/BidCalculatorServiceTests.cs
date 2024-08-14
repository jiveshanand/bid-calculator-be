using Xunit;
using BidCalculatorServices.Services;
using BidCalculatorServices.DTOs;
using BidCalculatorServices.DTOs.enums;

namespace BidCalculatorServices.Tests.Services
{
    public class BidCalculatorServiceTests
    {
        private readonly BidCalculatorService _service;

        public BidCalculatorServiceTests()
        {
            _service = new BidCalculatorService();
        }

        [Theory]
        [InlineData(398.00, VehicleType.Common, 550.76, 39.80, 7.96, 5.00, 100.00)]
        [InlineData(501.00, VehicleType.Common, 671.02, 50.00, 10.02, 10.00, 100.00)]
        [InlineData(57.00, VehicleType.Common, 173.14, 10.00, 1.14, 5.00, 100.00)]
        [InlineData(1800.00, VehicleType.Luxury, 2167.00, 180.00, 72.00, 15.00, 100.00)]
        [InlineData(1100.00, VehicleType.Common, 1287.00, 50.00, 22.00, 15.00, 100.00)]
        [InlineData(1000000.00, VehicleType.Luxury, 1040320.00, 200.00, 40000.00, 20.00, 100.00)]
        public void CalculateTotal_ShouldReturnExpectedResult(
            decimal basePrice,
            VehicleType vehicleType,
            decimal expectedTotalCost,
            decimal expectedBasicBuyerFee,
            decimal expectedSpecialFee,
            decimal expectedAssociationFee,
            decimal expectedStorageFee)
        {
            var request = new BidCalculationRequestDto
            {
                BasePrice = basePrice,
                VehicleType = vehicleType
            };
         
            var result = _service.CalculateTotal(request);

            Assert.Equal(expectedTotalCost, result.TotalCost);
            Assert.Equal(expectedBasicBuyerFee, result.BasicBuyerFee);
            Assert.Equal(expectedSpecialFee, result.SpecialFee);
            Assert.Equal(expectedAssociationFee, result.AssociationFee);
            Assert.Equal(expectedStorageFee, result.StorageFee);
        }
    }
}
