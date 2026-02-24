using System.Collections.Generic;
using Newtonsoft.Json;

namespace OneNet_CSharp.OneNet.Command.Response;

/// <summary>
/// 查询设备历史命令响应数据
/// </summary>
public class CommandHistoryResponse
{
    /// <summary>
    /// 当前页码
    /// </summary>
    [JsonProperty("page")]
    public int Page { get; set; }

    /// <summary>
    /// 每页条数
    /// </summary>
    [JsonProperty("per_page")]
    public int PerPage { get; set; }

    /// <summary>
    /// 命令总数
    /// </summary>
    [JsonProperty("total_count")]
    public int TotalCount { get; set; }

    /// <summary>
    /// 历史命令列表
    /// </summary>
    [JsonProperty("items")]
    public List<CommandHistoryItem> Items { get; set; }
}

/// <summary>
/// 历史命令条目
/// </summary>
public class CommandHistoryItem
{
    /// <summary>
    /// 命令ID
    /// </summary>
    [JsonProperty("cmd_uuid")]
    public string CmdUuid { get; set; }

    /// <summary>
    /// 设备ID
    /// </summary>
    [JsonProperty("device_id")]
    public string DeviceId { get; set; }

    /// <summary>
    /// 过期时间
    /// </summary>
    [JsonProperty("expire_time")]
    public string ExpireTime { get; set; }

    /// <summary>
    /// 命令状态
    /// </summary>
    [JsonProperty("status")]
    public int Status { get; set; }

    /// <summary>
    /// 发送时间
    /// </summary>
    [JsonProperty("send_time")]
    public string SendTime { get; set; }

    /// <summary>
    /// 响应时间
    /// </summary>
    [JsonProperty("confirm_time")]
    public string ConfirmTime { get; set; }

    /// <summary>
    /// 响应内容（十六进制）
    /// </summary>
    [JsonProperty("confirm_body")]
    public string ConfirmBody { get; set; }

    /// <summary>
    /// 请求内容（十六进制）
    /// </summary>
    [JsonProperty("body")]
    public string Body { get; set; }
}
