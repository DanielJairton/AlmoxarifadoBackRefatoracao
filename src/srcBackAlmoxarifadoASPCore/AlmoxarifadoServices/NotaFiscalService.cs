using AlmoxarifadoDomain.Models;
using AlmoxarifadoInfrastructure.Data.Interfaces;
using AlmoxarifadoInfrastructure.Data.Repositories;
using AlmoxarifadoServices.DTO;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlmoxarifadoServices
{
    public class NotaFiscalService
    {
        private readonly INotaFiscalRepository _notaFiscalRepository;
        private readonly MapperConfiguration configurationMapper;

        public NotaFiscalService(INotaFiscalRepository notaFiscalRepository)
        {
            _notaFiscalRepository = notaFiscalRepository;
            configurationMapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<NotaFiscal, NotaFiscalGetDTO>();
                cfg.CreateMap<NotaFiscalGetDTO, NotaFiscal>();
            });
        }

        public List<NotaFiscalGetDTO> ObterTodasNotasFiscais()
        {
            IMapper mapper = configurationMapper.CreateMapper();

            return mapper.Map<List<NotaFiscalGetDTO>>(_notaFiscalRepository.ObterTodasNotasFiscais());
        }

        public NotaFiscal ObterNotaFiscalPorId(int id)
        {
            return _notaFiscalRepository.ObterNotaFiscalPorId(id);
        }

        public NotaFiscalGetDTO CriarNotaFiscal(NotaFiscalPostDTO notaFiscalP)
        {
            var notaFiscalSalva = _notaFiscalRepository.CriarNotaFiscal(
                new NotaFiscal
                {
                    ID_TIPO_NOTA = notaFiscalP.ID_TIPO_NOTA,
                    ID_FOR = notaFiscalP.ID_FOR,
                    ID_SEC = notaFiscalP.ID_SEC,
                    NUM_NOTA = notaFiscalP.NUM_NOTA,
                    VALOR_NOTA = notaFiscalP.VALOR_NOTA,
                    QTD_ITEM = notaFiscalP.QTD_ITEM,
                    ICMS = notaFiscalP.ICMS,
                    ISS = notaFiscalP.ISS,
                    ANO = notaFiscalP.ANO,
                    MES = notaFiscalP.MES,
                    DATA_NOTA = notaFiscalP.DATA_NOTA,
                    OBSERVACAO_NOTA = notaFiscalP.OBSERVACAO_NOTA,
                    EMPENHO_NUM = notaFiscalP.EMPENHO_NUM
                });
            return new NotaFiscalGetDTO
            {
                ID_TIPO_NOTA = notaFiscalSalva.ID_TIPO_NOTA,
                ID_FOR = notaFiscalSalva.ID_FOR,
                ID_SEC = notaFiscalSalva.ID_SEC,
                NUM_NOTA = notaFiscalSalva.NUM_NOTA,
                VALOR_NOTA = notaFiscalSalva.VALOR_NOTA,
                QTD_ITEM = notaFiscalSalva.QTD_ITEM,
                ICMS = notaFiscalSalva.ICMS,
                ISS = notaFiscalSalva.ISS,
                ANO = notaFiscalSalva.ANO,
                MES = notaFiscalSalva.MES,
                DATA_NOTA = notaFiscalSalva.DATA_NOTA,
                OBSERVACAO_NOTA = notaFiscalSalva.OBSERVACAO_NOTA,
                EMPENHO_NUM = notaFiscalSalva.EMPENHO_NUM
            };
        }

        public NotaFiscalGetDTO AtualizarNotaFiscal(int id, NotaFiscalPostDTO notaFiscalP)
        {
            var notaFiscalAtualizada = _notaFiscalRepository.AtualizarNotaFiscal(id, new NotaFiscal
            {
                ID_NOTA = id,
                ID_TIPO_NOTA = notaFiscalP.ID_TIPO_NOTA,
                ID_FOR = notaFiscalP.ID_FOR,
                ID_SEC = notaFiscalP.ID_SEC,
                NUM_NOTA = notaFiscalP.NUM_NOTA,
                VALOR_NOTA = notaFiscalP.VALOR_NOTA,
                QTD_ITEM = notaFiscalP.QTD_ITEM,
                ICMS = notaFiscalP.ICMS,
                ISS = notaFiscalP.ISS,
                ANO = notaFiscalP.ANO,
                MES = notaFiscalP.MES,
                DATA_NOTA = notaFiscalP.DATA_NOTA,
                OBSERVACAO_NOTA = notaFiscalP.OBSERVACAO_NOTA,
                EMPENHO_NUM = notaFiscalP.EMPENHO_NUM
            });

            return new NotaFiscalGetDTO
            {
                ID_TIPO_NOTA = notaFiscalAtualizada.ID_TIPO_NOTA,
                ID_FOR = notaFiscalAtualizada.ID_FOR,
                ID_SEC = notaFiscalAtualizada.ID_SEC,
                NUM_NOTA = notaFiscalAtualizada.NUM_NOTA,
                VALOR_NOTA = notaFiscalAtualizada.VALOR_NOTA,
                QTD_ITEM = notaFiscalAtualizada.QTD_ITEM,
                ICMS = notaFiscalAtualizada.ICMS,
                ISS = notaFiscalAtualizada.ISS,
                ANO = notaFiscalAtualizada.ANO,
                MES = notaFiscalAtualizada.MES,
                DATA_NOTA = notaFiscalAtualizada.DATA_NOTA,
                OBSERVACAO_NOTA = notaFiscalAtualizada.OBSERVACAO_NOTA,
                EMPENHO_NUM = notaFiscalAtualizada.EMPENHO_NUM
            };
        }

        public NotaFiscalGetDTO DeletarNotaFiscal(int id)
        {
            NotaFiscal notaFiscal = _notaFiscalRepository.DeletarNotaFiscal(id);
            return new NotaFiscalGetDTO {
                ID_TIPO_NOTA = notaFiscal.ID_TIPO_NOTA,
                ID_FOR = notaFiscal.ID_FOR,
                ID_SEC = notaFiscal.ID_SEC,
                NUM_NOTA = notaFiscal.NUM_NOTA,
                VALOR_NOTA = notaFiscal.VALOR_NOTA,
                QTD_ITEM = notaFiscal.QTD_ITEM,
                ICMS = notaFiscal.ICMS,
                ISS = notaFiscal.ISS,
                ANO = notaFiscal.ANO,
                MES = notaFiscal.MES,
                DATA_NOTA = notaFiscal.DATA_NOTA,
                OBSERVACAO_NOTA = notaFiscal.OBSERVACAO_NOTA,
                EMPENHO_NUM = notaFiscal.EMPENHO_NUM
            };
        }
    }
}
