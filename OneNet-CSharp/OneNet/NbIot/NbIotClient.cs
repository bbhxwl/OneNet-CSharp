using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using OneNet_CSharp.OneNet.NbIot.Request;
using OneNet_CSharp.OneNet.NbIot.Response;
using OneNet_CSharp.OneNet.Response;

namespace OneNet_CSharp.OneNet.NbIot;

/// <summary>
/// LwM2M/NB-IoT 设备命令客户端
/// 基础地址：https://api.heclouds.com
/// 鉴权方式：api-key 请求头
/// </summary>
public class NbIotClient
{
    private const string BaseUrl = "https://api.heclouds.com";
    private readonly string _apiKey;
    private readonly HttpClient _client = new HttpClient();

    public NbIotClient(string productId, string apiKey)
    {
        _apiKey = apiKey;
    }

    /// <summary>
    /// 即时命令-Execute（设备须在线）
    /// 平台向设备发送Execute操作请求
    /// </summary>
    /// <param name="imei">NB-IoT设备的IMEI号</param>
    /// <param name="objId">设备对象ID（由终端设备SDK决定）</param>
    /// <param name="objInstId">对象实例ID</param>
    /// <param name="resId">设备资源ID</param>
    /// <param name="args">命令参数，可选，最大2KB</param>
    /// <param name="timeout">请求超时时间（秒），范围[5,40]，默认25</param>
    /// <returns>执行结果</returns>
    public async Task<OneNetCmdResponse<object>> ExecuteAsync(string imei, int objId, int objInstId, int resId, string args = null, int timeout = 25)
    {
        var url = $"{BaseUrl}/nbiot/execute?imei={imei}&obj_id={objId}&obj_inst_id={objInstId}&res_id={resId}&timeout={timeout}";
        var request = new HttpRequestMessage(HttpMethod.Post, url);
        request.Headers.TryAddWithoutValidation("api-key", _apiKey);

        var body = new NbIotExecuteRequest { Args = args };
        request.Content = new StringContent(JsonConvert.SerializeObject(body), Encoding.UTF8, "application/json");

        var response = await _client.SendAsync(request);
        var result = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<OneNetCmdResponse<object>>(result);
    }

    /// <summary>
    /// 缓存命令-Execute（设备可离线，上线后平台自动下发）
    /// </summary>
    /// <param name="imei">NB-IoT设备的IMEI号</param>
    /// <param name="objId">设备对象ID</param>
    /// <param name="objInstId">对象实例ID</param>
    /// <param name="resId">设备资源ID</param>
    /// <param name="args">命令参数，可选，最大2KB</param>
    /// <param name="expiredTime">过期时间，格式：2016-07-05T00:00:00</param>
    /// <param name="validTime">生效时间，可选，格式：2016-07-05T00:00:00</param>
    /// <returns>执行结果</returns>
    public async Task<OneNetCmdResponse<object>> CacheExecuteAsync(string imei, int objId, int objInstId, int resId, string args, string expiredTime, string validTime = null)
    {
        var sb = new StringBuilder($"{BaseUrl}/nbiot/offline?imei={imei}&obj_id={objId}&obj_inst_id={objInstId}&res_id={resId}&expired_time={expiredTime}");
        if (!string.IsNullOrEmpty(validTime))
        {
            sb.Append($"&valid_time={validTime}");
        }

        var request = new HttpRequestMessage(HttpMethod.Post, sb.ToString());
        request.Headers.TryAddWithoutValidation("api-key", _apiKey);

        var body = new NbIotExecuteRequest { Args = args };
        request.Content = new StringContent(JsonConvert.SerializeObject(body), Encoding.UTF8, "application/json");

        var response = await _client.SendAsync(request);
        var result = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<OneNetCmdResponse<object>>(result);
    }

    /// <summary>
    /// 查看设备缓存命令列表
    /// </summary>
    /// <param name="deviceId">设备ID</param>
    /// <param name="imei">设备IMEI号</param>
    /// <param name="start">查询起始时间，格式：2016-07-05T00:00:00</param>
    /// <param name="end">查询结束时间，可选</param>
    /// <param name="page">页码，默认1</param>
    /// <param name="perPage">每页条数，默认30，最大100</param>
    /// <returns>分页的缓存命令列表</returns>
    public async Task<OneNetCmdResponse<CacheCommandListResponse>> GetCacheCommandListAsync(string deviceId, string imei, string start, string end = null, int page = 1, int perPage = 30)
    {
        var sb = new StringBuilder($"{BaseUrl}/nbiot/offline/history/{deviceId}?imei={imei}&start={start}");
        if (!string.IsNullOrEmpty(end))
        {
            sb.Append($"&end={end}");
        }
        sb.Append($"&page={page}&per_page={perPage}");

        var request = new HttpRequestMessage(HttpMethod.Get, sb.ToString());
        request.Headers.TryAddWithoutValidation("api-key", _apiKey);

        var response = await _client.SendAsync(request);
        var result = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<OneNetCmdResponse<CacheCommandListResponse>>(result);
    }

    /// <summary>
    /// 查看指定缓存命令详情
    /// </summary>
    /// <param name="uuid">缓存命令ID</param>
    /// <param name="imei">设备IMEI号</param>
    /// <returns>缓存命令详情</returns>
    public async Task<OneNetCmdResponse<CacheCommandDetailResponse>> GetCacheCommandDetailAsync(string uuid, string imei)
    {
        var url = $"{BaseUrl}/nbiot/offline/{uuid}?imei={imei}";
        var request = new HttpRequestMessage(HttpMethod.Get, url);
        request.Headers.TryAddWithoutValidation("api-key", _apiKey);

        var response = await _client.SendAsync(request);
        var result = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<OneNetCmdResponse<CacheCommandDetailResponse>>(result);
    }

    /// <summary>
    /// 取消缓存命令
    /// </summary>
    /// <param name="uuid">缓存命令ID</param>
    /// <param name="imei">设备IMEI号</param>
    /// <returns>取消结果</returns>
    public async Task<OneNetCmdResponse<object>> CancelCacheCommandAsync(string uuid, string imei)
    {
        var url = $"{BaseUrl}/nbiot/offline/{uuid}?imei={imei}";
        var request = new HttpRequestMessage(HttpMethod.Put, url);
        request.Headers.TryAddWithoutValidation("api-key", _apiKey);

        var response = await _client.SendAsync(request);
        var result = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<OneNetCmdResponse<object>>(result);
    }
}
