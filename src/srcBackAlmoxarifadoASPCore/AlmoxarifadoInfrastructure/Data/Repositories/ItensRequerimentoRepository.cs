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
        private readonly EstoqueRepository _estoqueRepository;

        public ItensRequerimentoRepository(ContextSQL context)
        {
            _context = context;
            _estoqueRepository = new EstoqueRepository(context);
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
        public ItensRequerimento CriarItensRequerimento(ItensRequerimento itensReq)
        {
            try
            {
                Estoque estoque = _estoqueRepository.DiminuirEstoque(itensReq.ID_SEC, itensReq.ID_PRO, itensReq.QTD_PRO);

                _context.Itens_Req.Add(itensReq);
                _context.SaveChanges();

                return itensReq;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public ItensRequerimento AtualizarItensRequerimento(int num_Item, int id_Pro, int id_Req, int id_Sec, ItensRequerimento itensReq)
        {
            ItensRequerimento itensReqAtualizado = _context.Itens_Req.Find(num_Item, id_Pro, id_Req, id_Sec);
            if (itensReqAtualizado == null)
            {
                throw new KeyNotFoundException("Item de requerimento com esses IDs não encontrado.");
            }

            try
            {
                decimal quantidadeAtual = itensReqAtualizado.QTD_PRO;
                decimal quantidadeNova = itensReq.QTD_PRO;

                if (quantidadeAtual >= 0 && quantidadeNova >= 0)
                {
                    if (quantidadeAtual < quantidadeNova)
                    {
                        decimal diferencaQtd = quantidadeNova - quantidadeAtual;
                        _estoqueRepository.DiminuirEstoque(itensReq.ID_SEC, itensReq.ID_PRO, diferencaQtd);
                    }
                    else if (quantidadeAtual > quantidadeNova)
                    {
                        decimal diferencaQtd = quantidadeAtual - quantidadeNova;
                        _estoqueRepository.AumentarEstoque(itensReq.ID_SEC, itensReq.ID_PRO, diferencaQtd);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            itensReqAtualizado.NUM_ITEM = itensReq.NUM_ITEM;
            itensReqAtualizado.ID_PRO = itensReq.ID_PRO;
            itensReqAtualizado.ID_REQ = itensReq.ID_REQ;
            itensReqAtualizado.ID_SEC = itensReq.ID_SEC;
            itensReqAtualizado.QTD_PRO = itensReq.QTD_PRO;
            itensReqAtualizado.PRE_UNIT = itensReq.PRE_UNIT;
            itensReqAtualizado.TOTAL_ITEM = itensReq.TOTAL_ITEM;
            itensReqAtualizado.TOTAL_REAL = itensReq.TOTAL_REAL;

            _context.SaveChanges();

            return itensReqAtualizado;
        }
        public ItensRequerimento DeletarItensRequerimento(int num_Item, int id_Pro, int id_Req, int id_Sec)
        {
            ItensRequerimento itensReq = _context.Itens_Req.Find(num_Item, id_Pro, id_Req, id_Sec);
            if (itensReq == null )
            {
                throw new KeyNotFoundException("Item de requerimento com esses IDs não encontrado.");
            }

            _context.Itens_Req.Remove(itensReq);
            _context.SaveChanges();

            return itensReq;
        }
    }
}
