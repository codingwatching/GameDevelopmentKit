﻿using System;
using System.IO;
using UnityEditor;
using UnityEditor.Compilation;
using UnityEngine;
using Debug = UnityEngine.Debug;

namespace ET
{
	public enum PlatformType
	{
		None,
		Android,
		IOS,
		PC,
		MacOS,
	}
	
	public enum BuildType
	{
		Development,
		Release,
	}

	public class BuildEditor : EditorWindow
	{
		private PlatformType activePlatform;
		private PlatformType platformType;
		private bool clearFolder;
		private bool isBuildExe;
		private bool isContainAB;
		private CodeOptimization codeOptimization = CodeOptimization.Debug;
		private BuildOptions buildOptions;
		private BuildAssetBundleOptions buildAssetBundleOptions = BuildAssetBundleOptions.None;

		private CodeMode codeMode;

		[MenuItem("ET/Build Tool")]
		public static void ShowWindow()
		{
			GetWindow<BuildEditor>(DockDefine.Types);
		}

        private void OnEnable()
		{
			codeMode = AssetDatabase.LoadAssetAtPath<GlobalConfig>("Assets/Res/Builtin/ETGlobalConfig.asset").CodeMode;
			
#if UNITY_ANDROID
			activePlatform = PlatformType.Android;
#elif UNITY_IOS
			activePlatform = PlatformType.IOS;
#elif UNITY_STANDALONE_WIN
			activePlatform = PlatformType.PC;
#elif UNITY_STANDALONE_OSX
			activePlatform = PlatformType.MacOS;
#else
			activePlatform = PlatformType.None;
#endif
            platformType = activePlatform;
        }

        private void OnGUI() 
		{
			this.platformType = (PlatformType)EditorGUILayout.EnumPopup(platformType);
			this.clearFolder = EditorGUILayout.Toggle("clean folder? ", clearFolder);
			this.isBuildExe = EditorGUILayout.Toggle("build exe?", this.isBuildExe);
			this.isContainAB = EditorGUILayout.Toggle("contain assetsbundle?", this.isContainAB);
			this.codeOptimization = (CodeOptimization)EditorGUILayout.EnumPopup("CodeOptimization ", this.codeOptimization);
			EditorGUILayout.LabelField("BuildAssetBundleOptions ");
			this.buildAssetBundleOptions = (BuildAssetBundleOptions)EditorGUILayout.EnumFlagsField(this.buildAssetBundleOptions);
			
			switch (this.codeOptimization)
			{
				case CodeOptimization.None:
				case CodeOptimization.Debug:
					this.buildOptions = BuildOptions.Development | BuildOptions.ConnectWithProfiler;
					break;
				case CodeOptimization.Release:
					this.buildOptions = BuildOptions.None;
					break;
			}

			GUILayout.Space(5);
			
			if (GUILayout.Button("BuildPackage"))
			{
				if (this.platformType == PlatformType.None)
				{
					ShowNotification(new GUIContent("please select platform!"));
					return;
				}
				if (platformType != activePlatform)
				{
					switch (EditorUtility.DisplayDialogComplex("Warning!", $"current platform is {activePlatform}, if change to {platformType}, may be take a long time", "change", "cancel", "no change"))
					{
						case 0:
							activePlatform = platformType;
							break;
						case 1:
							return;
						case 2:
							platformType = activePlatform;
							break;
					}
				}
				BuildHelper.Build(this.platformType, this.buildAssetBundleOptions, this.buildOptions, this.isBuildExe, this.isContainAB, this.clearFolder);
			}
			
			GUILayout.Label("");
			GUILayout.Label("Code Compile：");
			
			//this.codeMode = (CodeMode)EditorGUILayout.EnumPopup("CodeMode: ", this.codeMode);
			EditorGUILayout.EnumPopup("CodeMode: ", this.codeMode);
			
			if (GUILayout.Button("BuildModelAndHotfix"))
			{
				if (Define.EnableCodes)
				{
					throw new Exception("now in ENABLE_CODES mode, do not need Build!");
				}
				BuildAssembliesHelper.BuildModel(this.codeOptimization, this.codeMode);
				BuildAssembliesHelper.BuildHotfix(this.codeOptimization, this.codeMode);

				AfterCompiling();
				
				ShowNotification("Build Model And Hotfix Success!");
			}
			
			if (GUILayout.Button("BuildModel"))
			{
				if (Define.EnableCodes)
				{
					throw new Exception("now in ENABLE_CODES mode, do not need Build!");
				}
				BuildAssembliesHelper.BuildModel(this.codeOptimization, this.codeMode);

				AfterCompiling();
				
				ShowNotification("Build Model Success!");
			}
			
			if (GUILayout.Button("BuildHotfix"))
			{
				if (Define.EnableCodes)
				{
					throw new Exception("now in ENABLE_CODES mode, do not need Build!");
				}
				BuildAssembliesHelper.BuildHotfix(this.codeOptimization, this.codeMode);

				AfterCompiling();
				
				ShowNotification("Build Hotfix Success!");
			}
			
			if (GUILayout.Button("ExcelExporter"))
			{
				//Directory.Delete("Assets/Bundles/Config", true);
				ToolsEditor.ExcelExporter();
				
				AssetDatabase.SaveAssets();
				AssetDatabase.Refresh();
			}
			
			if (GUILayout.Button("Proto2CS"))
			{
				ToolsEditor.Proto2CS();
			}

			GUILayout.Space(5);
		}
		
		private static void AfterCompiling()
		{
			Directory.CreateDirectory(BuildAssembliesHelper.CodeDir);
			
			AssetDatabase.SaveAssets();
			AssetDatabase.Refresh();
            
			Debug.Log("build success!");
		}
		
		public static void ShowNotification(string tips)
		{
			EditorWindow game = EditorWindow.GetWindow(typeof(EditorWindow).Assembly.GetType("UnityEditor.GameView"));
			game?.ShowNotification(new GUIContent($"{tips}"));
		}
	}
}
