using _Project.Scripts.CubeTowerGameScene.Configs;
using _Project.Scripts.Project.Balance.Storages;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

namespace _Project.Scripts.CubeTowerGameScene.Services.Balance.Storages
{
    public interface ICubeDragAndDropBalanceStorage : IBalanceStorageScriptableObject
    { 
        float PointerYDeltaToStartDrag { get; }
    }

    public class CubeDragAndDropBalanceStorage : BalanceStorageScriptableObject<ICubeTowerGameBalanceConfig, CubeTowerGameBalanceConfig>, ICubeDragAndDropBalanceStorage
    {
        public float PointerYDeltaToStartDrag => _config.DragAndDropBalanceConfig.PointerYDeltaToStartDrag;

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