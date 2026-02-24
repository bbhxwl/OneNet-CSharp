using Newtonsoft.Json;

namespace OneNet_CSharp.OneNet.Command.Response;

/// <summary>
/// 查询命令状态响应数据
/// </summary>
public class CommandStatusResponse
{
    /// <summary>
    /// 命令状态：1-命令已创建，2-命令已发送，4-设备已响应
    /// </summary>
    [JsonProperty("status")]
    public int Status { get; set; }

    /// <summary>
    /// 状态描述
    /// </summary>
    [JsonProperty("desc")]
    public string Desc { get; set; }
}
