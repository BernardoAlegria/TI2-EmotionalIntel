﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EmotionalIntel.Models
{
    public class Perguntas
    {
        public Perguntas()
        {

        }
        [Key]
        public int ID { get; set; }
        [Required]
        public string TxtPergunta { get; set; }

        //******************FK************************
        [ForeignKey("Testes")]
        public int TesteFK { get; set; }
        public Testes Testes { get; set; }

    }
}
