using _Project.Scripts.CubeTowerGameScene.Services.Balance.Models;
using _Project.Scripts.CubeTowerGameScene.Services.ObjectPools;
using _Project.Scripts.CubeTowerGameScene.UI.CubeTower;
using _Project.Scripts.Project.Camera;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using ZerglingUnityPlugins.Tools.Scripts.Log;

namespace _Project.Scripts.CubeTowerGameScene.Services.CubeTower
{
    public interface ICubeTowerAddCubeService
    { 
        bool CanAddCube(ICubeTowerWidget cubeTowerWidget);
        bool TryAddCube(ICubeTowerWidget cubeTowerWidget, ICubeBalanceModel cubeBalanceModel);
        void RemoveCube(ICubeTowerWidget cubeTowerWidget, CubeTowerCubeWidget cubeWidget);
    }

    public class CubeTowerAddCubeService : ICubeTowerAddCubeService
    {
        [Inject] private ICameraController _cameraController;
        [Inject] private ICubeTowerGameSceneObjectPoolService _objectPoolService;

        public bool CanAddCube(ICubeTowerWidget cubeTowerWidget)
        {
            var checkScreenHeightResult = CanAddCubeCheckScreenHeight(cubeTowerWidget);
            var checkAddingRestrictionsResult = CanAddCubeCheckAddingRestriction();
            var result = checkScreenHeightResult && checkAddingRestrictionsResult;
            return result;
        }

        private bool CanAddCubeCheckScreenHeight(ICubeTowerWidget cubeTowerWidget)
        {
            var topAnchor = cubeTowerWidget.CubeContainerTopAnchor;
            var topAnchorScreenPos = _cameraController.Camera.WorldToScreenPoint(topAnchor.position);
            var result = topAnchorScreenPos.y < Screen.height;

            /*
            Debug.LogError($"====================");
            Debug.LogError($"Scree = {Screen.width}x{Screen.height} ; Safe Area = {Screen.safeArea.size}");
            Debug.LogError($"top cube top anchor screen pos = {topAnchorScreenPos}");
            Debug.LogError($"result = {result}");
            */

            return result;
        }

        private bool CanAddCubeCheckAddingRestriction()
        {
            // check some adding restrictions
            return true;
        }

        public bool TryAddCube(ICubeTowerWidget cubeTowerWidget, ICubeBalanceModel cubeBalanceModel)
        {
            var canAdd = CanAddCube(cubeTowerWidget);

            if (!canAdd)
                return false;

            var pool = _objectPoolService.CubeTowerCubeWidgetPool;
            var newCube = pool.Spawn();
            newCube.Setup(cubeBalanceModel);
            cubeTowerWidget.AddCube(newCube);
            return true;
        }

        public void RemoveCube(ICubeTowerWidget cubeTowerWidget, CubeTowerCubeWidget cubeWidget)
        {
            cubeTowerWidget.RemoveCube(cubeWidget);
            var pool = _objectPoolService.CubeTowerCubeWidgetPool;
            pool.Despawn(cubeWidget);
        }
    }
}