//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using Bright.Serialization;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace Game
{

public sealed partial class DTEntity : IDataTable
{
    private readonly Dictionary<int, DREntity> _dataMap;
    private readonly List<DREntity> _dataList;
    private readonly System.Func<Task<ByteBuf>> _loadFunc;

    public DTEntity(System.Func<Task<ByteBuf>> loadFunc)
    {
        _loadFunc = loadFunc;
        _dataMap = new Dictionary<int, DREntity>();
        _dataList = new List<DREntity>();
    }

    public async Task LoadAsync()
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
        PostInit();
    }

    public Dictionary<int, DREntity> DataMap => _dataMap;
    public List<DREntity> DataList => _dataList;
    public DREntity GetOrDefault(int key) => _dataMap.TryGetValue(key, out var v) ? v : null;
    public DREntity Get(int key) => _dataMap[key];
    public DREntity this[int key] => _dataMap[key];

    public void Resolve(Dictionary<string, IDataTable> _tables)
    {
        foreach(var v in _dataList)
        {
            v.Resolve(_tables);
        }
        PostResolve();
    }

    public void TranslateText(System.Func<string, string, string> translator)
    {
        foreach(var v in _dataList)
        {
            v.TranslateText(translator);
        }
    }

 
    partial void PostInit();
    partial void PostResolve();
}
}