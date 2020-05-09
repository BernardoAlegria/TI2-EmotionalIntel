﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EmotionalIntel.Models
{
    public class TestesRealizados
    {
        public TestesRealizados()
        {

        }

        public int ID { get; set; }

        public int Pontuacao { get; set; }

        public DateTime Data { get; set; }


        //******************FK************************
        [ForeignKey("Utilizador")] 
        public int UtilizadorFK { get; set; } 
        public Utilizadores Utilizador { get; set; }

        [ForeignKey("Teste")]
        public int TesteFK { get; set; }
        public Testes Teste { get; set; }
    }
}
