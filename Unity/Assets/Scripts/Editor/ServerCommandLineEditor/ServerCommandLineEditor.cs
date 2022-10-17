﻿using System.Collections.Generic;
using System.IO;
using System.Linq;
using editor.cfg.ET;
using SimpleJSON;
using UnityEditor;
using UnityEngine;

namespace ET
{
    public enum DevelopMode
    {
        正式 = 0,
        开发 = 1,
        压测 = 2,
    }
    
    public class ServerCommandLineEditor: EditorWindow
    {
        [MenuItem("ET/ServerTools")]
        public static void ShowWindow()
        {
            GetWindow<ServerCommandLineEditor>(DockDefine.Types);
        }
        
        private int selectStartConfigIndex;
        private string[] startConfigs;
        private string startConfig;
        private DevelopMode developMode;

        public void OnEnable()
        {
            JSONNode jsonNode = JSONNode.Parse(File.ReadAllText("Assets/Res/Editor/Luban/et_dtstartmachineconfig.json"));
            List<string> configs = new List<string>();
            foreach (var childNode in jsonNode.Children)
            {
                DRStartMachineConfig config = DRStartMachineConfig.LoadJsonDRStartMachineConfig(childNode);
                if (!configs.Contains(config.StartConfig))
                {
                    configs.Add(config.StartConfig);
                }
            }
            this.startConfigs = configs.ToArray();
        }

        public void OnGUI()
        {
            selectStartConfigIndex = EditorGUILayout.Popup(selectStartConfigIndex, this.startConfigs);
            this.startConfig = this.startConfigs[this.selectStartConfigIndex];
            this.developMode = (DevelopMode) EditorGUILayout.EnumPopup("起服模式：", this.developMode);
            int develop = (int) this.developMode;

            string dotnet = "dotnet.exe";
            
#if UNITY_EDITOR_OSX
            dotnet = "dotnet";
#endif
            
            if (GUILayout.Button("Start Server(Single Process)"))
            {
                string arguments = $"App.dll --Process=1 --StartConfig={this.startConfig} --Console=1";
                ProcessHelper.Run(dotnet, arguments, "../Bin/");
            }
            
            if (GUILayout.Button("Start Watcher"))
            {
                string arguments = $"App.dll --AppType=Watcher --StartConfig={this.startConfig} --Console=1";
                ProcessHelper.Run(dotnet, arguments, "../Bin/");
            }

            if (GUILayout.Button("Start Mongo"))
            {
                ProcessHelper.Run("mongod", @"--dbpath=db", "../Database/bin/");
            }
        }
    }
}
