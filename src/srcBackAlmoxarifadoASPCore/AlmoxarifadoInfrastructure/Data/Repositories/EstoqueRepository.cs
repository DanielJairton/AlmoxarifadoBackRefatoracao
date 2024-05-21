using AlmoxarifadoDomain.Models;
using AlmoxarifadoInfrastructure.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlmoxarifadoInfrastructure.Data.Repositories
{
    public class EstoqueRepository : IEstoqueRepository
    {
        private readonly ContextSQL _context;

        public EstoqueRepository(ContextSQL contextSQL)
        {
            _context = contextSQL;
        }

        public Estoque AumentarEstoque(int id_Sec, int id_Pro,  decimal? qtdPro)
        {
            if (qtdPro.HasValue && qtdPro > 0)
            {
                Estoque estoque = _context.Estoque.Find(id_Sec, id_Pro) 
                    ?? throw new KeyNotFoundException($"Estoque não encontraddo com ID_SEC:{id_Sec} ID_PRO:{id_Pro}");

                estoque.QTD_PRO += qtdPro.Value;
                _context.Estoque.Update(estoque);

                _context.SaveChanges();

                return estoque;
            }
            else
            {
                throw new Exception("Quantidade de produto adicionado inválida para aumento de estoque");
            }
        }

        public Estoque DiminuirEstoque(int id_Sec, int id_Pro, decimal? qtdPro)
        {
            if (qtdPro.HasValue && qtdPro > 0)
            {
                Estoque estoque = _context.Estoque.Find(id_Sec, id_Pro)
                    ?? throw new KeyNotFoundException($"Estoque não encontraddo com ID_SEC:{id_Sec} ID_PRO:{id_Pro}");

                if (estoque.QTD_PRO >= qtdPro)
                {
                    estoque.QTD_PRO -= qtdPro.Value;
                    _context.Estoque.Update(estoque);

                    _context.SaveChanges();

                    return estoque;
                }
                else
                {
                    throw new Exception("Tentativa de tirar mais produtos do que existem no estoque");
                }
            }
            else
            {
                throw new Exception("Quantidade de produto retirada inválida para diminuição de estoque");
            }
        }
    }
}
