using _Project.Scripts.BrickTowerGameScene.Configs;
using _Project.Scripts.Project.Balance;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

namespace _Project.Scripts.BrickTowerGameScene.Services.Balance.Storages
{
    public interface IBrickTowerGameBalanceStorage : IBalanceStorageScriptableObject
    { 
    }

    public class BrickTowerGameBalanceStorage : BalanceStorageScriptableObject<IBrickTowerGameBalanceConfig, BrickTowerGameBalanceConfig>, IBrickTowerGameBalanceStorage
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