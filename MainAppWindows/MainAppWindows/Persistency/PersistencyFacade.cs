using MainAppWindows.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MainAppWindows.Persistency
{
    static public class PersistencyFacade
    {
        //Get's HttpClient
        private static HttpClient GetClient()
        {
            HttpClientHandler handler = new HttpClientHandler();
            handler.UseDefaultCredentials = true;

            HttpClient client = new HttpClient(handler);

            client.BaseAddress = new Uri("http://localhost:57121");
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("Application/json"));

            return client;
        }


        public static Andelshaver GetAndelshaver(int andelshaverID)
        {
            using (HttpClient client = GetClient())
            {
                string uri = "api/andelshaver/" + andelshaverID;
                HttpResponseMessage getResponse = client.GetAsync(uri).Result;
                if (getResponse.IsSuccessStatusCode)
                {
                    return getResponse.Content.ReadAsAsync<Andelshaver>().Result;
                }

                else throw new HttpRequestException();
            }
        }

        //TODO rewrite this part
        //the API returns a IEnumerable with a "DBView class" containing deffrent kinds of StatusRaports
        //needs to convert the data based on RaportType to the proper StatusRapport sub Type
        //and then return a list of StatusRaport, insted of a list with StatusRaportFaldstamme
        public static List<StatusRaportFaldstamme> GetFaldstammeRaports(int lejlighedsID)
        {
            using (HttpClient client = GetClient())
            {            
                string uri = "api/ListLejlighedersRaporterViews/" + lejlighedsID;
                HttpResponseMessage getResponse = client.GetAsync(uri).Result;
                if (getResponse.IsSuccessStatusCode)
                {
                    List<StatusRaportFaldstamme> tmp = getResponse.Content.ReadAsAsync<IEnumerable<StatusRaportFaldstamme>>().Result.ToList();
                    return tmp;
                }
                else throw new HttpRequestException();
            }
        }

        public static List<Lejlighed> GetAndelshaversLejligheder(int andelshaverID)
        {
            using (HttpClient client = GetClient())
            {
                string uri = "api/ListAndelshaversLejlighederViews/" + andelshaverID;
                HttpResponseMessage getResponse = client.GetAsync(uri).Result;
                if (getResponse.IsSuccessStatusCode)
                {
                    return getResponse.Content.ReadAsAsync<IEnumerable<Lejlighed>>().Result.ToList();
                }
                else throw new HttpRequestException();
            }
            
        }

        //Create
        public static void NewRaport(StatusRaport statusRaport)
        {
            using (HttpClient client = GetClient())
            {
                string uri = "api/Status_Raport/";
                HttpResponseMessage newRaportResponse = client.PostAsJsonAsync(uri, statusRaport).Result;
            }
        }

    }
}
