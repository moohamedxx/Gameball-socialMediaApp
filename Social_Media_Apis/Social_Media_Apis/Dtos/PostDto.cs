using Core.Entities;

namespace Social_Media_Apis.Dtos
{
    public class PostDto
    {
        public int Id {  get; set; }
        public string Title { get; set; }
        public string UserName { get; set; }
        public string PictureUrl { get; set; }
        public int UserId { get; set; }
        public DateTime DateOfCreation { get; set; }
        public UserEntity User { get; set; }
        public ICollection<CommentEntity> Comments { get; set; }
    }
}
