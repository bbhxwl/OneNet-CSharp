using OneNet_CSharp.OneNet.Device;

namespace OneNet_CSharp.OneNet;

public class OneNetClient
{
    private static string _productid;
    private static string _accessKey;
    public OneNetClient(string productid,string accessKey)
    {
        _productid = productid;
        _accessKey = accessKey;
    }
    public DeviceClient Device => new DeviceClient(_productid,_accessKey);
}