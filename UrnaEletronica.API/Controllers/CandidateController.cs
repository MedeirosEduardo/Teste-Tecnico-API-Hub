using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Threading.Tasks;
using UrnaEletronica.Domain;
using UrnaEletronica.Interface;

namespace UrnaEletronica.API.Controllers
{
    [ApiController]
    [Route("candidate/")]
    public class CandidateController : AppBaseController
    {
        public CandidateController(IServiceProvider serviceProvider, IConfiguration configuration) : base(serviceProvider, configuration)
        {
        }

        [HttpPost]
        public async Task<ActionResult<dynamic>> RegisterCandidate([FromBody] CandidateDTO model)
        {
            var candidateRepository = GetService<ICandidateRepository>();

            try
            {
                if (!candidateRepository.CheckIfItIsRegistered(model.FullName, model.PartyLegend))
                {
                    if (await candidateRepository.SaveNewCandidate(model) == 1)
                        return Ok("Sucesso: Candidato Registrado Com Sucesso!");

                    else
                        throw new Exception("Erro: Houve um problema com a requisição.");
                }
                else
                {
                    throw new Exception("Erro: Já existe um candidato cadastrado com essas informações!");
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        [Route("{partyLegend}")]
        public async Task<ActionResult<dynamic>> GetCandidate(int partyLegend)
        {
            var candidateRepository = GetService<ICandidateRepository>();
            try
            {
                if (await candidateRepository.CheckIfItIsRegistered(partyLegend))
                {

                    return Ok(candidateRepository.GetCandidateByPartyLegend(partyLegend));
                }
                else
                {
                    throw new Exception("Erro: O Candidato não está cadastrado!");
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        [HttpDelete]
        public async Task<ActionResult<dynamic>> DeleteCandidate([FromBody] DeleteCandidateDTO model)
        {
            var candidateRepository = GetService<ICandidateRepository>();

            try
            {
                if (await candidateRepository.CheckIfItIsRegistered(model.PartyLegend))
                {
                    if (await candidateRepository.DeleteCandidate(model.PartyLegend) == 1)
                        return Ok("Sucesso: Candidato Deletado Com Sucesso!");

                    else
                        throw new Exception("Erro: Houve Um Problema Com A Requisição.");
                }
                else
                {
                    throw new Exception("Erro: O Candidato Não Está Cadastrado!");
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
