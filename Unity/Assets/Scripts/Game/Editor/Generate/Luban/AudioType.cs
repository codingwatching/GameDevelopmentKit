
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------


namespace Game.Editor
{
    public enum AudioType
    {
        UNKNOWN = 0,
        ACC = 1,
        AIFF = 2,
    }

    public static class AudioType_Metadata
    {
        public static readonly Luban.EditorEnumItemInfo UNKNOWN = new Luban.EditorEnumItemInfo("UNKNOWN", "", 0, "");
        public static readonly Luban.EditorEnumItemInfo ACC = new Luban.EditorEnumItemInfo("ACC", "", 1, "");
        public static readonly Luban.EditorEnumItemInfo AIFF = new Luban.EditorEnumItemInfo("AIFF", "", 2, "");

        private static readonly System.Collections.Generic.List<Luban.EditorEnumItemInfo> __items = new System.Collections.Generic.List<Luban.EditorEnumItemInfo>
        {
            UNKNOWN,
            ACC,
            AIFF,
        };

        public static System.Collections.Generic.List<Luban.EditorEnumItemInfo> GetItems() => __items;

        public static Luban.EditorEnumItemInfo GetByName(string name)
        {
            return __items.Find(c => c.Name == name);
        }

        public static Luban.EditorEnumItemInfo GetByNameOrAlias(string name)
        {
            return __items.Find(c => c.Name == name || c.Alias == name);
        }

        public static Luban.EditorEnumItemInfo GetByValue(int value)
        {
            return __items.Find(c => c.Value == value);
        }
    }

} 

