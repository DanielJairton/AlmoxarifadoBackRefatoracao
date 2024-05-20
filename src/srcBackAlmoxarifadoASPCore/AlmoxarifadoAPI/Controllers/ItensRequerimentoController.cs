using AlmoxarifadoDomain.Models;
using AlmoxarifadoServices;
using AlmoxarifadoServices.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AlmoxarifadoAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ItensRequerimentoController : ControllerBase
    {
        private readonly ItensRequerimentoService _itensReqService;
        public ItensRequerimentoController(ItensRequerimentoService itensRequerimentoService)
        {
            _itensReqService = itensRequerimentoService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                List<ItensRequerimentoGetDTO> itensReqs = _itensReqService.ObterTodosItensRequerimentos();
                return Ok(itensReqs);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ocorreu um erro ao acessar os dados. Por favor, tente novamente mais tarde.\nError:{ex}");
            }
        }

        [HttpGet("/ItensRequerimento/{num_Item}/{id_Pro}/{id_Req}/{id_Sec}")]
        public IActionResult GetPorIDs(int num_Item, int id_Pro, int id_Req, int id_Sec) 
        {
            try
            {
                ItensRequerimento itensReqs = _itensReqService.ObterItensRequerimentoPorId(num_Item, id_Pro, id_Req, id_Sec);
                if (itensReqs == null)
                {
                    return StatusCode(404, "Nenhum item de requerimento encontrado com esses IDs");
                }
                return Ok(itensReqs);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ocorreu um erro ao acessar os dados. Por favor, tente novamente mais tarde.\nError:{ex}");
            }
        }

        [HttpPost]
        public IActionResult CriarItensRequerimento(ItensRequerimentoPostDTO itensReqPost)
        {
            try
            {
                ItensRequerimentoGetDTO itensReq = _itensReqService.CriarItensRequerimento(itensReqPost);
                return Ok(itensReq);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ocorreu um erro ao acessar os dados. Por favor, tente novamente mais tarde.\nError:{ex}");
            }
        }

        [HttpPut("/ItensRequerimento/{num_Item}/{id_Pro}/{id_Req}/{id_Sec}")]
        public IActionResult AtualizarItensRequerimento(int num_Item, int id_Pro, int id_Req, int id_Sec, ItensRequerimentoPostDTO itensReqPost)
        {
            try
            {
                ItensRequerimentoGetDTO itensReqAtualizado = _itensReqService.AtualizarItensRequerimento(num_Item, id_Pro, id_Req, id_Sec, itensReqPost);
                if (itensReqAtualizado == null)
                {
                    return StatusCode(404, "Nenhum item de requerimento encontrado com esses IDs");
                }
                return Ok(itensReqAtualizado);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ocorreu um erro ao acessar os dados. Por favor, tente novamente mais tarde.\nError:{ex}");
            }
        }

        [HttpDelete("/ItensRequerimento/{num_Item}/{id_Pro}/{id_Req}/{id_Sec}")]
        public IActionResult DeletarItensRequerimento(int num_Item, int id_Pro, int id_Req, int id_Sec)
        {
            try
            {
                ItensRequerimentoGetDTO itensReqDeletado = _itensReqService.DeletarItensRequerimento(num_Item, id_Pro, id_Req, id_Sec);
                if (itensReqDeletado == null)
                {
                    return StatusCode(404, "Nenhum item de requerimento encontrado com esses IDs");
                }
                return Ok(itensReqDeletado);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ocorreu um erro ao acessar os dados. Por favor, tente novamente mais tarde.\nError:{ex}");
            }
        }
    }
}
