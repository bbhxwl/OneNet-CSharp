using System;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace OneNet_CSharp.OneNet;

public class OneNetAuthHelper
{
    /// <summary>
    /// 生成 OneNET 安全鉴权 Token
    /// </summary>
    /// <param name="res">资源</param>
    /// <param name="accessKey">AccessKey (Base64格式)</param>
    /// <param name="expireInSeconds">Token过期时间(秒)，默认1小时</param>
    /// <param name="version">Token过期时间(秒)，默认1小时</param>
    /// <returns>计算好的 Token 字符串</returns>
    public static string GenerateToken(string res, string accessKey, int expireInSeconds = 3600,string version="2022-05-01")
    {
        string method = "sha1";
        // 计算过期时间戳 (Unix时间戳)
        long et = DateTimeOffset.Now.AddSeconds(expireInSeconds).ToUnixTimeSeconds();
        // 2. 拼接“待签名字符串” (注意顺序必须是: et -> method -> res -> version)
        // 并且必须以换行符 \n 连接
        StringBuilder sb = new StringBuilder();
        sb.Append(et).Append("\n")
            .Append(method).Append("\n")
            .Append(res).Append("\n")
            .Append(version);
        string stringForSignature = sb.ToString();
        // 3. 计算签名 (Signature)
        // 关键点：AccessKey 需要先 Base64 解码
        byte[] keyBytes = Convert.FromBase64String(accessKey);
        string sign = "";
        using (var hmac = new HMACSHA1(keyBytes))
        {
            byte[] signBytes = hmac.ComputeHash(Encoding.UTF8.GetBytes(stringForSignature));
            // 签名结果再做一次 Base64 编码
            sign = Convert.ToBase64String(signBytes);
        }
        // 4. 拼接最终 Token (注意：res 和 sign 必须进行 URL 编码)
        // 使用 Uri.EscapeDataString 可以兼容 .NET Core 和 Framework，不需要引用 System.Web
        string token = $"version={version}&res={HttpUtility.UrlEncode(res)}&et={et}&method={method}&sign={HttpUtility.UrlEncode(sign)}";
        return token;
    }
    public static string GenerateClientToken(string productId,string deviceName,string deviceAccessKey,int expireInSeconds=3600)
    {
        var token = GenerateToken($"products/{productId}/devices/{deviceName}",deviceAccessKey, version:"2018-10-31", expireInSeconds: expireInSeconds);
        return token;
    }
}