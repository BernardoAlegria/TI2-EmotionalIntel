using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EmotionalIntel.Models
{
    public class Respostas
    {
        public Respostas()
        {

        }

        [Key]
        public int ID { get; set; }

        [Required]
        public string TxtRespostas { get; set; }

        //******************FK************************
        [ForeignKey("Perguntas")]
        public int PerguntaFK { get; set; }
        public Perguntas Perguntas { get; set; }

    }
}
