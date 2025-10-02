using _Project.Scripts.CubeTowerGameScene.Configs;
using _Project.Scripts.Project.Balance;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

namespace _Project.Scripts.CubeTowerGameScene.Services.Balance.Storages
{
    public interface ICubeTowerGameBalanceStorage : IBalanceStorageScriptableObject
    {
    }

    public class CubeTowerGameBalanceStorage : BalanceStorageScriptableObject<ICubeTowerGameBalanceConfig, CubeTowerGameBalanceConfig>, ICubeTowerGameBalanceStorage
    {
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