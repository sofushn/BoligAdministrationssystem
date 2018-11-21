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
            Status_Raport report = null;

            switch (tmp.Value<int>("RaportType"))
            {
                case 0:
                    {
                        report = new Faldstamme_Raport();
                        break;
                    }
                case 1:
                    {
                        report = new Vindue_Raport();
                        break;
                    }
                default:
                    {
                        report = new Status_Raport();
                        break;
                    }
            }

            serializer.Populate(tmp.CreateReader(), report);
            return report;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}