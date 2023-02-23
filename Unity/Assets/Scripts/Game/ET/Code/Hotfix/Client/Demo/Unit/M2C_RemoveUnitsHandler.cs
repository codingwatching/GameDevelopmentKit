﻿using Cysharp.Threading.Tasks;

namespace ET.Client
{
	[MessageHandler(SceneType.Client)]
	public class M2C_RemoveUnitsHandler : AMHandler<M2C_RemoveUnits>
	{
		protected override async UniTask Run(Session session, M2C_RemoveUnits message)
		{	
			UnitComponent unitComponent = session.DomainScene().CurrentScene()?.GetComponent<UnitComponent>();
			if (unitComponent == null)
			{
				return;
			}
			foreach (long unitId in message.Units)
			{
				unitComponent.Remove(unitId);
			}

			await UniTask.CompletedTask;
		}
	}
}