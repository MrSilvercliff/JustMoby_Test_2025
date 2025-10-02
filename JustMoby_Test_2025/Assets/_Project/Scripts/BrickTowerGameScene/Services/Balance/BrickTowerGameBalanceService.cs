using _Project.Scripts.Project.Services.Balance;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZerglingUnityPlugins.Tools.Scripts.Interfaces.ProjectService.AsyncSync;

namespace _Project.Scripts.BrickTowerGameScene.Services.Balance
{
    public interface IBrickTowerGameBalanceService : IBalanceService
    { 
    }

    public class BrickTowerGameBalanceService : BalanceService, IBrickTowerGameBalanceService
    {
        public BrickTowerGameBalanceService()
        { 
        }

        protected override HashSet<IProjectService> GetStoragesToInit()
        {
            var result = new HashSet<IProjectService>();
            return result;
        }
    }
}