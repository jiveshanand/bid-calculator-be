using BidCalculatorServices.Controllers;
using BidCalculatorServices.DTOs.enums;
using BidCalculatorServices.DTOs;
using BidCalculatorServices.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace BidCalculatorServices.Tests.Controllers
{
    public class BidCalculationControllerTests
    {
        private readonly Mock<IBidCalculatorService> _mockBidCalculatorService;
        private readonly BidCalculationController _controller;

        public BidCalculationControllerTests()
        {
            _mockBidCalculatorService = new Mock<IBidCalculatorService>();
            _controller = new BidCalculationController(_mockBidCalculatorService.Object);
        }

        [Fact]
        public void Calculate_ShouldReturnOkResult_WithValidData()
        {
            // Arrange
            var request = new BidCalculationRequestDto
            {
                BasePrice = 1000,
                VehicleType = VehicleType.Common
            };
            var expectedResponse = new BidCalculationResponseDto
            {
                TotalCost = 1180,
                BasicBuyerFee = 50,
                SpecialFee = 20,
                AssociationFee = 10,
                StorageFee = 100
            };

            _mockBidCalculatorService
                .Setup(service => service.CalculateTotal(request))
                .Returns(expectedResponse);

            // Act
            var result = _controller.Calculate(request) as OkObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(200, result.StatusCode);
            var resultValue = result.Value as BidCalculationResponseDto;
            Assert.Equal(expectedResponse.TotalCost, resultValue.TotalCost);
            Assert.Equal(expectedResponse.BasicBuyerFee, resultValue.BasicBuyerFee);
            Assert.Equal(expectedResponse.SpecialFee, resultValue.SpecialFee);
            Assert.Equal(expectedResponse.AssociationFee, resultValue.AssociationFee);
            Assert.Equal(expectedResponse.StorageFee, resultValue.StorageFee);
        }

        [Fact]
        public void Calculate_ShouldReturnBadRequest_WhenRequestIsNull()
        {
            // Arrange
            BidCalculationRequestDto request = null;

            // Act
            var result = _controller.Calculate(request) as BadRequestResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(400, result.StatusCode);
        }
    }
}
