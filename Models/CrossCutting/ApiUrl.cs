
namespace CardFitness.CrossCutting
{
    public class APIUrl
    {
        public static string Url()
        {
            return Local;
        }
        public static string Url(string Ambiente)
        {
            return Ambiente;
        }
        public static string Local
        {
            get
            {
                return "http://localhost:3000/api/";
            }
        }
      
    }
}
