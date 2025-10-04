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
        float CubeScrollYDeltaToStartDrag { get; }
        float CubeTowerDeltaToStartDrag { get; }
        float CubeTowerDeltaToStartDragSquared { get; }
    }

    public class CubeDragAndDropBalanceStorage : BalanceStorageScriptableObject<ICubeTowerGameBalanceConfig, CubeTowerGameBalanceConfig>, ICubeDragAndDropBalanceStorage
    {
        public float CubeScrollYDeltaToStartDrag => _config.DragAndDropBalanceConfig.CubeScrollPointerYDeltaToStartDrag;
        public float CubeTowerDeltaToStartDrag => _config.DragAndDropBalanceConfig.CubeTowerDeltaToStartDrag;
        public float CubeTowerDeltaToStartDragSquared => _cubeTowerDeltaToStartDragSquared;

        private float _cubeTowerDeltaToStartDragSquared;

        protected override Task<bool> OnInit()
        {
            _cubeTowerDeltaToStartDragSquared = CubeTowerDeltaToStartDrag * CubeTowerDeltaToStartDrag;
            return Task.FromResult(true);
        }

        protected override bool OnFlush()
        {
            return true;
        }
    }
}