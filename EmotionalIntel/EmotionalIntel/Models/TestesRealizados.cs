using System;
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
        // este int? é um workaround para quebrar o ciclo
        // https://entityframeworkcore.com/knowledge-base/52268985/may-cause-cycles-or-multiple-cascade-paths--specify-on-delete-no-action-or-on-update-no-action--or-modify-other-foreign-key-constraints
        
        [ForeignKey("Utilizador")] 
        public int? UtilizadorFK { get; set; } 
        public Utilizadores Utilizador { get; set; }

        [ForeignKey("Teste")]
        public int? TesteFK { get; set; }
        public Testes Teste { get; set; }
    }
}
