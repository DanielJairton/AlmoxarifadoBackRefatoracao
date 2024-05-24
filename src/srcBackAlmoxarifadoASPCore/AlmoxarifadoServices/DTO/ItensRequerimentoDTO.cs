using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlmoxarifadoServices.DTO
{
    public class ItensRequerimentoPostDTO
    {
        public int NUM_ITEM { get; set; }
        public int ID_PRO { get; set; }
        public int ID_REQ { get; set; }
        public int ID_SEC { get; set; }
        public decimal QTD_PRO { get; set; }
        public decimal? PRE_UNIT { get; set; }
        public decimal? TOTAL_REAL { get; set; }
    }

    public class ItensRequerimentoGetDTO
    {
        public int NUM_ITEM { get; set; }
        public int ID_PRO { get; set; }
        public int ID_REQ { get; set; }
        public int ID_SEC { get; set; }
        public decimal QTD_PRO { get; set; }
        public decimal? PRE_UNIT { get; set; }
        public decimal? TOTAL_ITEM { get; set; }
        public decimal? TOTAL_REAL { get; set; }
    }
}
