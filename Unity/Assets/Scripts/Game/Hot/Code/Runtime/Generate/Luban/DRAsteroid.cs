//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using Bright.Serialization;
using System.Collections.Generic;

namespace Game.Hot
{
public sealed partial class DRAsteroid :  Bright.Config.BeanBase 
{
    public DRAsteroid(ByteBuf _buf) 
    {
        Id = _buf.ReadInt();
        MaxHP = _buf.ReadInt();
        Attack = _buf.ReadInt();
        Speed = _buf.ReadFloat();
        AngularSpeed = _buf.ReadFloat();
        DeadEffectId = _buf.ReadInt();
        DeadSoundId = _buf.ReadInt();
        PostInit();
    }

    public static DRAsteroid DeserializeDRAsteroid(ByteBuf _buf)
    {
        return new DRAsteroid(_buf);
    }

    /// <summary>
    /// 小行星编号
    /// </summary>
    public int Id { get; private set; }
    /// <summary>
    /// 最大生命
    /// </summary>
    public int MaxHP { get; private set; }
    /// <summary>
    /// 冲击力
    /// </summary>
    public int Attack { get; private set; }
    /// <summary>
    /// 速度
    /// </summary>
    public float Speed { get; private set; }
    /// <summary>
    /// 角速度
    /// </summary>
    public float AngularSpeed { get; private set; }
    /// <summary>
    /// 死亡特效编号
    /// </summary>
    public int DeadEffectId { get; private set; }
    /// <summary>
    /// 死亡声音编号
    /// </summary>
    public int DeadSoundId { get; private set; }
    public const int __ID__ = 1354599273;
    public override int GetTypeId() => __ID__;

    public  void Resolve(Dictionary<string, IDataTable> _tables)
    {
        PostResolve();
    }

    public  void TranslateText(System.Func<string, string, string> translator)
    {
    }

    public override string ToString()
    {
        return "{ "
        + "Id:" + Id + ","
        + "MaxHP:" + MaxHP + ","
        + "Attack:" + Attack + ","
        + "Speed:" + Speed + ","
        + "AngularSpeed:" + AngularSpeed + ","
        + "DeadEffectId:" + DeadEffectId + ","
        + "DeadSoundId:" + DeadSoundId + ","
        + "}";
    }

    partial void PostInit();
    partial void PostResolve();
}
}