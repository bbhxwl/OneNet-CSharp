using Newtonsoft.Json;

namespace OneNet_CSharp.OneNet.NbIot.Response;

/// <summary>
/// 指定缓存命令详情响应数据
/// </summary>
public class CacheCommandDetailResponse
{
    /// <summary>
    /// 缓存命令ID
    /// </summary>
    [JsonProperty("uuid")]
    public string Uuid { get; set; }

    /// <summary>
    /// 设备IMEI
    /// </summary>
    [JsonProperty("imei")]
    public string Imei { get; set; }

    /// <summary>
    /// 命令类型
    /// </summary>
    [JsonProperty("type")]
    public int Type { get; set; }

    /// <summary>
    /// 创建时间
    /// </summary>
    [JsonProperty("create_time")]
    public string CreateTime { get; set; }

    /// <summary>
    /// 生效时间
    /// </summary>
    [JsonProperty("valid_time")]
    public string ValidTime { get; set; }

    /// <summary>
    /// 过期时间
    /// </summary>
    [JsonProperty("expired_time")]
    public string ExpiredTime { get; set; }

    /// <summary>
    /// 发送时间
    /// </summary>
    [JsonProperty("send_time")]
    public string SendTime { get; set; }

    /// <summary>
    /// 触发类型
    /// </summary>
    [JsonProperty("trigger_msg")]
    public int TriggerMsg { get; set; }

    /// <summary>
    /// 发送状态
    /// </summary>
    [JsonProperty("send_status")]
    public int SendStatus { get; set; }

    /// <summary>
    /// 确认状态
    /// </summary>
    [JsonProperty("confirm_status")]
    public int ConfirmStatus { get; set; }

    /// <summary>
    /// 确认时间
    /// </summary>
    [JsonProperty("confirm_time")]
    public string ConfirmTime { get; set; }

    /// <summary>
    /// 命令内容
    /// </summary>
    [JsonProperty("content")]
    public string Content { get; set; }
}
