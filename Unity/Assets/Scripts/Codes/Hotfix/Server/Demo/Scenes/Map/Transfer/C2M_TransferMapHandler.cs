﻿using System;
using cfg;
using cfg.ET;

namespace ET.Server
{
	[ActorMessageHandler(SceneType.Map)]
	public class C2M_TransferMapHandler : AMActorLocationRpcHandler<Unit, C2M_TransferMap, M2C_TransferMap>
	{
		protected override async ETTask Run(Unit unit, C2M_TransferMap request, M2C_TransferMap response, Action reply)
		{
			await ETTask.CompletedTask;

			string currentMap = unit.DomainScene().Name;
			string toMap = null;
			if (currentMap == "Map1")
			{
				toMap = "Map2";
			}
			else
			{
				toMap = "Map1";
			}

			DRStartSceneConfig startSceneConfig = DataTables.Instance.DTStartSceneConfig.GetBySceneName(unit.DomainScene().Zone, toMap);
			TransferHelper.Transfer(unit, startSceneConfig.InstanceId, toMap).Coroutine();
			
			reply();
		}
	}
}