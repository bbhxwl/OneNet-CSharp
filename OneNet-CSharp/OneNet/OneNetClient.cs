using OneNet_CSharp.OneNet.Command;
using OneNet_CSharp.OneNet.Device;
using OneNet_CSharp.OneNet.NbIot;

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

    /// <summary>
    /// MQTT/EDP/Modbus/TCP 设备命令客户端
    /// </summary>
    public CommandClient Command => new CommandClient(_productid,_accessKey);

    /// <summary>
    /// LwM2M/NB-IoT 设备命令客户端
    /// </summary>
    public NbIotClient NbIot => new NbIotClient(_productid,_accessKey);
}