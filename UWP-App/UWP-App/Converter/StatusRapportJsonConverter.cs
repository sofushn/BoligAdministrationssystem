using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UWP_App.Model;

namespace UWP_App.Converter
{
    public class StatusRapportJsonConverter : JsonConverter<StatusRapportBase>
    {
        public override void WriteJson(JsonWriter writer, StatusRapportBase value, JsonSerializer serializer) {
            throw new NotImplementedException();
        }

        public override StatusRapportBase ReadJson(JsonReader reader, Type objectType, StatusRapportBase existingValue, bool hasExistingValue, JsonSerializer serializer) {
            JObject tmp = JObject.Load(reader);
            StatusRapportBase rapport = null;
            switch (tmp.Value<int>("RapportType"))
            {
                case 0:
                {
                    StatusRapportFaldstamme rapportFaldstamme = new StatusRapportFaldstamme() {};

                    rapportFaldstamme.Faldstamme.Faldstamme_ID = tmp.Value<int>("Faldstamme_ID");
                    rapportFaldstamme.Faldstamme.Del_ID = tmp.Value<int>("FaldstammeDel_ID");

                    rapport = rapportFaldstamme;
                    break;
                }
                case 1:
                    StatusRapportVindue rapportVindue = new StatusRapportVindue();

                    rapportVindue.Vindue.Vindue_ID = tmp.Value<int>("Vindue_ID");

                    rapport = rapportVindue;
                    break;
                default:
                    throw new JsonSerializationException($"Rapport Type {tmp.Value<int>("RapportType")} is no valid!");
            }

            rapport.Godkendt = tmp.Value<bool>("Godkendt");
            rapport.Note = tmp.Value<string>("Note");
            rapport.Status = (StatusValues)tmp.Value<int>("RapportStatus");
            rapport.Status_ID = tmp.Value<int>("Status_ID");
            rapport.Dato = tmp.Value<DateTime>("Dato");
            return rapport;
        }
    }
}
