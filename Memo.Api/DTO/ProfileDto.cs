namespace MemoApi.DTO
{
    public class ProfileDto
    {
        //Pas nessaire pour le moment , mais pourrait servir a l'avenir si on veut ajouter des infos au profile ex : email , nom , prenom etc
        //Offre une meilleure structure pour l'avenir

        public string NomUtilisateur { get; set; } = null!;

        public string MotDePasse { get; set; } = null!;
    }
}
