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

public sealed partial class DTSound : IDataTable
{
    private readonly Dictionary<int, DRSound> _dataMap;
    private readonly List<DRSound> _dataList;
    private readonly System.Func<Task<ByteBuf>> _loadFunc;

    public DTSound(System.Func<Task<ByteBuf>> loadFunc)
    {
        _loadFunc = loadFunc;
        _dataMap = new Dictionary<int, DRSound>();
        _dataList = new List<DRSound>();
    }

    public async Task LoadAsync()
    {
        ByteBuf _buf = await _loadFunc();
        _dataMap.Clear();
        _dataList.Clear();
        for(int n = _buf.ReadSize() ; n > 0 ; --n)
        {
            DRSound _v;
            _v = DRSound.DeserializeDRSound(_buf);
            _dataList.Add(_v);
            _dataMap.Add(_v.Id, _v);
        }
        PostInit();
    }

    public Dictionary<int, DRSound> DataMap => _dataMap;
    public List<DRSound> DataList => _dataList;
    public DRSound GetOrDefault(int key) => _dataMap.TryGetValue(key, out var v) ? v : null;
    public DRSound Get(int key) => _dataMap[key];
    public DRSound this[int key] => _dataMap[key];

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