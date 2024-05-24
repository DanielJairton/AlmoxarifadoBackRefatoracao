using AlmoxarifadoDomain.Models;
using AlmoxarifadoInfrastructure.Data.Enum;
using AlmoxarifadoInfrastructure.Data.Interfaces;
using AlmoxarifadoServices.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlmoxarifadoServices
{
    public class EstoqueService
    {
        private readonly IEstoqueRepository _estoqueRepository;
        private readonly ProdutoService _produtoService;

        public EstoqueService(IEstoqueRepository estoqueRepository, ProdutoService produtoService)
        {
            _estoqueRepository = estoqueRepository;
            _produtoService = produtoService;
        }

        public EstoqueGetDTO AumentarEstoque(int id_Sec, int id_Pro, decimal? qtdPro)
        {
            Estoque estoque = _estoqueRepository.AumentarEstoque(id_Sec, id_Pro, qtdPro);

            return new EstoqueGetDTO
            {
                ID_PRO = estoque.ID_PRO,
                ID_SEC = estoque.ID_SEC,
                QTD_PRO = estoque.QTD_PRO
            };
        }

        public EstoqueGetDTO DiminuirEstoque(int id_Sec, int id_Pro, decimal? qtdPro, int id_Transacao, EnumTipoTransacao tipoTransacao)
        {
            Estoque estoque = _estoqueRepository.DiminuirEstoque(id_Sec, id_Pro, qtdPro, id_Transacao, tipoTransacao);

            return new EstoqueGetDTO
            {
                ID_PRO = estoque.ID_PRO,
                ID_SEC = estoque.ID_SEC,
                QTD_PRO = estoque.QTD_PRO
            };
        }
    }
}
