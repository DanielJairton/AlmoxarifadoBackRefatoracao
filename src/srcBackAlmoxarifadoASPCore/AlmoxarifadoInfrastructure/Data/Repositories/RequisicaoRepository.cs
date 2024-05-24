using AlmoxarifadoDomain.Models;
using AlmoxarifadoInfrastructure.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlmoxarifadoInfrastructure.Data.Repositories
{
    public class RequisicaoRepository : IRequisicaoRepository
    {
        private readonly ContextSQL _context;

        public RequisicaoRepository(ContextSQL context)
        {
            _context = context;
        }

        public List<Requisicao> ObterTodasRequicoes()
        {
            return _context.Requisicao
                .Select(e => new Requisicao
                {
                    ID_REQ = e.ID_REQ,
                    ID_CLI = e.ID_CLI,
                    TOTAL_REQ = e.TOTAL_REQ,
                    QTD_ITEN = e.QTD_ITEN,
                    DATA_REQ = e.DATA_REQ,
                    ANO = e.ANO,
                    MES = e.MES,
                    ID_SEC = e.ID_SEC,
                    ID_SET = e.ID_SET,
                    OBSERVACAO = e.OBSERVACAO ?? ""
                }).ToList();
        }
        public Requisicao ObterRequisicaoPorId(int id)
        {
            return _context.Requisicao
                .Select(e => new Requisicao
                {
                    ID_REQ = e.ID_REQ,
                    ID_CLI = e.ID_CLI,
                    TOTAL_REQ = e.TOTAL_REQ,
                    QTD_ITEN = e.QTD_ITEN,
                    DATA_REQ = e.DATA_REQ,
                    ANO = e.ANO,
                    MES = e.MES,
                    ID_SEC = e.ID_SEC,
                    ID_SET = e.ID_SET,
                    OBSERVACAO = e.OBSERVACAO ?? ""
                }).ToList().First(x => x?.ID_REQ == id);
        }
        public Requisicao CriarRequicao(Requisicao requisicao)
        {
            _context.Requisicao.Add(requisicao);
            _context.SaveChanges();
            return requisicao;
        }
        public Requisicao AtualizarRequicao(int id, Requisicao requisicao)
        {
            Requisicao requisicaoExistente = _context.Requisicao.Find(id);
            if (requisicaoExistente == null)
            {
                throw new KeyNotFoundException($"Requisição com ID {id} não encontrada.");
            }
            requisicaoExistente.ID_CLI = requisicao.ID_CLI;
            requisicaoExistente.TOTAL_REQ = requisicao.TOTAL_REQ;
            requisicaoExistente.QTD_ITEN = requisicao.QTD_ITEN;
            requisicaoExistente.DATA_REQ = requisicao.DATA_REQ;
            requisicaoExistente.ANO = requisicao.ANO;
            requisicaoExistente.MES = requisicao.MES;
            requisicaoExistente.ID_SEC = requisicao.ID_SEC;
            requisicaoExistente.ID_SET = requisicao.ID_SET;
            requisicaoExistente.OBSERVACAO = requisicao.OBSERVACAO;

            _context.SaveChanges();

            return requisicaoExistente;
        }
        public Requisicao DeletarRequisicao(int id)
        {
            Requisicao requisicao = _context.Requisicao.Find(id);
            if (requisicao == null)
            {
                throw new KeyNotFoundException($"Requisição com ID {id} não encontrada.");
            }

            _context.Requisicao.Remove(requisicao);
            _context.SaveChanges();

            return requisicao;
        }
    }
}
