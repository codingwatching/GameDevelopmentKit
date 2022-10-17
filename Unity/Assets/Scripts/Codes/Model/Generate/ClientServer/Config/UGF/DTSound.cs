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
   
public partial class DTSound
{
    private readonly Dictionary<int, UGF.DRSound> _dataMap;
    private readonly List<UGF.DRSound> _dataList;
    
    public DTSound(ByteBuf _buf)
    {
        _dataMap = new Dictionary<int, UGF.DRSound>();
        _dataList = new List<UGF.DRSound>();
        
        for(int n = _buf.ReadSize() ; n > 0 ; --n)
        {
            UGF.DRSound _v;
            _v = UGF.DRSound.DeserializeDRSound(_buf);
            _dataList.Add(_v);
            _dataMap.Add(_v.Id, _v);
        }
        PostInit();
    }

    public Dictionary<int, UGF.DRSound> DataMap => _dataMap;
    public List<UGF.DRSound> DataList => _dataList;

    public UGF.DRSound GetOrDefault(int key) => _dataMap.TryGetValue(key, out var v) ? v : null;
    public UGF.DRSound Get(int key) => _dataMap[key];
    public UGF.DRSound this[int key] => _dataMap[key];

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