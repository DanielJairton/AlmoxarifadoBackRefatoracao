using AlmoxarifadoDomain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlmoxarifadoInfrastructure.Data.Interfaces
{
    public interface IItensNotaRepository
    {
        List<ItensNota> ObterTodosItensNota();
        ItensNota ObterItensNotaPorId(int item_Num, int id_Pro, int Id_Nota, int id_Sec);
        ItensNota CriarItensNota(ItensNota itensNota);
        ItensNota AtualizarItensNota(int item_Num, int id_Pro, int Id_Nota, int id_Sec, ItensNota itensNota);
        ItensNota DeletarItensNota(int item_Num, int id_Pro, int Id_Nota, int id_Sec);
    }
}
