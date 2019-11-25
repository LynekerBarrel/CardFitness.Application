using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CardFitness.Models
{
    public class FichaExercicio
    {
        public int IDFichaExercicio { get; set; }

        public int? IDFicha { get; set; }
        public Ficha Ficha { get; set; }

        public int? IDExercicio { get; set; }
        public Exercicio Exercicio { get; set; }

        public string Repeticao { get; set; }
        public int? Serie { get; set; }
        public decimal? Carga { get; set; }
    }
    public class FichaExercicioVM
    {
        public Ficha Ficha { get; set; }
        public List<FichaExercicio> FichaExercicio { get; set; }
    }
}
