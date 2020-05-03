﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EmotionalIntel.Models
{
    public class Tecnica
    {
        public Tecnica()
        {

        }
        [Key]
        public int ID { get; set; }
        [Required]
        public string nome { get; set; }
        [Required]
        public string descricao { get; set; }
        [Required]
        public string nivel { get; set; }


        //******************FK************************
        [ForeignKey("Teste")]
        public int testeFK { get; set; }
        public Teste teste { get; set; }
    }
}
