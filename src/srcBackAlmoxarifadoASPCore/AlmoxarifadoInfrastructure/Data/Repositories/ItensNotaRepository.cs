using AlmoxarifadoDomain.Models;
using AlmoxarifadoInfrastructure.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlmoxarifadoInfrastructure.Data.Repositories
{
    public class ItensNotaRepository : IItensNotaRepository
    {
        private readonly ContextSQL _context;
        private readonly EstoqueRepository _estoqueRepository;

        public ItensNotaRepository(ContextSQL context)
        {
            _context = context;
            _estoqueRepository = new EstoqueRepository(context);
        }

        public List<ItensNota> ObterTodosItensNota()
        {
            return _context.Itens_Nota.Select(e => new ItensNota {
                ITEM_NUM = e.ITEM_NUM,
                ID_PRO = e.ID_PRO,
                ID_NOTA = e.ID_NOTA,
                ID_SEC = e.ID_SEC,
                QTD_PRO = e.QTD_PRO,
                PRE_UNIT = e.PRE_UNIT,
                TOTAL_ITEM = e.TOTAL_ITEM,
                EST_LIN = e.EST_LIN
            }).ToList();
        }
        public ItensNota ObterItensNotaPorId(int item_Num, int id_Pro, int Id_Nota, int id_Sec)
        {
            return _context.Itens_Nota.Select(e => new ItensNota
            {
                ITEM_NUM = e.ITEM_NUM,
                ID_PRO = e.ID_PRO,
                ID_NOTA = e.ID_NOTA,
                ID_SEC = e.ID_SEC,
                QTD_PRO = e.QTD_PRO,
                PRE_UNIT = e.PRE_UNIT,
                TOTAL_ITEM = e.TOTAL_ITEM,
                EST_LIN = e.EST_LIN
            }).ToList().First(x => x.ITEM_NUM == item_Num && x.ID_PRO == id_Pro && x.ID_NOTA == Id_Nota && x.ID_SEC == id_Sec);
        }
        public ItensNota CriarItensNota(ItensNota itensNota)
        {
            _context.Itens_Nota.Add(itensNota);
            _context.SaveChanges();

            _estoqueRepository.AumentarEstoque(itensNota.ID_SEC, itensNota.ID_PRO, itensNota.QTD_PRO);

            return itensNota;
        }
        public ItensNota AtualizarItensNota(int item_Num, int id_Pro, int id_Nota, int id_Sec, ItensNota itensNota)
        {
            ItensNota itensNotaExistente = _context.Itens_Nota.Find(item_Num, id_Pro, id_Nota, id_Sec);

            if (itensNotaExistente == null)
            {
                throw new KeyNotFoundException($"ItensNota não encontraddo com ITEM_NUM:{item_Num} ID_PRO:{id_Pro} ID_NOTA:{id_Nota} ID_SEC:{id_Sec}");
            }

            decimal quantidadeAtual = itensNotaExistente.QTD_PRO ?? 0;
            decimal quantidadeNova = itensNota.QTD_PRO ?? 0;

            itensNotaExistente.ITEM_NUM = itensNota.ITEM_NUM;
            itensNotaExistente.ID_PRO = itensNota.ID_PRO;
            itensNotaExistente.ID_NOTA = itensNota.ID_NOTA;
            itensNotaExistente.ID_SEC = itensNota.ID_SEC;
            itensNotaExistente.QTD_PRO = itensNota.QTD_PRO;
            itensNotaExistente.PRE_UNIT = itensNota.PRE_UNIT;
            itensNotaExistente.TOTAL_ITEM = itensNota.TOTAL_ITEM;
            itensNotaExistente.EST_LIN = itensNota.EST_LIN;

            _context.SaveChanges();

            if (quantidadeAtual > 0 && quantidadeNova >0)
            {
                if (quantidadeAtual > quantidadeNova)
                {
                    decimal diferencaQtd = quantidadeAtual - quantidadeNova;
                    _estoqueRepository.DiminuirEstoque(itensNota.ID_SEC, itensNota.ID_PRO, diferencaQtd);
                }
                else if (quantidadeAtual < quantidadeNova)
                {
                    decimal diferencaQtd = quantidadeNova - quantidadeAtual;
                    _estoqueRepository.AumentarEstoque(itensNota.ID_SEC, itensNota.ID_PRO, diferencaQtd);
                }
            }

            return itensNotaExistente;
        }
        public ItensNota DeletarItensNota(int item_Num, int id_Pro, int id_Nota, int id_Sec)
        {
            ItensNota itensNota = _context.Itens_Nota.Find(item_Num, id_Pro, id_Nota, id_Sec);
            if(itensNota == null)
            {
                throw new KeyNotFoundException($"ItensNota não encontraddo com ITEM_NUM:{item_Num} ID_PRO:{id_Pro} ID_NOTA:{id_Nota} ID_SEC:{id_Sec}");
            }

            _context.Itens_Nota.Remove(itensNota);
            _context.SaveChanges();

            return itensNota;
        }
    }
}
