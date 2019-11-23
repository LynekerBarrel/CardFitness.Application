using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CardFitness.Models
{
    public class Exercicio
    {
        public int IDExercicio { get; set; }
        public int IDTipo { get; set; }
        public string Descricao { get; set; }
        public string Chave { get; set; }
        public int Status { get; set; }
        public Tipo Tipo { get; set; }
        public List<Tipo> Tipos { get; set; }
    }
}
