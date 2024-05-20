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
    public class ItensNotaService
    {
        private readonly IItensNotaRepository _itensNotaRepository;
        private readonly MapperConfiguration configurationMapper;

        public ItensNotaService(IItensNotaRepository itensNotaRepository)
        {
            _itensNotaRepository = itensNotaRepository;
            configurationMapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ItensNota, ItensNotaGetDTO>();
                cfg.CreateMap<ItensNotaGetDTO, ItensNota>();
            });
        }

        public List<ItensNotaGetDTO> ObterTodosItensNota()
        {
            IMapper mapper = configurationMapper.CreateMapper();

            return mapper.Map<List<ItensNotaGetDTO>>(_itensNotaRepository.ObterTodosItensNota());
        }

        public ItensNota ObterItensNotaPorId(int item_Num, int id_Pro, int Id_Nota, int id_Sec)
        {
            return _itensNotaRepository.ObterItensNotaPorId(item_Num, id_Pro, Id_Nota, id_Sec);
        }

        public ItensNotaGetDTO CriarItensNota(ItensNotaPostDTO itensNotaP)
        {
            ItensNota itensNota = _itensNotaRepository.CriarItensNota(
                new ItensNota
                {
                    ITEM_NUM = itensNotaP.ITEM_NUM,
                    ID_PRO = itensNotaP.ID_PRO,
                    ID_NOTA = itensNotaP.ID_NOTA,
                    ID_SEC = itensNotaP.ID_SEC,
                    QTD_PRO = itensNotaP.QTD_PRO,
                    PRE_UNIT = itensNotaP.PRE_UNIT,
                    EST_LIN = itensNotaP.EST_LIN
                });
            return new ItensNotaGetDTO
            {
                ITEM_NUM = itensNota.ITEM_NUM,
                ID_PRO = itensNota.ID_PRO,
                ID_NOTA = itensNota.ID_NOTA,
                ID_SEC = itensNota.ID_SEC,
                QTD_PRO = itensNota.QTD_PRO,
                PRE_UNIT = itensNota.PRE_UNIT,
                EST_LIN = itensNota.EST_LIN
            };
        }

        public ItensNotaGetDTO AtualizarItensNota(int item_Num, int id_Pro, int Id_Nota, int id_Sec, ItensNotaPostDTO itensNotaP)
        {
            ItensNota itensNota = _itensNotaRepository.AtualizarItensNota(item_Num, id_Pro, Id_Nota, id_Sec, new ItensNota
            {
                ITEM_NUM = item_Num,
                ID_PRO = id_Pro,
                ID_NOTA = Id_Nota,
                ID_SEC = id_Sec,
                QTD_PRO = itensNotaP.QTD_PRO,
                PRE_UNIT = itensNotaP.PRE_UNIT,
                EST_LIN = itensNotaP.EST_LIN
            });

            return new ItensNotaGetDTO
            {
                ITEM_NUM = itensNota.ITEM_NUM,
                ID_PRO = itensNota.ID_PRO,
                ID_NOTA = itensNota.ID_NOTA,
                ID_SEC = itensNota.ID_SEC,
                QTD_PRO = itensNota.QTD_PRO,
                PRE_UNIT = itensNota.PRE_UNIT,
                TOTAL_ITEM = itensNota.TOTAL_ITEM,
                EST_LIN = itensNota.EST_LIN
            };
        }

        public ItensNotaGetDTO DeletarItensNota(int item_Num, int id_Pro, int Id_Nota, int id_Sec)
        {
            ItensNota itensNota = _itensNotaRepository.DeletarItensNota(item_Num, id_Pro, Id_Nota, id_Sec);
            return new ItensNotaGetDTO
            {
                ITEM_NUM = itensNota.ITEM_NUM,
                ID_PRO = itensNota.ID_PRO,
                ID_NOTA = itensNota.ID_NOTA,
                ID_SEC = itensNota.ID_SEC,
                QTD_PRO = itensNota.QTD_PRO,
                PRE_UNIT = itensNota.PRE_UNIT,
                TOTAL_ITEM = itensNota.TOTAL_ITEM,
                EST_LIN = itensNota.EST_LIN
            };
        }
    }
}
