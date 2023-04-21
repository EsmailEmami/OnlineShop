namespace OnlineShop.Application.Core.Services.ProductItemSellerService.Dtos
{
    public class ProductItemSellerOutputDto
    {
        public Guid Id { get; set; }
        public Guid ProductItemId { get; set; }
        public Guid ProductId { get; set; }
        public string ProductName { get; set; }

        public long SellerId { get; set; }
        public string StoreName { get; set; }
        public string SellerFirstName { get; set; }
        public string SellerLastName { get; set; }
        public string SellerUserName { get; set; }
        public string SellerPhoneNumber { get; set; }

        public double Quantity { get; set; }

        public bool IsActive { get; set; }

    }
}
