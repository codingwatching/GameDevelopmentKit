﻿#if UNITY_EDITOR || UNITY_STANDALONE || DOTNET
using System;

namespace ET.Server
{
    [FriendOf(typeof(DBManagerComponent))]
    public static partial class DBManagerComponentSystem
    {
        public static DBComponent GetZoneDB(this DBManagerComponent self, int zone)
        {
            DBComponent dbComponent = self.GetChild<DBComponent>(zone);
            if (dbComponent != null)
            {
                return dbComponent;
            }

            var startZoneConfig = Tables.Instance.DTStartZoneConfig.Get(Options.Instance.StartConfig, zone);
            if (startZoneConfig.DBConnection == "")
            {
                throw new Exception($"zone: {zone} not found mongo connect string");
            }

            dbComponent = self.AddChildWithId<DBComponent, string, string>(zone, startZoneConfig.DBConnection, startZoneConfig.DBName);
            return dbComponent;
        }
    }
}
#endif