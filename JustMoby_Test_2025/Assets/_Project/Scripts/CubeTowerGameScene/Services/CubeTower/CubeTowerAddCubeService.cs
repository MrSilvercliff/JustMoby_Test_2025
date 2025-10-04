using _Project.Scripts.CubeTowerGameScene.Services.Balance.Models;
using _Project.Scripts.CubeTowerGameScene.Services.ObjectPools;
using _Project.Scripts.CubeTowerGameScene.UI.CubeTower;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace _Project.Scripts.CubeTowerGameScene.Services.CubeTower
{
    public interface ICubeTowerAddCubeService
    { 
        bool TryAddCube(ICubeTowerWidget cubeTowerWidget, ICubeBalanceModel cubeBalanceModel);
    }

    public class CubeTowerAddCubeService : ICubeTowerAddCubeService
    {
        [Inject] private ICubeTowerGameSceneObjectPoolService _objectPoolService;

        public bool TryAddCube(ICubeTowerWidget cubeTowerWidget, ICubeBalanceModel cubeBalanceModel)
        {
            var pool = _objectPoolService.CubeTowerCubeWidgetPool;
            var newCube = pool.Spawn();
            newCube.Setup(cubeBalanceModel);
            cubeTowerWidget.AddCube(newCube);
            return true;
        }
    }
}