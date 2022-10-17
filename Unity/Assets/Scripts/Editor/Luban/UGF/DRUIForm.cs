//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using Bright.Serialization;
using System.Collections.Generic;
using SimpleJSON;



namespace editor.cfg.UGF
{

public sealed partial class DRUIForm :  Bright.Config.EditorBeanBase 
{
    public DRUIForm()
    {
            Desc = "";
            AssetName = "";
            UIGroupName = "";
    }

    public override void LoadJson(SimpleJSON.JSONObject _json)
    {
        { 
            var _fieldJson = _json["Id"];
            if (_fieldJson != null)
            {
                if(!_fieldJson.IsNumber) { throw new SerializationException(); }  Id = _fieldJson;
            }
        }
        
        { 
            var _fieldJson = _json["Desc"];
            if (_fieldJson != null)
            {
                if(!_fieldJson.IsString) { throw new SerializationException(); }  Desc = _fieldJson;
            }
        }
        
        { 
            var _fieldJson = _json["AssetName"];
            if (_fieldJson != null)
            {
                if(!_fieldJson.IsString) { throw new SerializationException(); }  AssetName = _fieldJson;
            }
        }
        
        { 
            var _fieldJson = _json["UIGroupName"];
            if (_fieldJson != null)
            {
                if(!_fieldJson.IsString) { throw new SerializationException(); }  UIGroupName = _fieldJson;
            }
        }
        
        { 
            var _fieldJson = _json["AllowMultiInstance"];
            if (_fieldJson != null)
            {
                if(!_fieldJson.IsBoolean) { throw new SerializationException(); }  AllowMultiInstance = _fieldJson;
            }
        }
        
        { 
            var _fieldJson = _json["PauseCoveredUIForm"];
            if (_fieldJson != null)
            {
                if(!_fieldJson.IsBoolean) { throw new SerializationException(); }  PauseCoveredUIForm = _fieldJson;
            }
        }
        
    }

    public override void SaveJson(SimpleJSON.JSONObject _json)
    {
        {
            _json["Id"] = new JSONNumber(Id);
        }
        {

            if (Desc == null) { throw new System.ArgumentNullException(); }
            _json["Desc"] = new JSONString(Desc);
        }
        {

            if (AssetName == null) { throw new System.ArgumentNullException(); }
            _json["AssetName"] = new JSONString(AssetName);
        }
        {

            if (UIGroupName == null) { throw new System.ArgumentNullException(); }
            _json["UIGroupName"] = new JSONString(UIGroupName);
        }
        {
            _json["AllowMultiInstance"] = new JSONBool(AllowMultiInstance);
        }
        {
            _json["PauseCoveredUIForm"] = new JSONBool(PauseCoveredUIForm);
        }
    }

    public static DRUIForm LoadJsonDRUIForm(SimpleJSON.JSONNode _json)
    {
        DRUIForm obj = new UGF.DRUIForm();
        obj.LoadJson((SimpleJSON.JSONObject)_json);
        return obj;
    }
        
    public static void SaveJsonDRUIForm(DRUIForm _obj, SimpleJSON.JSONNode _json)
    {
        _obj.SaveJson((SimpleJSON.JSONObject)_json);
    }

    /// <summary>
    /// 界面编号
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// 策划备注
    /// </summary>
    public string Desc { get; set; }

    /// <summary>
    /// 资源名称
    /// </summary>
    public string AssetName { get; set; }

    /// <summary>
    /// 界面组名称
    /// </summary>
    public string UIGroupName { get; set; }

    /// <summary>
    /// 是否允许多个界面实例
    /// </summary>
    public bool AllowMultiInstance { get; set; }

    /// <summary>
    /// 是否暂停被其覆盖的界面
    /// </summary>
    public bool PauseCoveredUIForm { get; set; }

}
}
