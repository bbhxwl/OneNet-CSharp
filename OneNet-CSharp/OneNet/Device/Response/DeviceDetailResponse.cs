using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace OneNet_CSharp.OneNet.Device.Response;

public class DeviceDetailResponse
{
    [JsonProperty("did")]
    public string Did { get; set; }
    [JsonProperty("pid")]
    public string PId { get; set; }
    /// <summary>
    /// 接入协议
    /// </summary>
    [JsonProperty("access_pt")]
    public int AccessPt { get; set; }
    /// <summary>
    /// 数据协议
    /// </summary>
    [JsonProperty("data_pt")]
    public string DataPt { get; set; }

    /// <summary>
    /// 设备名称
    /// </summary>
    [JsonProperty("name")]
    public string Name { get; set; }
    /// <summary>
    /// 设备描述
    /// </summary>
    [JsonProperty("desc")]
    public string Desc { get; set; }
    
    [JsonProperty("auth_info")]
    public string AuthInfo { get; set; }

    /// <summary>
    /// 设备状态，0-离线，1-在线，2-未激活
    /// </summary>
    [JsonProperty("status")]
    public int Status { get; set; }
    /// <summary>
    /// 设备创建时间
    /// </summary>
    [JsonProperty("create_time")]
    public DateTime CreateTime { get; set; }
    /// <summary>
    /// 设备激活时间
    /// </summary>
    [JsonProperty("activate_time")]
    public DateTime ActivateTime { get; set; }
    /// <summary>
    /// 设备最后一次在线时间
    /// </summary>
    [JsonProperty("last_time")]
    public DateTime LastTime { get; set; }
    /// <summary>
    /// 设备接入鉴权 key
    /// </summary>
    [JsonProperty("sec_key")]
    public string SecKey { get; set; }
    /// <summary>
    /// LwM2M 设备 imei
    /// </summary>
    [JsonProperty("imei")]
    public string Imei { get; set; }
    /// <summary>
    /// LwM2M 设备 imsi
    /// </summary>
    [JsonProperty("imsi")]
    public string Imsi { get; set; }
    /// <summary>
    /// LwM2M 设备 psk
    /// </summary>
    [JsonProperty("psk")]
    public string Psk { get; set; }
    /// <summary>
    /// LwM2M 设备 auth_code
    /// </summary>
    [JsonProperty("auth_code")]
    public string AuthCode { get; set; }
    /// <summary>
    /// 产品智能化方式，1-设备接入、2-产品智能化
    /// </summary>
    [JsonProperty("intelligent_way")]
    public int IntelligentWay { get; set; }
   
    [JsonProperty("group_id")]
    public string GroupId { get; set; }
    [JsonProperty("enable_status")]
    public bool EnableStatus { get; set; }
    [JsonProperty("tags")]
    public List<string> Tags { get; set; }
    [JsonProperty("lon")]
    public string Lon { get; set; }
    [JsonProperty("lat")]
    public string Lat { get; set; }
    [JsonProperty("chip")]
    public string Chip { get; set; }
    /// <summary>
    /// 设备资源自动订阅是否启用
    /// </summary>
    [JsonProperty("obsv")]
    public bool Obsv { get; set; }
    /// <summary>
    /// 设备资源自动订阅状态
    /// </summary>
    [JsonProperty("obsv_st")]
    public bool ObsvAt { get; set; }
    /// <summary>
    /// 设备私密性
    /// </summary>
    [JsonProperty("private")]
    public bool Private { get; set; }
    /// <summary>
    /// 设备 imsi 历史变更记录
    /// </summary>
    [JsonProperty("imsi_old")]
    public List<string> ImsiOld { get; set; }
    /// <summary>
    /// 设备 imsi 最近一次修改时间
    /// </summary>
    [JsonProperty("imsi_mt")]
    public DateTime ImsiMt { get; set; }
    /// <summary>
    /// 视频设备编码，视联网设备返回
    /// </summary>
    [JsonProperty("viot_device_sn")]
    public string ViotDeviceSn { get; set; }
    /// <summary>
    /// 视频设备接入协议，视联网设备返回，1-GB28181 协议，2-千里眼协议
    /// </summary>
    [JsonProperty("viot_protocol")]
    public int ViotProtocol { get; set; }
    /// <summary>
    /// 视频设备设备类型，视联网设备返回1-IPC，2-NVR
    /// </summary>
    [JsonProperty("viot_device_type")]
    public int ViotDeviceType { get; set; }
    /// <summary>
    /// SIP 服务器 ID，国标摄像头设备返回
    /// </summary>
    [JsonProperty("viot_sip_server_id")]
    public string ViotSipServerId { get; set; }
    /// <summary>
    /// SIP 服务器域，国标摄像头设备返回
    /// </summary>
    [JsonProperty("viot_sip_server_domain")]
    public string ViotSipServerDomain { get; set; }
    /// <summary>
    /// SIP 服务器 IP，国标摄像头设备返回
    /// </summary>
    [JsonProperty("viot_sip_server_ip")]
    public string ViotSipServerIp { get; set; }
    /// <summary>
    /// SIP 服务器端口，国标摄像头设备返回
    /// </summary>
    [JsonProperty("viot_sip_server_port")]
    public string ViotSipServerPort { get; set; }
    /// <summary>
    /// 登录用户名，国标摄像头设备返回
    /// </summary>
    [JsonProperty("viot_login_name")]
    public string ViotLoginName { get; set; }
    /// <summary>
    /// 登录密码，国标摄像头设备返回
    /// </summary>
    [JsonProperty("viot_login_pwd")]
    public string ViotLoginPwd { get; set; }
    /// <summary>
    /// 设备 modelId，如：cmiot_E4702_002
    /// </summary>
    [JsonProperty("viot_module_id")]
    public string ViotModuleId { get; set; }
    /// <summary>
    /// 软件版本，如：2.860.20250512
    /// </summary>
    [JsonProperty("viot_camera_app_version")]
    public string ViotCameraAppVersion { get; set; }
    /// <summary>
    /// 固件版本，如：2.860.20250512
    /// </summary>
    [JsonProperty("viot_firmware_version")]
    public string ViotFirmwareVersion { get; set; }
    /// <summary>
    /// 千里眼设备 imei（cmei），如：119094672043670
    /// </summary>
    [JsonProperty("viot_imei")]
    public string ViotImei { get; set; }
}