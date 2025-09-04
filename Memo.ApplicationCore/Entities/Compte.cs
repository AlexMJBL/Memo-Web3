using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Memo.ApplicationCore.Entities
{
        public class Compte
        {
            [Key]
            public string Id { get; set; }
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
