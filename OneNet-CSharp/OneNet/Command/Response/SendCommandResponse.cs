using Newtonsoft.Json;

namespace OneNet_CSharp.OneNet.Command.Response;

/// <summary>
/// 下发命令响应数据
/// </summary>
public class SendCommandResponse
{
    /// <summary>
    /// 命令ID，平台范围内唯一
    /// </summary>
    [JsonProperty("cmd_uuid")]
    public string CmdUuid { get; set; }
}
