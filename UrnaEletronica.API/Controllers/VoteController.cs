using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Threading.Tasks;
using UrnaEletronica.Domain;
using UrnaEletronica.Interface;

namespace UrnaEletronica.API.Controllers
{
    [ApiController]
    public class VoteController : AppBaseController
    {
        public VoteController(IServiceProvider serviceProvider, IConfiguration configuration) : base(serviceProvider, configuration)
        {
        }

        [HttpPost]
        [Route("vote")]
        public async Task<ActionResult<dynamic>> RegisterVote([FromBody] VoteDTO model)
        {
            var candidateRepository = GetService<ICandidateRepository>();
            var voteRepository = GetService<IVoteRepository>();
            try
            {
                Candidate entity = await candidateRepository.RegistreVoteAndGetCandidate(model.partyLegend);

                if (await voteRepository.RegisterVote(entity.IdCandidate) == 1)
                {
                    return Ok("Sucesso: Voto computado com sucesso!");
                }
                else
                {
                    throw new Exception("Erro: Não Existe Um Candidato Com Essa Legenda.");
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        [Route("votes")]
        public async Task<ActionResult<dynamic>> ReturnAllCandidatesWithVotes()
        {
            var candidateRepository = GetService<ICandidateRepository>();

            try
            {
                return Ok(candidateRepository.GetAllCandidates());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
