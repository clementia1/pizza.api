using System;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using PizzaApi.Services.Abstractions;

namespace PizzaApi.Services
{
    public class JsonSerializer : IJsonSerializer
    {
        public string Serialize<T>(T data)
        {
           return JsonConvert.SerializeObject(data);
        }

        public T? Deserialize<T>(string value)
        {
            return JsonConvert.DeserializeObject<T>(value);
        }
    }
}