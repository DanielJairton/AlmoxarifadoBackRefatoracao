using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlmoxarifadoServices.DTO
{
    public class EstoqueGetDTO
    {
        public int ID_SEC { get; set; }
        public int ID_PRO { get; set; }
        public decimal QTD_PRO { get; set; }
    }

    public class EstoquePostDTO
    {
        public decimal QTD_PRO { get; set; }
    }
}
