using _Project.Scripts.CubeTowerGameScene.Services.Balance.Storages;
using _Project.Scripts.Project.Services.Balance;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using ZerglingUnityPlugins.Tools.Scripts.Interfaces.ProjectService.AsyncSync;

namespace _Project.Scripts.CubeTowerGameScene.Services.Balance
{
    public interface ICubeTowerGameBalanceService : IBalanceService
    {
        ICubeBalanceStorage Cubes { get; }
        ICubeDragAndDropBalanceStorage CubeDragAndDrop{ get; }
        ICubeTowerBuildBalanceStorage CubeTowerBuild { get; }
    }

    public class CubeTowerGameBalanceService : BalanceService, ICubeTowerGameBalanceService
    {
        public ICubeBalanceStorage Cubes => _cubeBalanceStorage;
        public ICubeDragAndDropBalanceStorage CubeDragAndDrop => _cubeDragAndDropBalanceStorage;
        public ICubeTowerBuildBalanceStorage CubeTowerBuild => _cubeTowerBuildBalanceStorage;

        private ICubeBalanceStorage _cubeBalanceStorage;
        private ICubeDragAndDropBalanceStorage _cubeDragAndDropBalanceStorage;
        private ICubeTowerBuildBalanceStorage _cubeTowerBuildBalanceStorage;

        public CubeTowerGameBalanceService()
        {
            _cubeBalanceStorage = new CubeBalanceStorage();
            _cubeDragAndDropBalanceStorage = new CubeDragAndDropBalanceStorage();
            _cubeTowerBuildBalanceStorage = new CubeTowerBuildBalanceStorage();
        }

        protected override HashSet<IProjectService> GetStoragesToInit()
        {
            var result = new HashSet<IProjectService>();
            result.Add(_cubeBalanceStorage);
            result.Add(_cubeDragAndDropBalanceStorage);
            result.Add(_cubeTowerBuildBalanceStorage);
            return result;
        }
    }
}