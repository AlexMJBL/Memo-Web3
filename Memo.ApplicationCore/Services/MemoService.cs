using MemoApp.ApplicationCore.Entities;
using MemoApp.ApplicationCore.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace MemoApp.ApplicationCore.Services
{
    public class MemoService : IMemoService
    {
        private readonly IAsyncRepository<Memo, int> _memoRepository;
        public MemoService(IAsyncRepository<Memo, int> memoRepository)
        {
            _memoRepository = memoRepository;
        }

        public async Task<Memo> AjouterAsync(Memo memo)
        {
            if(memo == null)
            {
                throw new ArgumentNullException(nameof(memo), "Le mémo ne peut pas être nul.");
            }
            if(memo.IdCompte == null)
            {
                throw new ArgumentException("L'identifiant du compte ne peut pas être nul.", nameof(memo.IdCompte));
            }

            if (string.IsNullOrWhiteSpace(memo.Titre) || memo.Titre.Length > 150)
                throw new ArgumentException("Le titre est obligatoire et doit contenir au maximum 150 caractères.", nameof(memo.Titre));

            if (string.IsNullOrWhiteSpace(memo.Description) || memo.Description.Length > 150)
                throw new ArgumentException("La description est obligatoire et doit contenir au maximum 150 caractères.", nameof(memo.Description));

            memo.DateCreation = DateTime.Now;

            await _memoRepository.AddAsync(memo);

            return memo;
        }

        public async Task<IEnumerable<Memo>> ObtenirMemoParCompteAsync(string idCompte)
        {
            if (string.IsNullOrWhiteSpace(idCompte))
            {
                throw new ArgumentException("L'identifiant du compte ne peut pas être nul ou vide.", nameof(idCompte));
            }

            return await _memoRepository.ListAsync(m => m.IdCompte.ToLower() == idCompte.ToLower());
        }

        public async  Task SuprimerAsync(int id)
        {
            Memo memo = await _memoRepository.GetByIdAsync(id);
            await _memoRepository.DeleteAsync(memo);
        }


    }
}
