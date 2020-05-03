using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;

namespace EmotionalIntel.Models
{
    public class Testes
    {
        public Testes(){
            ListaTecnicas = new HashSet<Tecnicas>();
            ListaPerguntas = new HashSet<Perguntas>();
            ListaTestesRealizados = new HashSet<Testes_Realizados>();
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
        public Utilizadores utilizador { get; set; }

        public ICollection<Tecnicas> ListaTecnicas { get; set; }
        public ICollection<Perguntas> ListaPerguntas { get; set; }
        // Este não temos bem a certeza
        public ICollection<Testes_Realizados> ListaTestesRealizados { get; set; }
    }
}
