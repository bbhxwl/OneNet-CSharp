using System.Collections.Generic;
using Newtonsoft.Json;

namespace OneNet_CSharp.OneNet.Device.Request;

public class AddRequest
{
    /// <summary>
    /// 产品ID
    /// </summary>
    [JsonProperty("product_id")]
    public string ProductId { get; set; }
    /// <summary>
    /// 设备名称，格式为英文字母、数字、短横线-和下划线_，长度不超过64位
    /// </summary>
    [JsonProperty("device_name")]
    public string DeviceName { get; set; }
    /// <summary>
    /// 设备描述，长度不超过100位
    /// </summary>
    [JsonProperty("desc")]
    public string Desc { get; set; }
    /// <summary>
    /// 经度
    /// </summary>
    [JsonProperty("lon")]
    public string Lon { get; set; }
    /// <summary>
    /// 纬度
    /// </summary>
    [JsonProperty("lat")]
    public string Lat { get; set; }
    /// <summary>
    /// 设备标签
    /// </summary>
    [JsonProperty("tags")]
    public List<string> Tags { get; set; }
    /// <summary>
    /// LwM2M设备专有，当接入协议为LwM2M时必填，15位数字
    /// </summary>
    [JsonProperty("imei")]
    public string Imei { get; set; }
    /// <summary>
    /// LwM2M设备专有，必填，1-15位数字
    /// </summary>
    [JsonProperty("imsi")]
    public string Imsi { get; set; }
    /// <summary>
    /// LwM2M设备专有，允许为空，当接入协议为LwM2M时该属性有效，格式为英文字母、数字，长度为8-16位，若不传/传空则平台自动生成一个随机字符串作为psk
    /// </summary>
    [JsonProperty("psk")]
    public string Psk { get; set; }
    /// <summary>
    /// LwM2M设备专有，允许为空，格式为英文字母、数字，长度不超过16位
    /// </summary>
    [JsonProperty("auth_code")]
    public string AuthCode { get; set; }
    /// <summary>
    /// 视联网设备专有，必填，1-国标，2-千里眼
    /// </summary>
    [JsonProperty("viot_protocol")]
    public int ViotProtocol { get; set; }
    /// <summary>
    /// 视联网设备专有，国标协议可选，默认 1-IPC
    /// </summary>
    [JsonProperty("viot_device_type")]
    public int ViotDeviceType { get; set; }
    /// <summary>
    /// 视联网设备专有，千里眼协议必填，设备mac，如：aabbccddeeff
    /// </summary>
    [JsonProperty("viot_device_mac")]
    public string ViotDeviceMac { get; set; }
    /// <summary>
    /// 视联网设备专有，千里眼协议必填，1-有线绑定，2-扫码绑定
    /// </summary>
    [JsonProperty("viot_login_type")]
    public int ViotLoginType { get; set; }
    /// <summary>
    /// 视联网设备专有，千里眼协议扫码绑定必填，WIFI名称
    /// </summary>
    [JsonProperty("viot_wifi_ssid")]
    public string ViotWifiSsid { get; set; }
    /// <summary>
    /// 视联网设备专有，千里眼协议扫码绑定必填，WIFI密码
    /// </summary>
    [JsonProperty("viot_wifi_pwd")]
    public string ViotWifiPwd { get; set; }
    /// <summary>
    /// 视联网设备专有，千里眼协议扫码绑定可选，WIFI加密方式：默认使用wpa/wpa2，0-无密码, 1-wpa, 2-wpa2, 3-wep, 4-wpa/wpa2
    /// </summary>
    [JsonProperty("viot_wifi_security")]
    public int ViotWifiSecurity { get; set; }
}