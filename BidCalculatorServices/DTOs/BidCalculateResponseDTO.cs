namespace BidCalculatorServices.DTOs
{
    public class BidCalculationResponseDto
    {
        public decimal BasicBuyerFee { get; set; }
        public decimal SpecialFee { get; set; }
        public decimal AssociationFee { get; set; }
        public decimal StorageFee { get; set; } = 100;
        public decimal TotalCost { get; set; }
    }
}
