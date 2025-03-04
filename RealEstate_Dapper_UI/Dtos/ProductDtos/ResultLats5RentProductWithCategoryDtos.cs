namespace RealEstate_Dapper_UI.Dtos.ProductDtos;

public class ResultLats5RentProductWithCategoryDtos {
    public int ProductId { get; set; }
    public string? Title { get; set; }
    public decimal Price { get; set; }
    public string? City { get; set; }
    public string? District { get; set; }
    public int CategoryId { get; set; }
    public string? CategoryName { get; set; }
    public DateTime AdvertisementDate { get; set; }
}
