using AlmoxarifadoDomain.Models;
using AlmoxarifadoServices;
using AlmoxarifadoServices.DTO;
using Microsoft.AspNetCore.Mvc;

namespace AlmoxarifadoAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GrupoController : ControllerBase
    {
        private readonly GrupoService _grupoService;
        public GrupoController(GrupoService grupoService)
        {
            _grupoService = grupoService;
        }

  
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var grupos = _grupoService.ObterTodosGrupos();
                return Ok(grupos);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ocorreu um erro ao acessar os dados. Por favor, tente novamente mais tarde.\nErro:{ex}");
            }
         
        }

        [HttpGet("/Grupo/{id}")]
        public IActionResult GetPorID(int id)
        {
            try
            {
                var grupo = _grupoService.ObterGrupoPorID(id);
                if (grupo == null)
                {
                    return StatusCode(404, "Nenhum Usuario Encontrado com Esse Codigo");
                }
                return Ok(grupo);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ocorreu um erro ao acessar os dados. Por favor, tente novamente mais tarde.\nErro:{ex}");
            }

        }

        [HttpPost]
        public IActionResult CriarGrupo(GrupoPostDTO grupo)
        {
            try
            {
                 var grupoSalvo = _grupoService.CriarGrupo(grupo);
                  return Ok(grupoSalvo);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ocorreu um erro ao acessar os dados. Por favor, tente novamente mais tarde.\nErro:{ex}");
            }
        }
    }
}
