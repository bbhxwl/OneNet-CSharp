using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using OneNet_CSharp.OneNet.Command.Response;
using OneNet_CSharp.OneNet.Response;

namespace OneNet_CSharp.OneNet.Command;

/// <summary>
/// MQTT/EDP/Modbus/TCP 通用设备命令客户端
/// 基础地址：https://api.heclouds.com
/// 鉴权方式：api-key 请求头
/// </summary>
public class CommandClient
{
    private const string BaseUrl = "https://api.heclouds.com";
    private readonly string _apiKey;
    private readonly HttpClient _client = new HttpClient();

    public CommandClient(string productId, string apiKey)
    {
        _apiKey = apiKey;
    }

    /// <summary>
    /// 下发命令（平台主动发送数据至设备）
    /// </summary>
    /// <param name="deviceId">接收命令的设备ID</param>
    /// <param name="body">用户自定义数据，支持JSON、字符串或二进制，最大64KB</param>
    /// <param name="qos">是否需要设备应答：0-仅发送一次（默认），1-至少发送一次（超时未应答则重发）</param>
    /// <param name="timeout">命令有效时间（秒），0-仅设备在线时有效（默认），大于0-离线也缓存，范围0-2678400</param>
    /// <returns>包含命令唯一ID(cmd_uuid)的响应</returns>
    public async Task<OneNetCmdResponse<SendCommandResponse>> SendCommandAsync(string deviceId, string body, int qos = 0, int timeout = 0)
    {
        var url = $"{BaseUrl}/cmds?device_id={deviceId}&qos={qos}&timeout={timeout}";
        var request = new HttpRequestMessage(HttpMethod.Post, url);
        request.Headers.TryAddWithoutValidation("api-key", _apiKey);
        request.Content = new StringContent(body, Encoding.UTF8);
        var response = await _client.SendAsync(request);
        var result = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<OneNetCmdResponse<SendCommandResponse>>(result);
    }

    /// <summary>
    /// 查询命令状态
    /// </summary>
    /// <param name="cmdUuid">命令唯一ID</param>
    /// <returns>命令状态：1-命令已创建，2-命令已发送，4-设备已响应</returns>
    public async Task<OneNetCmdResponse<CommandStatusResponse>> GetCommandStatusAsync(string cmdUuid)
    {
        var url = $"{BaseUrl}/cmds/{cmdUuid}";
        var request = new HttpRequestMessage(HttpMethod.Get, url);
        request.Headers.TryAddWithoutValidation("api-key", _apiKey);
        var response = await _client.SendAsync(request);
        var result = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<OneNetCmdResponse<CommandStatusResponse>>(result);
    }

    /// <summary>
    /// 查询命令响应（仅在命令状态为"设备已正常响应"时有效）
    /// </summary>
    /// <param name="cmdUuid">命令唯一ID</param>
    /// <returns>设备原始响应数据</returns>
    public async Task<string> GetCommandResponseAsync(string cmdUuid)
    {
        var url = $"{BaseUrl}/cmds/{cmdUuid}/resp";
        var request = new HttpRequestMessage(HttpMethod.Get, url);
        request.Headers.TryAddWithoutValidation("api-key", _apiKey);
        var response = await _client.SendAsync(request);
        return await response.Content.ReadAsStringAsync();
    }

    /// <summary>
    /// 查询设备历史命令
    /// </summary>
    /// <param name="deviceId">设备ID</param>
    /// <param name="start">查询起始时间，格式：2015-01-10T08:00:35</param>
    /// <param name="end">查询结束时间，可选</param>
    /// <param name="page">页码，默认1</param>
    /// <param name="perPage">每页条数，默认30，最大100</param>
    /// <returns>分页的历史命令列表</returns>
    public async Task<OneNetCmdResponse<CommandHistoryResponse>> GetCommandHistoryAsync(string deviceId, string start, string end = null, int page = 1, int perPage = 30)
    {
        var sb = new StringBuilder($"{BaseUrl}/cmds/history/{deviceId}?start={start}");
        if (!string.IsNullOrEmpty(end))
        {
            sb.Append($"&end={end}");
        }
        sb.Append($"&page={page}&per_page={perPage}");

        var request = new HttpRequestMessage(HttpMethod.Get, sb.ToString());
        request.Headers.TryAddWithoutValidation("api-key", _apiKey);
        var response = await _client.SendAsync(request);
        var result = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<OneNetCmdResponse<CommandHistoryResponse>>(result);
    }
}
