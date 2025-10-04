using _Project.Scripts.CubeTowerGameScene.Services.Balance.Models;
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
        bool TryBuildTower(Transform cubeTowerContainer, ICubeBalanceModel cubeBalanceModel);
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

        public bool TryBuildTower(Transform cubeTowerContainer, ICubeBalanceModel cubeBalanceModel)
        {
            var result = _buildService.TryBuildTower(cubeTowerContainer, out var cubeTowerWidget);

            if (!result)
                return result;

            result = _addCubeService.TryAddCube(cubeTowerWidget, cubeBalanceModel);
            return result;
        }
    }
}