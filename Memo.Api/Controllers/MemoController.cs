using MemoApp.Api.DTO;
using MemoApp.ApplicationCore.Entities;
using MemoApp.ApplicationCore.Interfaces;

using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MemoApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemoController : ControllerBase
    {
        private readonly IMemoService  _memoService;
        private readonly ICompteService _compteService;

        public MemoController(IMemoService memoService, ICompteService compteService)
        {
            _memoService = memoService;
            _compteService = compteService;
        }
        

        // GET api/<ValuesController>/5
        [HttpGet("[action]/{nomUtilisateur}")]
        public async Task<ActionResult<IEnumerable<MemoDto>>> Get(string nomUtilisateur)
        {
            try
            {
                Compte? compte =await _compteService.ObtenirCompteParNomAsync(nomUtilisateur);
                
                if (compte == null)
                {
                    return NotFound(new { message = "Compte non trouvé." });
                }
                
                var memos = await _memoService.ObtenirMemoParCompteAsync(compte.Id); 
                
                var memosDto = memos
                    .Select(memo => new MemoDto
                    {
                        Id = memo.Id,
                        Titre = memo.Titre,
                        Description = memo.Description,
                        DateCreation = memo.DateCreation
                    })
                    .ToList();
                
                return Ok(memosDto);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        // POST api/<ValuesController>
        [HttpPost("[action]/{nomUtilisateur}")]
        public async Task<ActionResult<MemoDto>> Ajouter([FromBody] MemoDto memoDto, [FromRoute] string nomUtilisateur)
        {
            try
            {
                var compte = await _compteService.ObtenirCompteParNomAsync(nomUtilisateur);
                if(compte == null) 
                {
                    return NotFound("Aucun compte avec ce nom d'utilisateur.");
                }
                var memo = new ApplicationCore.Entities.Memo
                {
                    Titre = memoDto.Titre,
                    Description = memoDto.Description,
                    IdCompte = compte.Id
                };
                await _memoService.AjouterAsync(memo);
                
                var memoRetour = new MemoDto
                {
                    Id = memo.Id,
                    Titre = memo.Titre,
                    Description = memo.Description,
                    DateCreation = memo.DateCreation
                };
                
                return  Ok(memoRetour);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }
        
        // DELETE api/<ValuesController>/5
        [HttpDelete("[action]/{id}")]
        public async Task<ActionResult> Supprimer(int id)
        {
            try
            {
                await _memoService.SuprimerAsync(id);
                return Ok("Memo supprimer avec succès");
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }
    }
}
