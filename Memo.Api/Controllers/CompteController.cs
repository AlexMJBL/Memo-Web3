using Memo.Api.DTO;
using MemoApi.DTO;
using MemoApp.ApplicationCore.Entities;
using MemoApp.ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MemoApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompteController : ControllerBase
    {
        private readonly ICompteService _compteService;

        public CompteController(ICompteService compteService)
        {
            _compteService = compteService;
        }
        
        // Post: api/<CompteController>
        [HttpPost]
        public async Task<ActionResult<AuthentificationDto>> SeConnecter(InfoConnexionDto Infodto)
        {
            try
            {
                await _compteService.SeConnecterAsync(Infodto.NomUtilisateur, Infodto.MotDePasse);
                AuthentificationDto authenDto = new AuthentificationDto
                    {
                        NomUtilisateur = Infodto.NomUtilisateur,
                        DateEmission = DateTime.UtcNow,
                    };
                return Ok(authenDto);
            }
            catch (Exception ex)
            {
                return BadRequest(new{ message = ex.Message});
            }
        }
        
        // Post: api/<CompteController>
        [HttpPost]
        public async Task<ActionResult<AuthentificationDto>> EnregistrerCompte(ProfileDto dto)
        {
            try
            {
                Compte compte = new Compte
                {
                    NomUtilisateur = dto.NomUtilisateur,
                    MotDePasse = dto.MotDePasse,
                };
                await _compteService.CreerCompteAsync(compte);
                AuthentificationDto authenDto = new AuthentificationDto
                {
                    NomUtilisateur = dto.NomUtilisateur,
                    DateEmission = DateTime.UtcNow,
                };
                return Ok(authenDto);
            }
            catch (UnauthorizedAccessException ex)
            {
                return Unauthorized(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return BadRequest(new{ message = ex.Message});
            }
        }
    }
}
