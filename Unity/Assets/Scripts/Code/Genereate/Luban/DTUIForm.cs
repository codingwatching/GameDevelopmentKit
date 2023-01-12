//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using Bright.Serialization;
using System.Collections.Generic;


namespace Game
{
   
public partial class DTUIForm
{
    private readonly Dictionary<int, DRUIForm> _dataMap;
    private readonly List<DRUIForm> _dataList;
    
    public DTUIForm(ByteBuf _buf)
    {
        _dataMap = new Dictionary<int, DRUIForm>();
        _dataList = new List<DRUIForm>();
        
        for(int n = _buf.ReadSize() ; n > 0 ; --n)
        {
            DRUIForm _v;
            _v = DRUIForm.DeserializeDRUIForm(_buf);
            _dataList.Add(_v);
            _dataMap.Add(_v.Id, _v);
        }
        PostInit();
    }

    public Dictionary<int, DRUIForm> DataMap => _dataMap;
    public List<DRUIForm> DataList => _dataList;

    public DRUIForm GetOrDefault(int key) => _dataMap.TryGetValue(key, out var v) ? v : null;
    public DRUIForm Get(int key) => _dataMap[key];
    public DRUIForm this[int key] => _dataMap[key];

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