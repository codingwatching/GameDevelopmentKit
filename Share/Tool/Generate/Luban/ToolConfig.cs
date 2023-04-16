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

public partial class ToolConfig
{
    public RemoteBuilderConfig RemoteBuilderConfig { private set; get; }

    private Dictionary<string, IDataTable> _tables;

    public IEnumerable<IDataTable> DataTables => _tables.Values;

    public IDataTable GetDataTable(string tableName) => _tables.TryGetValue(tableName, out var v) ? v : null;

    public async Task LoadAsync(System.Func<string, Task<ByteBuf>> loader)
    {
        _tables = new Dictionary<string, IDataTable>();
        List<Task> loadTasks = new List<Task>();
        RemoteBuilderConfig = new RemoteBuilderConfig(() => loader("remotebuilderconfig")); 
        loadTasks.Add(RemoteBuilderConfig.LoadAsync());
        _tables.Add("RemoteBuilderConfig", RemoteBuilderConfig);

        await Task.WhenAll(loadTasks);

        PostInit();
        RemoteBuilderConfig.Resolve(_tables); 
        PostResolve();
    }

    public void TranslateText(System.Func<string, string, string> translator)
    {
        RemoteBuilderConfig.TranslateText(translator); 
    }
    
    partial void PostInit();
    partial void PostResolve();
}

}