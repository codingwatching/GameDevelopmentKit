
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Luban;

namespace ET
{
public sealed partial class DROneConfig : Luban.BeanBase
{
    public DROneConfig(ByteBuf _buf) 
    {
        MaxMatchTime = _buf.ReadLong();
        Test = _buf.ReadInt();
        PostInit();
    }

    public static DROneConfig DeserializeDROneConfig(ByteBuf _buf)
    {
        return new DROneConfig(_buf);
    }

    /// <summary>
    /// 匹配最大时间
    /// </summary>
    public readonly long MaxMatchTime;
    /// <summary>
    /// 匹配最大时间
    /// </summary>
    public readonly int Test;
    public const int __ID__ = -2019618726;
    public override int GetTypeId() => __ID__;

    public  void ResolveRef(Tables tables)
    {
        PostResolveRef();
    }

    public override string ToString()
    {
        return "{ "
        + "MaxMatchTime:" + MaxMatchTime + ","
        + "Test:" + Test + ","
        + "}";
    }

    partial void PostInit();
    partial void PostResolveRef();
}
}
