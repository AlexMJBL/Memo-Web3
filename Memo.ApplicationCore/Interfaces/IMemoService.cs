using MemoApp.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoApp.ApplicationCore.Interfaces
{
    public interface IMemoService
    {
        Task<IEnumerable<Memo>> ObtenirMemoParCompteAsync(string idCompte);
        Task SuprimerAsync(int id);
        Task<Memo> AjouterAsync(Memo memo);

    }
}
