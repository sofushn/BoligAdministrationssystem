using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using UWP_App.Model;

namespace UWP_App.Persistency
{
    public class PersistencyFacade : IPersistency
    {
        private HttpClient GetHttpClient()
        {
            HttpClientHandler handler = new HttpClientHandler();
            handler.UseDefaultCredentials = true;

            HttpClient client = new HttpClient(handler);

            client.BaseAddress = new Uri("http://localhost:57121/api/");
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("Application/json"));

            return client;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="lejlighed"></param>
        /// <returns></returns>
        public async Task<IEnumerable<Faldstamme>> GetLejlighedsFaldstammerAsync(Lejlighed lejlighed)
        {
            using (HttpClient client = GetHttpClient())
            {
                string uri = "Faldstamme/" + lejlighed.Lejlighed_No;
                HttpResponseMessage responseMessage = await client.GetAsync(uri);
                if (responseMessage.IsSuccessStatusCode)
                {
                    return await responseMessage.Content.ReadAsAsync<IEnumerable<Faldstamme>>();
                }
                else
                    throw new HttpRequestException($"StausCode: {responseMessage.StatusCode}; ReasonPhrase: {responseMessage.ReasonPhrase}");

            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="lejlighed"></param>
        /// <returns></returns>
        public async Task<IEnumerable<Vindue>> GetLejlighedsVinduerAsync(Lejlighed lejlighed)
        {
            using (HttpClient client = GetHttpClient())
            {
                string uri = "Vindue/" + lejlighed.Lejlighed_No;
                HttpResponseMessage responseMessage = await client.GetAsync(uri);
                if (responseMessage.IsSuccessStatusCode)
                {
                    return await responseMessage.Content.ReadAsAsync<IEnumerable<Vindue>>();
                }
                else
                    throw new HttpRequestException($"StausCode: {responseMessage.StatusCode}; ReasonPhrase: {responseMessage.ReasonPhrase}");

            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="lejlighed"></param>
        /// <returns></returns>
        public async Task<IEnumerable<StatusRapportBase>> GetLejlighedsStatusRapporterAsync(Lejlighed lejlighed)
        {
            using(HttpClient client = GetHttpClient())
            {
                string uri = "StatusRapporter/" + lejlighed.Lejlighed_No;
                HttpResponseMessage responseMessage = await client.GetAsync(uri);
                if (responseMessage.IsSuccessStatusCode)
                {
                    return await responseMessage.Content.ReadAsAsync<IEnumerable<StatusRapportBase>>();
                }
                else
                    throw new HttpRequestException($"StausCode: {responseMessage.StatusCode}; ReasonPhrase: {responseMessage.ReasonPhrase}");
            }
        }

        public IEnumerable<StatusRapportBase> GetLejlighedsStatusRapporter(Lejlighed lejlighed)
        {
            using (HttpClient client = GetHttpClient())
            {
                string uri = "StatusRapporter/" + lejlighed.Lejlighed_No;
                HttpResponseMessage responseMessage = client.GetAsync(uri).Result;
                if (responseMessage.IsSuccessStatusCode)
                {
                    return responseMessage.Content.ReadAsAsync<IEnumerable<StatusRapportBase>>().Result;
                }
                else
                    throw new HttpRequestException($"StausCode: {responseMessage.StatusCode}; ReasonPhrase: {responseMessage.ReasonPhrase}");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="andelshaver"></param>
        /// <returns></returns>
        public async Task<IEnumerable<Lejlighed>> GetAndelshaversLejlighederAsync(Andelshaver andelshaver)
        {
            using (HttpClient client = GetHttpClient()) {
                string uri = "ListAndelshaversLejlighederViews/" + andelshaver.Andelshaver_ID;
                HttpResponseMessage responseMessage = await client.GetAsync(uri);
                if (responseMessage.IsSuccessStatusCode) {
                    return await responseMessage.Content.ReadAsAsync<IEnumerable<Lejlighed>>();
                }
                else
                    throw new HttpRequestException($"StausCode: {responseMessage.StatusCode}; ReasonPhrase: {responseMessage.ReasonPhrase}");
            }
        }


        public async Task<IEnumerable<Kontrakt>> GetAndelshaversKontrakterAsync(Andelshaver andelshaver) {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Henter en andelshaver fra serveren
        /// </summary>
        /// <param name="andelshaverID">Andelshaveren id nummer</param>
        /// <returns>En andelshaver</returns>
        public async Task<Andelshaver> GetAndelshaverAsync(int andelshaverID) {
            using (HttpClient client = GetHttpClient())
            {
                string uri = "Andelshaver/" + andelshaverID;
                HttpResponseMessage getResponse = client.GetAsync(uri).Result;
                if (getResponse.IsSuccessStatusCode) {
                    return await getResponse.Content.ReadAsAsync<Andelshaver>();
                }

                await Task.Yield();
            }
            return null;
        }

        /// <summary>
        /// Tilføjer en ny statusrapport til DB
        /// </summary>
        /// <param name="statusRapport">Statusrapporten som skal tilføjes til DB</param>
        /// <returns></returns>
        public async Task CreateStatusRapport(StatusRapportBase statusRapport) {
            using (HttpClient client = GetHttpClient())
            {
                string uri = "Status_Raport/";
                HttpResponseMessage responseMessage = await client.PostAsJsonAsync(uri, statusRapport);
                if (!responseMessage.IsSuccessStatusCode)
                {
                    throw new Exception($"[{responseMessage.StatusCode}] - {responseMessage.ReasonPhrase}");
                }
            }
        }
    }
}