namespace OnlineShop.Application.Core.Services.CityService.Dtos
{
    public class CityOutputDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }

        public int StateId { get; set; }
        public string StateName { get; set; }
    }
}
