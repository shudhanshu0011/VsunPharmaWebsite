namespace VsunPharmaWebsite.Models
{
    public class ProductReview
    {
        public int ProductReviewId { get; set; }
        public int ProductId { get; set; }
        public string CustomerName { get; set; }
        public string ReviewText { get; set; }
        public int Rating { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
