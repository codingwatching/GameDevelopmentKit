
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Luban;

namespace Game
{
public partial class DTEntity : IDataTable
{
    private readonly System.Collections.Generic.Dictionary<int, DREntity> _dataMap;
    private readonly System.Collections.Generic.List<DREntity> _dataList;
    private readonly System.Func<Cysharp.Threading.Tasks.UniTask<ByteBuf>> _loadFunc;

    public DTEntity(System.Func<Cysharp.Threading.Tasks.UniTask<ByteBuf>> loadFunc)
    {
        _loadFunc = loadFunc;
        _dataMap = new System.Collections.Generic.Dictionary<int, DREntity>();
        _dataList = new System.Collections.Generic.List<DREntity>();
    }

    public async Cysharp.Threading.Tasks.UniTask LoadAsync()
    {
        ByteBuf _buf = await _loadFunc();
        _dataMap.Clear();
        _dataList.Clear();
        for(int n = _buf.ReadSize() ; n > 0 ; --n)
        {
            DREntity _v;
            _v = DREntity.DeserializeDREntity(_buf);
            _dataList.Add(_v);
            _dataMap.Add(_v.Id, _v);
        }
        PostLoad();
    }

    public System.Collections.Generic.Dictionary<int, DREntity> DataMap => _dataMap;
    public System.Collections.Generic.List<DREntity> DataList => _dataList;

    public DREntity GetOrDefault(int key) => _dataMap.TryGetValue(key, out var v) ? v : null;
    public DREntity Get(int key) => _dataMap[key];
    public DREntity this[int key] => _dataMap[key];

    public void ResolveRef(TablesComponent tables)
    {
        foreach(var _v in _dataList)
        {
            _v.ResolveRef(tables);
        }
        PostResolveRef();
    }


    partial void PostLoad();
    partial void PostResolveRef();
}
}
