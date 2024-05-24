using AlmoxarifadoDomain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlmoxarifadoInfrastructure.Data.Interfaces
{
    public interface IRequisicaoRepository
    {
        List<Requisicao> ObterTodasRequicoes();
        Requisicao ObterRequisicaoPorId(int id);
        Requisicao CriarRequicao(Requisicao requisicao);
        Requisicao AtualizarRequicao(int id, Requisicao requisicao);
        Requisicao DeletarRequisicao(int id);
    }
}
