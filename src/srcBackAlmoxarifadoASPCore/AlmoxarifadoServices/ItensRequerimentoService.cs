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
    public class ItensRequerimentoService
    {
        private readonly IItensRequerimentoRepository _itensRequerimentoRepository;
        private readonly MapperConfiguration configurationMapper;

        public ItensRequerimentoService(IItensRequerimentoRepository itensRequerimentoRepository)
        {
            _itensRequerimentoRepository = itensRequerimentoRepository;
            configurationMapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ItensRequerimento, ItensRequerimentoGetDTO>();
                cfg.CreateMap<ItensRequerimentoGetDTO, ItensRequerimento>();
            });
        }

        public List<ItensRequerimentoGetDTO> ObterTodosItensRequerimentos()
        {
            IMapper mapper = configurationMapper.CreateMapper();

            return mapper.Map<List<ItensRequerimentoGetDTO>>(_itensRequerimentoRepository.ObterTodosItensRequerimentos());
        }

        public ItensRequerimento ObterItensRequerimentoPorId(int num_Item, int id_Pro, int id_Req, int id_Sec)
        {
            return _itensRequerimentoRepository.ObterItensRequerimentoPorId(num_Item, id_Pro, id_Req, id_Sec);
        }

        public ItensRequerimentoGetDTO CriarItensRequerimento(ItensRequerimentoPostDTO itensRequerimentoP)
        {
            ItensRequerimento itensRequerimento = _itensRequerimentoRepository.CriarItensRequerimento(
                new ItensRequerimento
                {
                    NUM_ITEM = itensRequerimentoP.NUM_ITEM,
                    ID_PRO = itensRequerimentoP.ID_PRO,
                    ID_REQ = itensRequerimentoP.ID_REQ,
                    ID_SEC = itensRequerimentoP.ID_SEC,
                    QTD_PRO = itensRequerimentoP.QTD_PRO,
                    PRE_UNIT = itensRequerimentoP.PRE_UNIT,
                    TOTAL_REAL = itensRequerimentoP.TOTAL_REAL
                });
            return new ItensRequerimentoGetDTO
            {
                NUM_ITEM = itensRequerimento.NUM_ITEM,
                ID_PRO = itensRequerimento.ID_PRO,
                ID_REQ = itensRequerimento.ID_REQ,
                ID_SEC = itensRequerimento.ID_SEC,
                QTD_PRO = itensRequerimento.QTD_PRO,
                PRE_UNIT = itensRequerimento.PRE_UNIT,
                TOTAL_ITEM = itensRequerimento.TOTAL_ITEM,
                TOTAL_REAL = itensRequerimento.TOTAL_REAL
            };
        }

        public ItensRequerimentoGetDTO AtualizarItensRequerimento(int num_Item, int id_Pro, int id_Req, int id_Sec, ItensRequerimentoPostDTO itensRequerimento)
        {
            ItensRequerimento itensReqAtualizado = _itensRequerimentoRepository.AtualizarItensRequerimento(num_Item, id_Pro, id_Req, id_Sec, 
                new ItensRequerimento
                {
                    NUM_ITEM = itensRequerimento.NUM_ITEM,
                    ID_PRO = itensRequerimento.ID_PRO,
                    ID_REQ = itensRequerimento.ID_REQ,
                    ID_SEC = itensRequerimento.ID_SEC,
                    QTD_PRO = itensRequerimento.QTD_PRO,
                    PRE_UNIT = itensRequerimento.PRE_UNIT,
                    TOTAL_REAL = itensRequerimento.TOTAL_REAL
                });

            return new ItensRequerimentoGetDTO
            {
                NUM_ITEM = itensReqAtualizado.NUM_ITEM,
                ID_PRO = itensReqAtualizado.ID_PRO,
                ID_REQ = itensReqAtualizado.ID_REQ,
                ID_SEC = itensReqAtualizado.ID_SEC,
                QTD_PRO = itensReqAtualizado.QTD_PRO,
                PRE_UNIT = itensReqAtualizado.PRE_UNIT,
                TOTAL_ITEM = itensReqAtualizado.TOTAL_ITEM,
                TOTAL_REAL = itensReqAtualizado.TOTAL_REAL
            };
        }

        public ItensRequerimentoGetDTO DeletarItensRequerimento(int num_Item, int id_Pro, int id_Req, int id_Sec)
        {
            ItensRequerimento itens = _itensRequerimentoRepository.DeletarItensRequerimento(num_Item, id_Pro, id_Req, id_Sec);
            return new ItensRequerimentoGetDTO
            {
                NUM_ITEM = itens.NUM_ITEM,
                ID_PRO = itens.ID_PRO,
                ID_REQ = itens.ID_REQ,
                ID_SEC = itens.ID_SEC,
                QTD_PRO = itens.QTD_PRO,
                PRE_UNIT = itens.PRE_UNIT,
                TOTAL_ITEM = itens.TOTAL_ITEM,
                TOTAL_REAL = itens.TOTAL_REAL
            };
        }
    }
}
