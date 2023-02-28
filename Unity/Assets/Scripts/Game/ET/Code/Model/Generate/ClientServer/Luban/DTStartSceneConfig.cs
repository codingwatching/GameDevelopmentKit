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

namespace ET
{
   
public partial class DTStartSceneConfig : IDataTable
{
    private readonly List<DRStartSceneConfig> _dataList;

    private readonly Dictionary<(string, int), DRStartSceneConfig> _dataMapUnion;

    private readonly Task<ByteBuf> _loadFunc;

    public DTStartSceneConfig(Task<ByteBuf> loadFunc)
    {
        _loadFunc = loadFunc;
        _dataList = new List<DRStartSceneConfig>();
        _dataMapUnion = new Dictionary<(string, int), DRStartSceneConfig>();
    }

    public async Task LoadAsync()
    {
        ByteBuf _buf = await _loadFunc;

        _dataList.Clear();
        
        for(int n = _buf.ReadSize() ; n > 0 ; --n)
        {
            DRStartSceneConfig _v;
            _v = DRStartSceneConfig.DeserializeDRStartSceneConfig(_buf);
            _dataList.Add(_v);
        }
        _dataMapUnion.Clear();
        foreach(var _v in _dataList)
        {
            _dataMapUnion.Add((_v.StartConfig, _v.Id), _v);
        }
        PostInit();
    }


    public List<DRStartSceneConfig> DataList => _dataList;

    public DRStartSceneConfig Get(string StartConfig, int Id) => _dataMapUnion.TryGetValue((StartConfig, Id), out DRStartSceneConfig __v) ? __v : null;

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