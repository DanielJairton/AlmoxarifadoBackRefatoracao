using AlmoxarifadoDomain.Models;
using AlmoxarifadoInfrastructure.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlmoxarifadoInfrastructure.Data.Repositories
{
    public class ItensRequerimentoRepository : IItensRequerimentoRepository
    {
        private readonly ContextSQL _context;

        public ItensRequerimentoRepository(ContextSQL context)
        {
            _context = context;
        }

        public List<ItensRequerimento> ObterTodosItensRequerimentos()
        {
            return _context.Itens_Req
                .Select(e => new ItensRequerimento
                {
                    NUM_ITEM = e.NUM_ITEM,
                    ID_PRO = e.ID_PRO,
                    ID_REQ = e.ID_REQ,
                    ID_SEC = e.ID_SEC,
                    QTD_PRO = e.QTD_PRO,
                    PRE_UNIT = e.PRE_UNIT,
                    TOTAL_ITEM = e.TOTAL_ITEM,
                    TOTAL_REAL = e.TOTAL_REAL
                }).ToList();
        }
        public ItensRequerimento ObterItensRequerimentoPorId(int num_Item, int id_Pro, int id_Req, int id_Sec)
        {
            return _context.Itens_Req
                .Select(e => new ItensRequerimento
                {
                    NUM_ITEM = e.NUM_ITEM,
                    ID_PRO = e.ID_PRO,
                    ID_REQ = e.ID_REQ,
                    ID_SEC = e.ID_SEC,
                    QTD_PRO = e.QTD_PRO,
                    PRE_UNIT = e.PRE_UNIT,
                    TOTAL_ITEM = e.TOTAL_ITEM,
                    TOTAL_REAL = e.TOTAL_REAL
                }).ToList().First(x => x.NUM_ITEM == num_Item && x.ID_PRO == id_Pro && x.ID_REQ == id_Req && x.ID_SEC == id_Sec);
        }
        public ItensRequerimento CriarItensRequerimento(ItensRequerimento itensRequerimento)
        {
            _context.Itens_Req.Add(itensRequerimento);
            _context.SaveChanges();
            return itensRequerimento;
        }
        public ItensRequerimento AtualizarItensRequerimento(int num_Item, int id_Pro, int id_Req, int id_Sec, ItensRequerimento itensRequerimento)
        {
            ItensRequerimento itensRequerimentoAtualizado = _context.Itens_Req.Find(num_Item, id_Pro, id_Req, id_Sec);
            if (itensRequerimentoAtualizado == null)
            {
                throw new KeyNotFoundException("Item de requerimento com esses IDs não encontrado.");
            }
            itensRequerimentoAtualizado.NUM_ITEM = itensRequerimento.NUM_ITEM;
            itensRequerimentoAtualizado.ID_PRO = itensRequerimento.ID_PRO;
            itensRequerimentoAtualizado.ID_REQ = itensRequerimento.ID_REQ;
            itensRequerimentoAtualizado.ID_SEC = itensRequerimento.ID_SEC;
            itensRequerimentoAtualizado.QTD_PRO = itensRequerimento.QTD_PRO;
            itensRequerimentoAtualizado.PRE_UNIT = itensRequerimento.PRE_UNIT;
            itensRequerimentoAtualizado.TOTAL_ITEM = itensRequerimento.TOTAL_ITEM;
            itensRequerimentoAtualizado.TOTAL_REAL = itensRequerimento.TOTAL_REAL;

            _context.SaveChanges();

            return itensRequerimentoAtualizado;
        }
        public ItensRequerimento DeletarItensRequerimento(int num_Item, int id_Pro, int id_Req, int id_Sec)
        {
            ItensRequerimento itensRequerimento = _context.Itens_Req.Find(num_Item, id_Pro, id_Req, id_Sec);
            if (itensRequerimento == null )
            {
                throw new KeyNotFoundException("Item de requerimento com esses IDs não encontrado.");
            }

            _context.Itens_Req.Remove(itensRequerimento);
            _context.SaveChanges();

            return itensRequerimento;
        }
    }
}
