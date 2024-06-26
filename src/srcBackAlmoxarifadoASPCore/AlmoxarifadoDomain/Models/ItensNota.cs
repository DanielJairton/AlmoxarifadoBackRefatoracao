﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlmoxarifadoDomain.Models
{
    public class ItensNota
    {
        [Key]
        public int ITEM_NUM { get; set; }
        [Key]
        public int ID_PRO { get; set;}
        [Key]
        public int ID_NOTA { get; set;}
        [Key]
        public int ID_SEC { get; set;}
        public decimal? QTD_PRO { get; set;}
        public decimal? PRE_UNIT { get; set;}
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public decimal? TOTAL_ITEM { get; set;}
        public decimal? EST_LIN { get; set;}
    }
}
