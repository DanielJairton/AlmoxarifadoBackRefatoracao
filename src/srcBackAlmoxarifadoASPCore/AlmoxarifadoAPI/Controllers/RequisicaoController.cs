using AlmoxarifadoDomain.Models;
using AlmoxarifadoServices;
using AlmoxarifadoServices.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AlmoxarifadoAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RequisicaoController : ControllerBase
    {
        private readonly RequisicaoService _requisicaoService;
        public RequisicaoController(RequisicaoService requisicaoService)
        {
            _requisicaoService = requisicaoService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                List<RequisicaoGetDTO> requisicoes = _requisicaoService.ObterTodasRequicoes();
                return Ok(requisicoes);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ocorreu um erro ao acessar os dados. Por favor, tente novamente mais tarde.\nError:{ex}");
            }
        }

        [HttpGet("/Requisicao/{id}")]
        public IActionResult GetPorId(int id)
        {
            try
            {
                Requisicao requisicao = _requisicaoService.ObterRequisicaoPorId(id);
                if (requisicao == null)
                {
                    return StatusCode(404, "Nenhuma Requisição Encontrada com Esse Codigo");
                }
                return Ok(requisicao);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ocorreu um erro ao acessar os dados. Por favor, tente novamente mais tarde.\nError:{ex}");
            }
        }

        [HttpPost]
        public IActionResult CriarRequicao(RequisicaoPostDTO requisicao)
        {
            try
            {
                RequisicaoGetDTO requisicaoSalva = _requisicaoService.CriarRequicao(requisicao);
                return Ok(requisicaoSalva);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ocorreu um erro ao acessar os dados. Por favor, tente novamente mais tarde.\nError:{ex}");
            }
        }

        [HttpPut("/Requisicao/{id}")]
        public IActionResult AtualizarRequicao(int id, RequisicaoPostDTO requisicao)
        {
            try
            {
                RequisicaoGetDTO requisicaoAtualizada = _requisicaoService.AtualizarRequicao(id, requisicao);
                if (requisicaoAtualizada == null)
                {
                    return StatusCode(404, "Nenhuma Requisição Encontrada com Esse Codigo");
                }
                return Ok(requisicaoAtualizada);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ocorreu um erro ao acessar os dados. Por favor, tente novamente mais tarde.\nError:{ex}");
            }
        }

        [HttpDelete("/Requisicao/{id}")]
        public IActionResult DeletarRequisicao(int id)
        {
            try
            {
                RequisicaoGetDTO requisicaoDeletada = _requisicaoService.DeletarRequisicao(id);
                if (requisicaoDeletada == null)
                {
                    return StatusCode(404, "Nenhuma Requisição Encontrada com Esse Codigo");
                }
                return Ok(requisicaoDeletada);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ocorreu um erro ao acessar os dados. Por favor, tente novamente mais tarde.\nError:{ex}");
            }
        }
    }
}
