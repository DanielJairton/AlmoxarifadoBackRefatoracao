using AlmoxarifadoDomain.Models;
using AlmoxarifadoServices;
using AlmoxarifadoServices.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AlmoxarifadoAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ItensNotaController : ControllerBase
    {
        private readonly ItensNotaService _itensNotaService;
        public ItensNotaController(ItensNotaService itensNotaService)
        {
            _itensNotaService = itensNotaService;
        }

        [HttpGet]
        public IActionResult Get() 
        {
            try
            {
                List<ItensNotaGetDTO> itensNota = _itensNotaService.ObterTodosItensNota();
                return Ok(itensNota);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ocorreu um erro ao acessar os dados. Por favor, tente novamente mais tarde.\nError:{ex}");
            }
        }

        [HttpGet("/NotaFiscal/{item_Num}/{id_Pro}/{id_Nota}/{id_Sec}")]
        public IActionResult GetPorIDs(int item_Num, int id_Pro, int id_Nota, int id_Sec)
        {
            try
            {
                ItensNota itensNota = _itensNotaService.ObterItensNotaPorId(item_Num, id_Pro, id_Nota, id_Sec);
                if (itensNota == null)
                {
                    return StatusCode(404, "Nenhum item de nota fiscal Encontrado com esses IDs");
                }
                return Ok(itensNota);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ocorreu um erro ao acessar os dados. Por favor, tente novamente mais tarde.\nError:{ex}");
            }
        }

        [HttpPost]
        public IActionResult CriarItensNota(ItensNotaPostDTO itensNota)
        {
            try
            {
                ItensNotaGetDTO itensNotaSalvo = _itensNotaService.CriarItensNota(itensNota);
                return Ok(itensNotaSalvo);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ocorreu um erro ao acessar os dados. Por favor, tente novamente mais tarde.\nError:{ex}");
            }
        }

        [HttpPut("/NotaFiscal/{item_Num}/{id_Pro}/{id_Nota}/{id_Sec}")]
        public IActionResult AtualizarItensNota(int item_Num, int id_Pro, int id_Nota, int id_Sec, ItensNotaPostDTO itensNota)
        {
            try
            {
                ItensNotaGetDTO itensNotaSalvo = _itensNotaService.AtualizarItensNota(item_Num, id_Pro, id_Nota, id_Sec, itensNota);
                if (itensNotaSalvo == null)
                {
                    return StatusCode(404, "Nenhum Item Nota Encontrado com Esses IDs");
                }
                return Ok(itensNotaSalvo);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ocorreu um erro ao acessar os dados. Por favor, tente novamente mais tarde.\nError:{ex}");
            }
        }

        [HttpDelete("/NotaFiscal/{item_Num}/{id_Pro}/{id_Nota}/{id_Sec}")]
        public IActionResult DeletarItensNota(int item_Num, int id_Pro, int id_Nota, int id_Sec)
        {
            try
            {
                ItensNotaGetDTO itensNotaDeletado = _itensNotaService.DeletarItensNota(item_Num, id_Pro, id_Nota, id_Sec);
                if (itensNotaDeletado == null)
                {
                    return StatusCode(404, "Nenhum Item Nota Encontrado com Esses IDs");
                }
                return Ok(itensNotaDeletado);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ocorreu um erro ao acessar os dados. Por favor, tente novamente mais tarde.\nError:{ex}");
            }
        }
    }
}
