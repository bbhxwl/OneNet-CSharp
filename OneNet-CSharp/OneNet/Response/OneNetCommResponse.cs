using Newtonsoft.Json;

namespace OneNet_CSharp.OneNet.Response;

public class OneNetCommResponse<T>
{
    [JsonProperty("code")]
    public int Code { get; set; }
    [JsonProperty("msg")]
    public string Msg { get; set; }
    [JsonProperty("request_id")]
    public string RequestId { get; set; }
    [JsonProperty("data")]
    public T Data { get; set; }
}