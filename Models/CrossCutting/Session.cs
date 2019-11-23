using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace CardFitness.CrossCutting
{
    public class Session
    {
        public static void Set(string Key, dynamic Value)
        {
            string Serialized = JsonConvert.SerializeObject(Value);
            HttpHelper.HttpContext.Session.SetString(Key, Serialized);
        }

        public static void Set(string Key, string Value)
        {
            HttpHelper.HttpContext.Session.SetString(Key, Value);
        }

        /// <summary>
        /// No parametro "Classe" é necessário informar o nome completo da classe desejada, incluindo o namespace.
        /// Exemplo: namespace.Classe
        /// </summary>
        /// <param name="Classe"></param>
        /// <param name="Key"></param>
        /// <returns></returns>
        public static dynamic Get(string Classe, string Key)
        {
            return JsonConvert.DeserializeObject(HttpHelper.HttpContext.Session.GetString(Key), Type.GetType(Classe));
        }
        public static T Get<T>(string Key)
        {
            try
            {
                return JsonConvert.DeserializeObject<T>(HttpHelper.HttpContext.Session.GetString(Key));
            }
            catch (Exception)
            {

                return default(T);
            }

        }

        public static string Get(string Key)
        {
            return HttpHelper.HttpContext.Session.GetString(Key);
        }

        public static void Remove(string Key)
        {
            HttpHelper.HttpContext.Session.Remove(Key);
        }

        public static void Clear()
        {
            HttpHelper.HttpContext.Session.Clear();
        }
    }
}
