namespace VsunPharmaWebsite.Models
{
    public class ProductModel
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string Brand { get; set; }
        public decimal RegularPrice { get; set; }
        public decimal DiscountedPrice { get; set; }
        public string SKU { get; set; }
        public string Category { get; set; }
        public bool IsAvailable { get; set; }
        public string ProductImage { get; set; } 
        public string ProductDescription { get; set; }
        public int Quantity { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
