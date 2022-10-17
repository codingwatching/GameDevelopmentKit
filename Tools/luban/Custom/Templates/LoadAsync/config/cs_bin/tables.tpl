using Bright.Serialization;
using ET;

{{
    name = x.name
    namespace = x.namespace
    tables = x.tables

}}
namespace {{namespace}}
{
   
public partial class {{name}}
{
    {{~for table in tables ~}}
{{~if table.comment != '' ~}}
    /// <summary>
    /// {{table.escape_comment}}
    /// </summary>
{{~end~}}
    public {{table.full_name}} {{table.name}} {get; private set; }
    {{~end~}}

    public async ETTask LoadAsync(System.Func<string, ETTask<ByteBuf>> loader)
    {
        var tables = new System.Collections.Generic.Dictionary<string, object>();
        {{~for table in tables ~}}
        {{table.name}} = new {{table.full_name}}(await loader("{{table.output_data_file}}")); 
        tables.Add("{{table.full_name}}", {{table.name}});
        {{~end~}}

        PostInit();
        {{~for table in tables ~}}
        {{table.name}}.Resolve(tables); 
        {{~end~}}
        PostResolve();
    }

    public void TranslateText(System.Func<string, string, string> translator)
    {
        {{~for table in tables ~}}
        {{table.name}}.TranslateText(translator); 
        {{~end~}}
    }
    
    partial void PostInit();
    partial void PostResolve();
}

}