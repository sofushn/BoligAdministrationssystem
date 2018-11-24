using Newtonsoft.Json;
using System;
using API.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json.Linq;

namespace API.Converter
{
    public class RaportJsonConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(Status_Raport);
        }
        public override bool CanWrite { get { return false; } }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JObject tmp = JObject.Load(reader);
            Status_Raport rapport = null;

            switch (tmp.Value<int>("RapportType"))
            {
                case 0:
                {
                    //Faldstammer f = tmp.Value<Faldstammer>("Faldstamme");
                    Faldstamme_Raport fRapport = new Faldstamme_Raport();

                    JToken faldstammeJToken = null;
                    tmp.TryGetValue("Faldstamme", out faldstammeJToken);
                    fRapport.FaldstammeDel_ID = faldstammeJToken.Value<int>("Del_ID");
                    fRapport.Faldstamme_ID = faldstammeJToken.Value<int>("Faldstamme_ID");


                    break;
                }
                case 1:
                {
                    Vindue_Raport vRapport = new Vindue_Raport();
                    JToken vindueJToken = null;
                    tmp.TryGetValue("Vindue", out vindueJToken);
                    vRapport.Vindue_ID = vindueJToken.Value<int>("Vindue_ID");
                    rapport = vRapport;
                    break;
                }
                default:
                {
                    rapport = new Status_Raport();
                    break;
                }
            }

            
            rapport.RaportType = tmp.Value<int>("RapportType");
            rapport.Dato = tmp.Value<DateTime>("Dato");
            rapport.Godkendt = tmp.Value<string>("Godkendt");
            rapport.Note = tmp.Value<string>("Note");
            rapport.Status = tmp.Value<int>("Status");
            
            return rapport;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}