using System.Collections.Generic;
using Newtonsoft.Json;

namespace OneNet_CSharp.OneNet.Device.Response;

public class DeviceListResponse
{
    [JsonProperty("limit")]
    public int Limit { get; set; }
    [JsonProperty("offset")]
    public int Offset { get; set; }
    [JsonProperty("list")]
    public List<DeviceDetailResponse> List { get; set; }
}