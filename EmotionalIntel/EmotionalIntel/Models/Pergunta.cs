using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EmotionalIntel.Models
{
    public class Pergunta
    {
        public Pergunta()
        {

        }
        [Key]
        public int ID { get; set; }
        [Required]
        public string txtPergunta { get; set; }

        //******************FK************************
        [ForeignKey("Teste")]
        public int testeFK { get; set; }
        public Teste teste { get; set; }

    }
}
