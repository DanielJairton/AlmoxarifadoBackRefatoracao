using AlmoxarifadoDomain.Models;
using AlmoxarifadoServices;
using AlmoxarifadoServices.DTO;
using Microsoft.AspNetCore.Mvc;

namespace AlmoxarifadoAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NotaFiscalController : ControllerBase
    {
        private readonly NotaFiscalService _notaFiscalService;
        public NotaFiscalController(NotaFiscalService notaFiscalService)
        {
            _notaFiscalService = notaFiscalService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                List<NotaFiscalGetDTO> notasFiscais = _notaFiscalService.ObterTodasNotasFiscais();
                return Ok(notasFiscais);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ocorreu um erro ao acessar os dados. Por favor, tente novamente mais tarde.\nError:{ex}");
            }
        }

        [HttpGet("/NotaFiscal/{id}")]
        public IActionResult GetPorID(int id) 
        {
            try
            {
                NotaFiscal notaFiscal = _notaFiscalService.ObterNotaFiscalPorId(id);
                if (notaFiscal == null)
                {
                    return StatusCode(404, "Nenhuma Nota Fiscal Encontrado com Esse Codigo");
                }
                return Ok(notaFiscal);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ocorreu um erro ao acessar os dados. Por favor, tente novamente mais tarde.\nError:{ex}");
            }
        }

        [HttpPost]
        public IActionResult CriarNotaFiscal(NotaFiscalPostDTO notaFiscal)
        {
            try
            {
                NotaFiscalGetDTO notaFiscalSalva = _notaFiscalService.CriarNotaFiscal(notaFiscal);
                return Ok(notaFiscalSalva);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ocorreu um erro ao acessar os dados. Por favor, tente novamente mais tarde.\nError:{ex}");
            }
        }

        [HttpPut("/NotaFiscal/{id}")]
        public IActionResult AtualizarNotaFiscal(int id, NotaFiscalPostDTO notaFiscal)
        {
            try
            {
                NotaFiscalGetDTO notaFiscalAtualizada = _notaFiscalService.AtualizarNotaFiscal(id, notaFiscal);
                if (notaFiscalAtualizada == null)
                {
                    return StatusCode(404, "Nenhuma Nota Fiscal Encontrado com Esse Codigo");
                }
                return Ok(notaFiscalAtualizada);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ocorreu um erro ao acessar os dados. Por favor, tente novamente mais tarde.\nError:{ex}");
            }
        }

        [HttpDelete("/NotaFiscal/{id}")]
        public IActionResult DeletarNotaFiscal(int id)
        {
            try
            {
                NotaFiscalGetDTO notaFiscalDeletada = _notaFiscalService.DeletarNotaFiscal(id);
                if (notaFiscalDeletada == null)
                {
                    return StatusCode(404, "Nenhuma Nota Fiscal Encontrado com Esse Codigo");
                }
                return Ok(notaFiscalDeletada);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ocorreu um erro ao acessar os dados. Por favor, tente novamente mais tarde.\nError:{ex}");
            }
        }
    }
}
