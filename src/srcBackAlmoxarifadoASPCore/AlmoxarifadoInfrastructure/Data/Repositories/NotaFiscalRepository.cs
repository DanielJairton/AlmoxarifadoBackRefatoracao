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
    public class NotaFiscalRepository : INotaFiscalRepository
    {
        private readonly ContextSQL _context;

        public NotaFiscalRepository(ContextSQL context)
        {
            _context = context;
        }

        public List<NotaFiscal> ObterTodasNotasFiscais()
        {
            return _context.Nota_Fiscal
                .Select(e => new NotaFiscal
                {
                    ID_NOTA = e.ID_NOTA,
                    ID_TIPO_NOTA = e.ID_TIPO_NOTA,
                    ID_FOR = e.ID_FOR,
                    ID_SEC = e.ID_SEC,
                    NUM_NOTA = e.NUM_NOTA,
                    VALOR_NOTA = e.VALOR_NOTA,
                    QTD_ITEM = e.QTD_ITEM,
                    ICMS = e.ICMS,
                    ISS = e.ISS,
                    ANO = e.ANO,
                    MES = e.MES,
                    DATA_NOTA = e.DATA_NOTA,
                    OBSERVACAO_NOTA = e.OBSERVACAO_NOTA ?? "",
                    EMPENHO_NUM = e.EMPENHO_NUM
                }).ToList();
        }

        public NotaFiscal ObterNotaFiscalPorId(int id)
        {
            return _context.Nota_Fiscal
                .Select(e => new NotaFiscal
                {
                    ID_NOTA = e.ID_NOTA,
                    ID_TIPO_NOTA = e.ID_TIPO_NOTA,
                    ID_FOR = e.ID_FOR,
                    ID_SEC = e.ID_SEC,
                    NUM_NOTA = e.NUM_NOTA,
                    VALOR_NOTA = e.VALOR_NOTA,
                    QTD_ITEM = e.QTD_ITEM,
                    ICMS = e.ICMS,
                    ISS = e.ISS,
                    ANO = e.ANO,
                    MES = e.MES,
                    DATA_NOTA = e.DATA_NOTA,
                    OBSERVACAO_NOTA = e.OBSERVACAO_NOTA ?? "",
                    EMPENHO_NUM = e.EMPENHO_NUM
                })
                .ToList().First(x => x?.ID_NOTA == id);
        }
        public NotaFiscal CriarNotaFiscal(NotaFiscal notaFiscal)
        {
            _context.Nota_Fiscal.Add(notaFiscal);
            _context.SaveChanges();
            return notaFiscal;
        }

        public NotaFiscal AtualizarNotaFiscal(int id, NotaFiscal notaFiscal)
        {
            var notaFiscalExistente = _context.Nota_Fiscal.Find(id);
            if (notaFiscalExistente == null)
            {
                throw new KeyNotFoundException($"Nota fiscal com ID {id} não encontrada.");
            }
            notaFiscalExistente.ID_TIPO_NOTA = notaFiscal.ID_TIPO_NOTA;
            notaFiscalExistente.ID_FOR = notaFiscal.ID_FOR;
            notaFiscalExistente.ID_SEC = notaFiscal.ID_SEC;
            notaFiscalExistente.NUM_NOTA = notaFiscal.NUM_NOTA;
            notaFiscalExistente.VALOR_NOTA = notaFiscal.VALOR_NOTA;
            notaFiscalExistente.QTD_ITEM = notaFiscal.QTD_ITEM;
            notaFiscalExistente.ICMS = notaFiscal.ICMS;
            notaFiscalExistente.ISS = notaFiscal.ISS;
            notaFiscalExistente.ANO = notaFiscal.ANO;
            notaFiscalExistente.MES = notaFiscal.MES;
            notaFiscalExistente.DATA_NOTA = notaFiscal.DATA_NOTA;
            notaFiscalExistente.OBSERVACAO_NOTA = notaFiscal.OBSERVACAO_NOTA;
            notaFiscalExistente.EMPENHO_NUM = notaFiscal.EMPENHO_NUM;

            _context.SaveChanges();

            return notaFiscalExistente;
        }

        public NotaFiscal DeletarNotaFiscal(int id)
        {
            NotaFiscal notaFiscal = _context.Nota_Fiscal.Find(id);
            if (notaFiscal == null)
            {
                throw new KeyNotFoundException($"Nota fiscal com ID {id} não encontrada.");
            }

            _context.Nota_Fiscal.Remove(notaFiscal);
            _context.SaveChanges();

            return notaFiscal;
        }
    }
}
