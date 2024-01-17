
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Luban;

namespace Game.Hot
{
public sealed partial class DRArmor : Luban.BeanBase
{
    public DRArmor(ByteBuf _buf) 
    {
        Id = _buf.ReadInt();
        MaxHP = _buf.ReadInt();
        Defense = _buf.ReadInt();
        PostLoad();
    }

    public static DRArmor DeserializeDRArmor(ByteBuf _buf)
    {
        return new DRArmor(_buf);
    }

    /// <summary>
    /// 装甲编号
    /// </summary>
    public readonly int Id;
    /// <summary>
    /// 最大生命
    /// </summary>
    public readonly int MaxHP;
    /// <summary>
    /// 防御力
    /// </summary>
    public readonly int Defense;

    public const int __ID__ = -1663135407;
    public override int GetTypeId() => __ID__;

    public  void ResolveRef(Tables tables)
    {
        
        
        
        PostResolveRef();
    }

    public override string ToString()
    {
        return "{ "
        + "Id:" + Id + ","
        + "MaxHP:" + MaxHP + ","
        + "Defense:" + Defense + ","
        + "}";
    }

    partial void PostLoad();
    partial void PostResolveRef();
}
}
