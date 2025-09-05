namespace Memo.Api.DTO
{
    public class AuthentificationDto
    {
        //Pour retourner apres la connexion ou la creation de compte
        public string NomUtilisateur { get; set; } = null!;
        public DateTime DateEmission { get; set; }
    }
}
