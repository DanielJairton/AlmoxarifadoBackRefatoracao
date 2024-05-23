using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlmoxarifadoDomain.Models
{
    public class Produto
    {
        [Key]
        public int ID_PRO { get; set; }
        public int ID_CLAS { get; set; }
        public int ID_UN_MED { get; set; }
        public string DESCRICAO { get; set; }
        public string? OBSERVACAO { get; set; }
        public int? ESTOQUE_MIN { get; set; }
        public bool? PERECIVEL { get; set; }
        public int? QTD_EMBALAGEM { get; set; }
    }
}
