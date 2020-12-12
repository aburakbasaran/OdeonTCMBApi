using Application.Json;
using Newtonsoft.Json;


namespace Domain.DomainObjects
{
    public class ResponseDTO<T>
    {
        [JsonConverter(typeof(NewtonJsonConverter))]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public T Data { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public bool IsSuccessfull { get; set; } = true;
    }
}
