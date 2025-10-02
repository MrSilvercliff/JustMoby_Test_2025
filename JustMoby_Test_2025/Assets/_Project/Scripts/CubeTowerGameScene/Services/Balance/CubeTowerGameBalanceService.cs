using _Project.Scripts.Project.Services.Balance;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZerglingUnityPlugins.Tools.Scripts.Interfaces.ProjectService.AsyncSync;

namespace _Project.Scripts.CubeTowerGameScene.Services.Balance
{
    public interface ICubeTowerGameBalanceService : IBalanceService
    {
    }

    public class CubeTowerGameBalanceService : BalanceService, ICubeTowerGameBalanceService
    {
        public CubeTowerGameBalanceService()
        {
        }

        protected override HashSet<IProjectService> GetStoragesToInit()
        {
            var result = new HashSet<IProjectService>();
            return result;
        }
    }
}