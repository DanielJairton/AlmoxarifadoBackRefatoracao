using AlmoxarifadoDomain.Models;
using AlmoxarifadoInfrastructure.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlmoxarifadoInfrastructure.Data.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly ContextSQL _context;

        public ProdutoRepository(ContextSQL context)
        {
            _context = context;
        }
        public Produto ObterProduto(int id)
        {
            return _context.Produto.Select(e => new Produto
            {
                ID_PRO = e.ID_PRO,
                ID_CLAS = e.ID_CLAS,
                ID_UN_MED = e.ID_UN_MED,
                DESCRICAO = e.DESCRICAO,
                OBSERVACAO = e.OBSERVACAO,
                ESTOQUE_MIN = e.ESTOQUE_MIN,
                PERECIVEL = e.PERECIVEL,
                QTD_EMBALAGEM = e.QTD_EMBALAGEM,
            }).ToList().First(x => x.ID_PRO == id);
        }
    }
}
