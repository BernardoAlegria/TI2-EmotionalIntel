using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EmotionalIntel.Models
{
    public class Tecnicas
    {
        public Tecnicas()
        {

        }
        [Key]
        public int ID { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Descricao { get; set; }
        [Required]
        public string Nivel { get; set; }


        //******************FK************************
        [ForeignKey("Teste")]
        public int TesteFK { get; set; }
        public Testes Teste { get; set; }
    }
}
