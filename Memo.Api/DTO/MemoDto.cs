using System.ComponentModel.DataAnnotations;

namespace MemoApp.Api.DTO
{
    public class MemoDto
    {
        public int Id { get; set; }

        public string Titre { get; set; }

        public string Description { get; set; }

        public DateTime DateCreation { get; set; }
    }
}
