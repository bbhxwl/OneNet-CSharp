using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using OneNet_CSharp.OneNet.Device.Request;
using OneNet_CSharp.OneNet.Device.Response;
using OneNet_CSharp.OneNet.Response;

namespace OneNet_CSharp.OneNet.Device;

public class DeviceClient
{
    private static string _productid;
    private static string _accessKey;
    HttpClient _client = new HttpClient();
    public DeviceClient(string productid,string accessKey)
    {
        _productid = productid;
        _accessKey = accessKey;
    }
    public async Task<OneNetCommResponse<DeviceListResponse>> GetListToPageAsync(string deviceName="",int pageIndex=1,int pageSize=10,string productid=null)
    {
        var str=OneNetAuthHelper.GenerateToken($"products/{_productid}",_accessKey);
        _client.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", str);
        StringBuilder sb = new StringBuilder();
        if (string.IsNullOrEmpty(productid))
        {
            sb.Append($"product_id={_productid}&");
        }
        else
        {
            sb.Append($"product_id={productid}&");
        }
        if (!string.IsNullOrEmpty(deviceName))
        {
            sb.Append($"device_name={deviceName}&");
        }
        if (pageIndex<=0)
        {
            pageIndex = 1;
        }
        sb.Append($"offset={(pageIndex-1)*pageSize}&");
        sb.Append($"limit={pageSize}&");
        var str2=await _client.GetStringAsync($"https://iot-api.heclouds.com/device/list?"+sb.ToString());
        return JsonConvert.DeserializeObject<OneNetCommResponse<DeviceListResponse>>(str2);
    }

   
    public async Task<OneNetCommResponse<DeviceDetailResponse>> GetDeviceByDeviceNameAsync(string deviceName)
    {
        var str=OneNetAuthHelper.GenerateToken($"products/{_productid}",_accessKey);
        _client.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", str);
        var str2=await _client.GetStringAsync($"https://iot-api.heclouds.com/device/detail?product_id={_productid}&device_name={deviceName}");
        return JsonConvert.DeserializeObject<OneNetCommResponse<DeviceDetailResponse>>(str2);
    }
    public async Task<OneNetCommResponse<DeviceDetailResponse>> AddDeviceAsync(AddRequest m)
    {
        if (string.IsNullOrEmpty(m.ProductId))
        {
            m.ProductId = _productid;
        }
        var token=OneNetAuthHelper.GenerateToken($"products/{_productid}",_accessKey);
        _client.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", token);
        var sc = new StringContent(JsonConvert.SerializeObject(m));
        var rs=await _client.PostAsync($"https://iot-api.heclouds.com/device/create",sc);
        return JsonConvert.DeserializeObject<OneNetCommResponse<DeviceDetailResponse>>(await rs.Content.ReadAsStringAsync());
    }
    public async Task<OneNetCommResponse<DeviceDetailResponse>> AddDeviceAsync(string deviceName)
    {
        return await AddDeviceAsync(new AddRequest()
        {
            DeviceName =  deviceName
        });
    }
}