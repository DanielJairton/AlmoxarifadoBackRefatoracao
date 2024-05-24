using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlmoxarifadoDomain.Models
{
    public class Estoque
    {
        [Key]
        public int ID_SEC { get; set; }
        [Key]
        public int ID_PRO { get; set; }
        public decimal QTD_PRO { get; set; }
    }
}
