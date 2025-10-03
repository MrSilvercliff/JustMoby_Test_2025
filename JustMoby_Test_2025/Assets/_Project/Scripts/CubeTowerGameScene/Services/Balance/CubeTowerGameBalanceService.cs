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
        ICubeDragAndDropBalanceStorage CubeDragAndDropBalanceStorage { get; }
    }

    public class CubeTowerGameBalanceService : BalanceService, ICubeTowerGameBalanceService
    {
        public ICubeBalanceStorage Cubes => _cubeBalanceStorage;
        public ICubeDragAndDropBalanceStorage CubeDragAndDropBalanceStorage => _cubeDragAndDropBalanceStorage;

        private ICubeBalanceStorage _cubeBalanceStorage;
        private ICubeDragAndDropBalanceStorage _cubeDragAndDropBalanceStorage;

        public CubeTowerGameBalanceService()
        {
            _cubeBalanceStorage = new CubeBalanceStorage();
            _cubeDragAndDropBalanceStorage = new CubeDragAndDropBalanceStorage();
        }

        protected override HashSet<IProjectService> GetStoragesToInit()
        {
            var result = new HashSet<IProjectService>();
            result.Add(_cubeBalanceStorage);
            result.Add(_cubeDragAndDropBalanceStorage);
            return result;
        }
    }
}