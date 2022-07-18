using System.Text.Json;
using System.Text.Json.Serialization;

namespace Armatasoft_NET_test
{
    public class Response<T>
    {
        public int? status { get; set; }

        public string? message { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public T? value { get; set; }
    }
}