using MemoApp.ApplicationCore.Entities;
using MemoApp.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            
            memo.DateCreation = DateTime.Today;

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

            if(memo == null)
            {
                throw new Exception("Le mémo avec l'identifiant spécifié n'existe pas.");
            }

            await _memoRepository.DeleteAsync(memo);


        }


    }
}
