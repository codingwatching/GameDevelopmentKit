using UnityEngine;
using System.Collections.Generic;
#if UNITY_EDITOR
using UnityEditor;
using System.IO;
#endif

[System.Serializable]
public class UIColor
{
    public string ColorDefName;
    public Color colorValue;
    public string ColorComment;
    public UIColor(string name, Color color, string comm)
    {
        ColorDefName = name;
        colorValue = color;
        ColorComment = comm;
    }
}

[CreateAssetMenu(fileName = "ui_color_config", menuName = "UXTool/UI Color Asset")]
public class UIColorAsset : ScriptableObject
{
    [SerializeField]
    [NaughtyAttributes.ShowInInspector]
    public List<UIColor> defList = new List<UIColor>(){
        new UIColor("Color1", new Color(236f/255f,71f/255f,61f/255f,1),"Color1")
    };
    public bool HasSameNameOrEmptyName()
    {
        List<string> names = new List<string>();
        foreach (var single in defList)
        {
            if (string.IsNullOrEmpty(single.ColorDefName))
            {
                return true;
            }
            if (names.Contains(single.ColorDefName))
            {
                return true;
            }
            names.Add(single.ColorDefName);
        }
        return false;
    }

#if UNITY_EDITOR
    public void GenColorDefScript()
    {
        string needGenCsCode = "// This file is generated by code\n";
        needGenCsCode += "public sealed class UIColorGenDef {\n\tpublic enum UIColorConfigDef {\n";
        foreach (var single in defList)
        {
            needGenCsCode += $"\t\tDef_{single.ColorDefName.ToUpper()} = {Animator.StringToHash(single.ColorDefName)},\n";
        }
        needGenCsCode += "\t}\n}";
        string path = $"{UXGUIConfig.ScriptsRootPath}Runtime/Feature/UIColor/UIColorGenDef.cs";
        if (!File.Exists(path) || File.ReadAllText(path) != needGenCsCode)
        {
            File.WriteAllText(path, needGenCsCode);
        }
    }
#endif
}