using AlmoxarifadoDomain.Models;
using AlmoxarifadoInfrastructure.Data.Interfaces;
using AlmoxarifadoServices.DTO;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlmoxarifadoServices
{
    public class RequisicaoService
    {
        private readonly IRequisicaoRepository _requisicaoRepository;
        private readonly MapperConfiguration configurationMapper;

        public RequisicaoService(IRequisicaoRepository requisicaoRepository)
        {
            _requisicaoRepository = requisicaoRepository;
            configurationMapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Requisicao, RequisicaoGetDTO>();
                cfg.CreateMap<RequisicaoGetDTO, Requisicao>();
            });
        }

        public List<RequisicaoGetDTO> ObterTodasRequicoes()
        {
            IMapper mapper = configurationMapper.CreateMapper();

            return mapper.Map<List<RequisicaoGetDTO>>(_requisicaoRepository.ObterTodasRequicoes());
        }

        public Requisicao ObterRequisicaoPorId(int id)
        {
            return _requisicaoRepository.ObterRequisicaoPorId(id);
        }

        public RequisicaoGetDTO CriarRequicao(RequisicaoPostDTO requisicao)
        {
            Requisicao requisicaoSalva = _requisicaoRepository.CriarRequicao(
                new Requisicao
                {
                    ID_CLI = requisicao.ID_CLI,
                    TOTAL_REQ = requisicao.TOTAL_REQ,
                    QTD_ITEN = requisicao.QTD_ITEN,
                    DATA_REQ = requisicao.DATA_REQU,
                    ANO = requisicao.ANO,
                    MES = requisicao.MES,
                    ID_SEC = requisicao.ID_SEC,
                    ID_SET = requisicao.ID_SET,
                    OBSERVACAO = requisicao.OBSERVACAO
                });
            return new RequisicaoGetDTO
            {
                ID_CLI = requisicaoSalva.ID_CLI,
                TOTAL_REQ = requisicaoSalva.TOTAL_REQ,
                QTD_ITEN = requisicaoSalva.QTD_ITEN,
                DATA_REQ = requisicaoSalva.DATA_REQ,
                ANO = requisicaoSalva.ANO,
                MES = requisicaoSalva.MES,
                ID_SEC = requisicaoSalva.ID_SEC,
                ID_SET = requisicaoSalva.ID_SET,
                OBSERVACAO = requisicaoSalva.OBSERVACAO
            };
        }

        public RequisicaoGetDTO AtualizarRequicao(int id, RequisicaoPostDTO requisicaoP)
        {
            Requisicao requisicaoAtualizada = _requisicaoRepository.AtualizarRequicao(id,
                new Requisicao
                {
                    ID_CLI = requisicaoP.ID_CLI,
                    TOTAL_REQ = requisicaoP.TOTAL_REQ,
                    QTD_ITEN = requisicaoP.QTD_ITEN,
                    DATA_REQ = requisicaoP.DATA_REQU,
                    ANO = requisicaoP.ANO,
                    MES = requisicaoP.MES,
                    ID_SEC = requisicaoP.ID_SEC,
                    ID_SET = requisicaoP.ID_SET,
                    OBSERVACAO = requisicaoP.OBSERVACAO
                });

            return new RequisicaoGetDTO
            {
                ID_REQ = requisicaoAtualizada.ID_REQ,
                ID_CLI = requisicaoAtualizada.ID_CLI,
                TOTAL_REQ = requisicaoAtualizada.TOTAL_REQ,
                QTD_ITEN = requisicaoAtualizada.QTD_ITEN,
                DATA_REQ = requisicaoAtualizada.DATA_REQ,
                ANO = requisicaoAtualizada.ANO,
                MES = requisicaoAtualizada.MES,
                ID_SEC = requisicaoAtualizada.ID_SEC,
                ID_SET = requisicaoAtualizada.ID_SET,
                OBSERVACAO = requisicaoAtualizada.OBSERVACAO
            };
        }

        public RequisicaoGetDTO DeletarRequisicao(int id)
        {
            Requisicao requisicao = _requisicaoRepository.DeletarRequisicao(id);

            return new RequisicaoGetDTO
            {
                ID_REQ = requisicao.ID_REQ,
                ID_CLI = requisicao.ID_CLI,
                TOTAL_REQ = requisicao.TOTAL_REQ,
                QTD_ITEN = requisicao.QTD_ITEN,
                DATA_REQ = requisicao.DATA_REQ,
                ANO = requisicao.ANO,
                MES = requisicao.MES,
                ID_SEC = requisicao.ID_SEC,
                ID_SET = requisicao.ID_SET,
                OBSERVACAO = requisicao.OBSERVACAO
            };
        }
    }
}
