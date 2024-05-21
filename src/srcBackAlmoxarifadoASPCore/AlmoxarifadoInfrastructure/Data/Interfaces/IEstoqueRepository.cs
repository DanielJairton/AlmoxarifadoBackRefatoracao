using AlmoxarifadoDomain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlmoxarifadoInfrastructure.Data.Interfaces
{
    public interface IEstoqueRepository
    {
        Estoque AumentarEstoque(int id_Sec, int id_Pro, decimal? qtdPro);
        Estoque DiminuirEstoque(int id_Sec, int id_Pro, decimal? qtdPro);
    }
}
