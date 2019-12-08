using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CardFitness.CrossCutting
{

    public class HttpGeneric
    {
        private static string Token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IkNhcmRGaXRuZXNzIiwicm9sZSI6IkRFViIsIm5iZiI6MTU3NTgwNjI0MywiZXhwIjoxNjA3MzQyMjQxLCJpYXQiOjE1NzU4MDYyNDN9.yS3J3-i0kiW9TD38fbuewQBQd3dEsV_VbTSXSFcE-lQ";

        public static async Task<Return> Post(string Url, dynamic Obj)
        {
            try
            {

                using (var client = new HttpClient())
                {

                    client.DefaultRequestHeaders.Add("Authorization", "Bearer " + Token);

                    using (var response = await client.PostAsync(Url, new StringContent(JsonConvert.SerializeObject(Obj), Encoding.UTF8, "application/json")))
                    {
                        string result = await response.Content.ReadAsStringAsync();
                        return JsonConvert.DeserializeObject<Return>(result);
                    }
                }
            }
            catch (Exception e)
            {
                return Return.CustomError(e);
            }
        }
        public static async Task<Return> Post_SetTimeOut(string Url, dynamic Obj, int TimeOutMinutes)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.Timeout = TimeSpan.FromMinutes(TimeOutMinutes);
                    client.DefaultRequestHeaders.Add("Authorization", "Bearer " + Token);
                    using (var response = await client.PostAsync(Url, new StringContent(JsonConvert.SerializeObject(Obj), Encoding.UTF8, "application/json")))
                    {
                        string result = await response.Content.ReadAsStringAsync();
                        return JsonConvert.DeserializeObject<Return>(result);
                    }
                }
            }
            catch (Exception e)
            {
                return Return.CustomError(e);
            }
        }
        public static async Task<Return> Put(string Url, dynamic Obj)
        {
            try
            {

                using (var client = new HttpClient())
                {

                    client.DefaultRequestHeaders.Add("Authorization", "Bearer " + Token);
                    using (var response = await client.PutAsync(Url, new StringContent(JsonConvert.SerializeObject(Obj), Encoding.UTF8, "application/json")))
                    {
                        if (!response.IsSuccessStatusCode)
                        {
                            return Return.ErrorToken;
                        }

                        string result = await response.Content.ReadAsStringAsync();


                        return JsonConvert.DeserializeObject<Return>(result);
                    }
                }
            }
            catch (Exception e)
            {
                return Return.CustomError(e);
            }
        }
        public static async Task<Return> Get(string Url)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Add("Authorization", "Bearer " + Token);
                    using (var response = await client.GetAsync(Url))
                    {
                        if (!response.IsSuccessStatusCode)
                        {
                            return Return.ErrorToken;
                        }

                        string result = await response.Content.ReadAsStringAsync();


                        return JsonConvert.DeserializeObject<Return>(result);
                    }
                }
            }
            catch (Exception e)
            {
                return Return.CustomError(e);
            }
        }
        public static async Task<Return> Delete(string Url)
        {
            try
            {

                using (var client = new HttpClient())
                {

                    client.DefaultRequestHeaders.Add("Authorization", "Bearer " + Token);

                    using (var response = await client.DeleteAsync(Url))
                    {
                        string result = await response.Content.ReadAsStringAsync();
                        return JsonConvert.DeserializeObject<Return>(result);
                    }
                }
            }
            catch (Exception e)
            {
                return Return.CustomError(e);
            }
        }

    }
}
