using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using UWP_App.Model;

namespace UWP_App.Persistency
{
    public class PersistencyFacade : ICreatePersistency, IRetrievePersistency
    {
        private static HttpClient _httpClient;
        private static HttpClient HttpClient
        {
            get {
                if (_httpClient != null) return _httpClient;

                HttpClientHandler handler = new HttpClientHandler();
                handler.UseDefaultCredentials = true;

                HttpClient client = new HttpClient(handler);

                client.BaseAddress = new Uri("http://localhost:57121/api");
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("Application/json"));

                _httpClient = client;

                return _httpClient;
            }
        }


        public async Task<IEnumerable<Faldstamme>> GetLejlighedsFaldstammerAsync(Lejlighed lejlighed)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Vindue>> GetLejlighedsVinduerAsync(Lejlighed lejlighed)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<StatusRapportBase>> GetLejlighedsStatusRapporterAsync(Lejlighed lejlighed) {
            throw new System.NotImplementedException();
        }

        public async Task<IEnumerable<Lejlighed>> GetAndelshaversLejlighederAsync(Andelshaver andelshaver)
        {
            using (HttpClient client = HttpClient) {
                string uri = "ListAndelshaversLejæihederViews/" + andelshaver.Andelshaver_ID;
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

        public async Task<Andelshaver> GetAndelshaverAsync(int andelshaverID) {
            using (HttpClient client = HttpClient)
            {
                string uri = "andelshaver/" + andelshaverID;
                HttpResponseMessage getResponse = await client.GetAsync(uri);
                if (getResponse.IsSuccessStatusCode) {
                    return await getResponse.Content.ReadAsAsync<Andelshaver>();
                }
            }
            return null;
        }

        public void CreateStatusRapport(StatusRapportBase statusRapport) {
            throw new NotImplementedException();
        }
    }
}