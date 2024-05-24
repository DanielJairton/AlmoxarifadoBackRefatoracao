using AlmoxarifadoDomain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlmoxarifadoInfrastructure.Data.Interfaces
{
    public interface IItensRequerimentoRepository
    {
        List<ItensRequerimento> ObterTodosItensRequerimentos();
        ItensRequerimento ObterItensRequerimentoPorId(int num_Item, int id_Pro, int id_Req, int id_Sec);
        ItensRequerimento CriarItensRequerimento(ItensRequerimento itensRequerimento);
        ItensRequerimento AtualizarItensRequerimento(int num_Item, int id_Pro, int id_Req, int id_Sec, ItensRequerimento itensRequerimento);
        ItensRequerimento DeletarItensRequerimento(int num_Item, int id_Pro, int id_Req, int id_Sec);
    }
}
