using System.ComponentModel.DataAnnotations;

namespace MemoApp.ApplicationCore.Entities
{
    public class Compte : BaseEntity<string>
    {
        [Required]
        [StringLength(150)]
        public string NomUtilisateur { get; set; }
        [Required]
        [StringLength(150)]
        public string MotDePasse { get; set; }
        [Required]
        public DateTime DateCreation { get; set; }
        public DateTime? DateDerniereConnexion { get; set; }

        public ICollection<Memo> Memos { get; set; } = new List<Memo>();
    }
}
