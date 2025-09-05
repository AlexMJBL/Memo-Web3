namespace MemoApp.Api.DTO
{
    public class MemoDto
    {
        public int Id { get; set; }
        public string Titre { get; set; } = null!;
        public string Description { get; set; } = null!;
        public DateTime DateCreation { get; set; }
    }
}
