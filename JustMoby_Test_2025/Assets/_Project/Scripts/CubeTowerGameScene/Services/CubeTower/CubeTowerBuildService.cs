using _Project.Scripts.CubeTowerGameScene.Services.ObjectPools;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace _Project.Scripts.CubeTowerGameScene.Services.CubeTower
{
    public interface ICubeTowerBuildService
    {
        bool TryBuildTower();
    }

    public class CubeTowerBuildService : ICubeTowerBuildService
    {
        [Inject] private ICubeTowerGameSceneObjectPoolService _objectPoolService;

        public bool TryBuildTower()
        {
            return true;
        }
    }
}