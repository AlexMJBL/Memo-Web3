using System.ComponentModel.DataAnnotations;

namespace Memo.Api.DTO
{
    public class AuthentificationDto
    {
        //Pour retourner apres la connexion ou la creation de compte
        public string NomUtilisateur { get; set; }

        public DateTime DateEmission { get; set; }
    }
}
