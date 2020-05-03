using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmotionalIntel.Models
{
    public class Utilizador{
        //criar listas

        public Utilizador(){
            //por listas
        }


        [Key]
        public int ID { get; set; }

        [Required]
        public string nome { get; set; }

        [Required]
        public string password { get; set; }

        //******************FK************************
        public ICollection<Teste_Realizado> ListaTestesRealizados { get; set; }
        public ICollection<Teste> ListaTestesCriados { get; set; }
    }



}
