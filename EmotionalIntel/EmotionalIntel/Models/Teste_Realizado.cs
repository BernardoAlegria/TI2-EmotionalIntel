﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EmotionalIntel.Models
{
    public class Teste_Realizado
    {
        public Teste_Realizado()
        {

        }

        public int ID { get; set; }
        public int pontuacao { get; set; }
        public DateTime data { get; set; }


        //******************FK************************
        [ForeignKey("Utilizador")] 
        public int utilizadorFK { get; set; } 
        public Utilizador utilizador { get; set; }

        [ForeignKey("Teste")]
        public int testeFK { get; set; }
        public Teste teste { get; set; }
    }
}
