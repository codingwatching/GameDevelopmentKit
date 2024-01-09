//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using Bright.Serialization;
using System.Collections.Generic;

namespace ET
{
public sealed partial class DRUnitConfig :  Bright.Config.BeanBase 
{
    public DRUnitConfig(ByteBuf _buf) 
    {
        Id = _buf.ReadInt();
        Type = _buf.ReadInt();
        Name = _buf.ReadString();
        Desc = _buf.ReadString();
        Position = _buf.ReadInt();
        Height = _buf.ReadInt();
        PostInit();
    }

    public static DRUnitConfig DeserializeDRUnitConfig(ByteBuf _buf)
    {
        return new DRUnitConfig(_buf);
    }

    /// <summary>
    /// Id
    /// </summary>
    public int Id { get; private set; }
    /// <summary>
    /// Type
    /// </summary>
    public int Type { get; private set; }
    /// <summary>
    /// 名字
    /// </summary>
    public string Name { get; private set; }
    /// <summary>
    /// 描述
    /// </summary>
    public string Desc { get; private set; }
    /// <summary>
    /// 位置
    /// </summary>
    public int Position { get; private set; }
    /// <summary>
    /// 身高
    /// </summary>
    public int Height { get; private set; }
    public const int __ID__ = -1701961452;
    public override int GetTypeId() => __ID__;

    public void Resolve(Dictionary<string, IDataTable> _tables)
    {
        PostResolve();
    }

    public void TranslateText(System.Func<string, string, string> translator)
    {
    }

    public override string ToString()
    {
        return "{ "
        + "Id:" + Id + ","
        + "Type:" + Type + ","
        + "Name:" + Name + ","
        + "Desc:" + Desc + ","
        + "Position:" + Position + ","
        + "Height:" + Height + ","
        + "}";
    }

    partial void PostInit();
    partial void PostResolve();
}
}