using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CardFitness.CrossCutting
{
    public class BuscaDinamica
    {
        public string Campo { get; set; }
        public dynamic Valor { get; set; }
        public bool PesquisaExata { get; set; }
        public bool OperadorNegativo { get; set; }
        public static List<BuscaDinamica> Add(List<BuscaDinamica> Lista, string Campo, dynamic Valor, bool PesquisaExata)
        {
            Lista.Add(new BuscaDinamica { Campo = Campo, Valor = Valor, PesquisaExata = PesquisaExata });
            return Lista;
        }
        public static List<BuscaDinamica> Add(List<BuscaDinamica> Lista, string Campo, dynamic Valor, bool PesquisaExata, bool OperadorNegativo)
        {
            Lista.Add(new BuscaDinamica { Campo = Campo, Valor = Valor, PesquisaExata = PesquisaExata, OperadorNegativo = OperadorNegativo });
            return Lista;
        }
        public static BuscaDinamica Add(string Campo, dynamic Valor, bool PesquisaExata)
        {
            return new BuscaDinamica() { Campo = Campo, Valor = Valor, PesquisaExata = PesquisaExata };
        }
        public static BuscaDinamica Add(string Campo, dynamic Valor, bool PesquisaExata, bool OperadorNegativo)
        {
            return new BuscaDinamica (){ Campo = Campo, Valor = Valor, PesquisaExata = PesquisaExata, OperadorNegativo = OperadorNegativo } ;
        }
        public static List<BuscaDinamica> AddList(params BuscaDinamica[] values)
        {
            return values.ToList();
        }
    }
}