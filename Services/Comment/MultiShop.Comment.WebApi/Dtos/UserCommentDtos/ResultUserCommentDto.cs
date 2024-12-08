namespace MultiShop.Comment.WebApi.Dtos.UserCommentDtos
{
    public class ResultUserCommentDto
    {
        public int Id { get; set; }
        public string ProductId { get; set; }
        public string CommentDetail { get; set; }
        public int Rating { get; set; }
        public string FullName { get; set; }
        public string? ImageUrl { get; set; }
        public string Email { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool Status { get; set; }
    }
}
