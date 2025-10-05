using _Project.Scripts.CubeTowerGameScene.Configs;
using _Project.Scripts.Project.Balance.Storages;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

namespace _Project.Scripts.CubeTowerGameScene.Services.Balance.Storages
{
    public interface ICubeTowerBuildBalanceStorage : IBalanceStorageScriptableObject
    { 
        int MaxActiveTowerCount { get; }
    }

    public class CubeTowerBuildBalanceStorage : BalanceStorageScriptableObject<ICubeTowerGameBalanceConfig, CubeTowerGameBalanceConfig>, ICubeTowerBuildBalanceStorage
    {
        public int MaxActiveTowerCount => _config.TowerBuildBalanceConfig.MaxActiveTowerCount;

        protected override Task<bool> OnInit()
        {
            return Task.FromResult(true);
        }

        protected override bool OnFlush()
        {
            return true;
        }
    }
}