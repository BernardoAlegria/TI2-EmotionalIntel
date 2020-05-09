using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmotionalIntel.Models
{
    public class Utilizadores{
        //criar listas

        public Utilizadores(){
            ListaTestesCriados = new HashSet<Testes>();
            ListaTestesRealizados = new HashSet<TestesRealizados>();

        }

        [Key]
        public int ID { get; set; }

        [Required]
        public string Nome { get; set; }


        //******************FK************************
        public ICollection<TestesRealizados> ListaTestesRealizados { get; set; }
        public ICollection<Testes> ListaTestesCriados { get; set; }
    }



}
