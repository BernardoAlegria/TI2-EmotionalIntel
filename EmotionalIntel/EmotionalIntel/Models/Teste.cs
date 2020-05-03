using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;

namespace EmotionalIntel.Models
{
    public class Teste
    {
        public Teste(){

        }

        [Key]
        public int ID { get; set; }
        [Required]
        public string nome { get; set; }
        [Required]
        public int nRespostas { get; set; }
        
        public string descricao { get; set; }
        [Required]
        public string niveisPontuacao { get; set; }

        //******************FK************************
        [ForeignKey("Utilizador")]
        public int utilizadorFK { get; set; }
        public Utilizador utilizador { get; set; }

        public ICollection<Tecnica> ListaTecnicas { get; set; }
        public ICollection<Pergunta> ListaPerguntas { get; set; }
        // Este não temos bem a certeza
        public ICollection<Teste_Realizado> ListaTestesRealizados { get; set; }
    }
}
