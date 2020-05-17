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
            ListaTestesRealizados = new HashSet<TestesRealizados>();
        }

        [Key]
        public int ID { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        public int NRespostas { get; set; }
        
        public string Descricao { get; set; }

        [Required]
        public int PontuacaoMedia { get; set; }

        [Required]
        public int PontuacaoAlta { get; set; }




        //******************FK************************
        [ForeignKey("Utilizador")]
        public int UtilizadorFK { get; set; }
        public Utilizadores Utilizador { get; set; }

        public ICollection<Tecnicas> ListaTecnicas { get; set; }
        public ICollection<Perguntas> ListaPerguntas { get; set; }

        // Este não temos bem a certeza
        public ICollection<TestesRealizados> ListaTestesRealizados { get; set; }
    }
}
