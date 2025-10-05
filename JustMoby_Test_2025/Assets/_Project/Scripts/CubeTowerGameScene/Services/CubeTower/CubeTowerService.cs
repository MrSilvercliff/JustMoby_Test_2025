using _Project.Scripts.CubeTowerGameScene.Services.Balance.Models;
using _Project.Scripts.CubeTowerGameScene.UI.CubeTower;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using Zenject;
using ZerglingUnityPlugins.Tools.Scripts.Interfaces.ProjectService.AsyncSync;

namespace _Project.Scripts.CubeTowerGameScene.Services.CubeTower
{
    public interface ICubeTowerService : IProjectService
    {
        bool TryGetCubeTowerByCubeWidget(CubeTowerCubeWidget cubeWidget, out ICubeTowerWidget cubeTowerWidget);
        bool TryBuildTower(Transform cubeTowerContainer, ICubeBalanceModel cubeBalanceModel);
        bool TryAddCube(ICubeTowerWidget cubeTower, ICubeBalanceModel cubeBalanceModel);
        void RemoveCube(ICubeTowerWidget cubeTower, CubeTowerCubeWidget cubeWidget);
    }

    public class CubeTowerService : ICubeTowerService
    {
        [Inject] private ICubeTowerRepository _repository;
        [Inject] private ICubeTowerBuildService _buildService;
        [Inject] private ICubeTowerAddCubeService _addCubeService;

        public Task<bool> Init()
        {
            return Task.FromResult(true);
        }

        public bool Flush()
        {
            return true;
        }

        public bool TryGetCubeTowerByCubeWidget(CubeTowerCubeWidget cubeWidget, out ICubeTowerWidget cubeTowerWidget)
        {
            var result = _repository.TryGetCubeTowerByCubeWidget(cubeWidget, out cubeTowerWidget);
            return result;
        }

        public bool TryBuildTower(Transform cubeTowerContainer, ICubeBalanceModel cubeBalanceModel)
        {
            var result = _buildService.TryBuildTower(cubeTowerContainer, out var cubeTowerWidget);

            if (!result)
                return result;

            result = _addCubeService.TryAddCube(cubeTowerWidget, cubeBalanceModel);
            return result;
        }

        public bool TryAddCube(ICubeTowerWidget cubeTowerWidget, ICubeBalanceModel cubeBalanceModel)
        {
            var result = _addCubeService.TryAddCube(cubeTowerWidget, cubeBalanceModel);
            return result;
        }

        public void RemoveCube(ICubeTowerWidget cubeTower, CubeTowerCubeWidget cubeWidget)
        {
            _addCubeService.RemoveCube(cubeTower, cubeWidget);

            if (cubeTower.CubeCount > 0)
                return;

            _buildService.DestroyTower(cubeTower);
        }
    }
}