using MemoApp.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoApp.ApplicationCore.Interfaces
{
    public interface ICompteService
    {
        Task<Compte?> ObtenirCompteParNomAsync(string nomUtilisateur);
        Task<Compte> SeConnecterAsync(string nomUtilisateur, string motDePasse);
        Task<Compte> CreerCompteAsync(Compte compte);
    }
}
