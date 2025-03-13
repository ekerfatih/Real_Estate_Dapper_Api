namespace RealEstate_Dapper_UI.Dtos.ProductDtos {
    public class ResultProductDtos {

        public int productId { get; set; }
        public string title { get; set; }
        public decimal price { get; set; }
        public string city { get; set; }
        public string district { get; set; }
        public string categoryName { get; set; }
        public string coverImage { get; set; }
        public string slugUrl { get; set; }
        public string Type { get; set; }
        public string Address { get; set; }
        public bool DealOfTheDay { get; set; }


    }
}
