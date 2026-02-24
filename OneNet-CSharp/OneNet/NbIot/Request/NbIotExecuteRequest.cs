using Newtonsoft.Json;

namespace OneNet_CSharp.OneNet.NbIot.Request;

/// <summary>
/// NB-IoT/LwM2M 即时命令/缓存命令请求体
/// </summary>
public class NbIotExecuteRequest
{
    /// <summary>
    /// 命令参数，可选，最大2KB
    /// </summary>
    [JsonProperty("args")]
    public string Args { get; set; }
}
