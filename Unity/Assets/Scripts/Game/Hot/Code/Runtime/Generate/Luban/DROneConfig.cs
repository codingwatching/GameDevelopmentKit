
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
public sealed partial class DROneConfig : Luban.BeanBase
{
    public DROneConfig(ByteBuf _buf) 
    {
        GameId = _buf.ReadString();
        SceneMenu = _buf.ReadInt();
        SceneMain = _buf.ReadInt();
        PostLoad();
    }

    public static DROneConfig DeserializeDROneConfig(ByteBuf _buf)
    {
        return new DROneConfig(_buf);
    }

    public readonly string GameId;
    public readonly int SceneMenu;
    public readonly int SceneMain;

    public const int __ID__ = -2019618726;
    public override int GetTypeId() => __ID__;

    public  void ResolveRef(Tables tables)
    {
        
        
        
        PostResolveRef();
    }

    public override string ToString()
    {
        return "{ "
        + "GameId:" + GameId + ","
        + "SceneMenu:" + SceneMenu + ","
        + "SceneMain:" + SceneMain + ","
        + "}";
    }

    partial void PostLoad();
    partial void PostResolveRef();
}
}
