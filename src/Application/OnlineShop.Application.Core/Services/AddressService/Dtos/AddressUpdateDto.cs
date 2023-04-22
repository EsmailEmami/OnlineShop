namespace OnlineShop.Application.Core.Services.AddressService.Dtos
{
    public class AddressUpdateDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public int CityId { get; set; }
        public string Plaque { get; set; }
        public string PostalCode { get; set; }
        public string AddressText { get; set; }
    }
}
