using Newtonsoft.Json;

namespace OneNet_CSharp.OneNet.Response;

/// <summary>
/// OneNET 多协议平台统一响应信封（MQTT/EDP/Modbus/TCP/LwM2M）
/// 与 OneNetCommResponse 不同，多协议平台使用 errno/error 字段
/// </summary>
public class OneNetCmdResponse<T>
{
    /// <summary>
    /// 错误码，0 表示成功
    /// </summary>
    [JsonProperty("errno")]
    public int Errno { get; set; }

    /// <summary>
    /// 错误描述，"succ" 表示成功
    /// </summary>
    [JsonProperty("error")]
    public string Error { get; set; }

    /// <summary>
    /// 响应数据
    /// </summary>
    [JsonProperty("data")]
    public T Data { get; set; }
}
