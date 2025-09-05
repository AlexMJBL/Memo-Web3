using MemoApp.ApplicationCore.Entities;
using MemoApp.ApplicationCore.Interfaces;

namespace MemoApp.ApplicationCore.Services
{
    public class CompteService : ICompteService
    {
        private readonly IAsyncRepository<Compte, string> _compteRepository;

        public CompteService(IAsyncRepository<Compte, string> compteRepository)
        {
            _compteRepository = compteRepository;
        }

        public async Task<Compte> CreerCompteAsync(Compte compte)
        {
            if (string.IsNullOrWhiteSpace(compte.MotDePasse) || string.IsNullOrWhiteSpace(compte.NomUtilisateur))
            {
                throw new Exception("Le nom d'utilisateur et le mot de passe ne doivent pas etre vide .");
            }

            Compte? compteExistant = await ObtenirCompteParNomAsync(compte.NomUtilisateur);

            if (compteExistant != null)
            {
                throw new Exception("Un compte avec ce nom d'utilisateur existe déjà.");
            }

            compte.DateCreation = DateTime.Today;
            await _compteRepository.AddAsync(compte);

            return compte;
        }

        public async Task<Compte> SeConnecterAsync(string nomUtilisateur, string motDePasse)
        {
            if (string.IsNullOrWhiteSpace(nomUtilisateur) || string.IsNullOrWhiteSpace(motDePasse))
            {
                throw new Exception("Le nom d'utilisateur et le mot de passe ne doivent pas etre vide .");
            }

            Compte? compte = await ObtenirCompteParNomAsync(nomUtilisateur);

            if (compte == null || compte.MotDePasse != motDePasse)
            {
                throw new Exception("Nom d'utilisateur ou mot de passe incorrect.");
            }

            compte.DateDerniereConnexion = DateTime.UtcNow;
            await _compteRepository.EditAsync(compte);

            return compte;
        }

        public async Task<Compte?> ObtenirCompteParNomAsync(string nomUtilisateur)
        {
            return await _compteRepository.GetSingleAsync(c => c.NomUtilisateur.ToLower() == nomUtilisateur.ToLower());
        }

    }
}
