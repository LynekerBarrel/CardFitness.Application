using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CardFitness.Models
{
    public class Ficha
    {
        public int IDFicha { get; set; }
        public string Descricao { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime DataFinalizacao { get; set; }
        public int Status { get; set; }
        public int DiaSeq { get; set; }
    }
}
