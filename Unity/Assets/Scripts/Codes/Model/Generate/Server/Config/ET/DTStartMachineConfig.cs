//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using Bright.Serialization;
using System.Collections.Generic;

namespace cfg.ET
{
   
public partial class DTStartMachineConfig
{
    private readonly List<ET.DRStartMachineConfig> _dataList;

    private Dictionary<(string, int), ET.DRStartMachineConfig> _dataMapUnion;

    public DTStartMachineConfig(ByteBuf _buf)
    {
        _dataList = new List<ET.DRStartMachineConfig>();
        
        for(int n = _buf.ReadSize() ; n > 0 ; --n)
        {
            ET.DRStartMachineConfig _v;
            _v = ET.DRStartMachineConfig.DeserializeDRStartMachineConfig(_buf);
            _dataList.Add(_v);
        }
        _dataMapUnion = new Dictionary<(string, int), ET.DRStartMachineConfig>();
        foreach(var _v in _dataList)
        {
            _dataMapUnion.Add((_v.StartConfig, _v.Id), _v);
        }
        PostInit();
    }


    public List<ET.DRStartMachineConfig> DataList => _dataList;

    public ET.DRStartMachineConfig Get(string StartConfig, int Id) => _dataMapUnion.TryGetValue((StartConfig, Id), out ET.DRStartMachineConfig __v) ? __v : null;

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