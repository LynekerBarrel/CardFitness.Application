using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CardFitness.CrossCutting
{
    public class Return
    {
        public int Code { get; set; }

        public dynamic Result { get; set; }

        public static Return ErrorToken
        {
            get
            {
                return new Return { Code = 001, Result = "Token não autorizado." };
            }
        }
        public static dynamic CustomError(dynamic Result)
        {
            return new Return { Code = 0, Result = Result };
        }
    }


}
