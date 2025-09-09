using MemoApp.ApplicationCore.Entities;
using MemoApp.ApplicationCore.Interfaces;
using System.Security.Cryptography;
using System.Text;

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
            if (string.IsNullOrWhiteSpace(compte.NomUtilisateur) || compte.NomUtilisateur.Length > 150)
                throw new Exception("Le nom d'utilisateur est obligatoire et ne peut pas dépasser 150 caractères.");

            if (string.IsNullOrWhiteSpace(compte.MotDePasse) || compte.MotDePasse.Length > 150)
                throw new Exception("Le mot de passe est obligatoire et ne peut pas dépasser 150 caractères.");

            Compte? compteExistant = await ObtenirCompteParNomAsync(compte.NomUtilisateur);

            if (compteExistant != null)
            {
                throw new Exception("Un compte avec ce nom d'utilisateur existe déjà.");
            }

            using (var hmac = new HMACSHA512())
            {
                var hashBytes = hmac.ComputeHash(Encoding.UTF8.GetBytes(compte.MotDePasse));
                compte.MotDePasse = Convert.ToBase64String(hashBytes);
                compte.Salt = hmac.Key;
            }

            compte.DateCreation = DateTime.Now;
            compte.DateDerniereConnexion = DateTime.Now;
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

            if (compte == null)
            {
                throw new UnauthorizedAccessException("Nom d'utilisateur invalide");
            }

            using (var hmac = new HMACSHA512(compte.Salt))
            {
                var hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(motDePasse));
                var hashString = Convert.ToBase64String(hash);
                if (hashString != compte.MotDePasse)
                    throw new UnauthorizedAccessException("Mot de passe incorrect.");
            }

            compte.DateDerniereConnexion = DateTime.Now;
            await _compteRepository.EditAsync(compte);

            return compte;
        }

        public async Task<Compte?> ObtenirCompteParNomAsync(string nomUtilisateur)
        {
            var compte = await _compteRepository.GetSingleAsync(c => c.NomUtilisateur.ToLower() == nomUtilisateur.ToLower());
            return compte;
        }
    }
}
