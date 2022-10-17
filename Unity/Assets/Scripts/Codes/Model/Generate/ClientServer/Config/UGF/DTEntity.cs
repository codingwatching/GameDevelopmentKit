//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using Bright.Serialization;
using System.Collections.Generic;

namespace cfg.UGF
{
   
public partial class DTEntity
{
    private readonly Dictionary<int, UGF.DREntity> _dataMap;
    private readonly List<UGF.DREntity> _dataList;
    
    public DTEntity(ByteBuf _buf)
    {
        _dataMap = new Dictionary<int, UGF.DREntity>();
        _dataList = new List<UGF.DREntity>();
        
        for(int n = _buf.ReadSize() ; n > 0 ; --n)
        {
            UGF.DREntity _v;
            _v = UGF.DREntity.DeserializeDREntity(_buf);
            _dataList.Add(_v);
            _dataMap.Add(_v.Id, _v);
        }
        PostInit();
    }

    public Dictionary<int, UGF.DREntity> DataMap => _dataMap;
    public List<UGF.DREntity> DataList => _dataList;

    public UGF.DREntity GetOrDefault(int key) => _dataMap.TryGetValue(key, out var v) ? v : null;
    public UGF.DREntity Get(int key) => _dataMap[key];
    public UGF.DREntity this[int key] => _dataMap[key];

    public void Resolve(Dictionary<string, object> _tables)
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