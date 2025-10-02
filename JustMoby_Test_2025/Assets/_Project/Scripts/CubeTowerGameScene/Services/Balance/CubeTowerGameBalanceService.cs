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
        public ICubeBalanceStorage Cubes { get; }
    }

    public class CubeTowerGameBalanceService : BalanceService, ICubeTowerGameBalanceService
    {
        public ICubeBalanceStorage Cubes => _cubeBalanceStorage;

        private ICubeBalanceStorage _cubeBalanceStorage;

        public CubeTowerGameBalanceService()
        {
            _cubeBalanceStorage = new CubeBalanceStorage();
        }

        protected override HashSet<IProjectService> GetStoragesToInit()
        {
            var result = new HashSet<IProjectService>();
            result.Add(_cubeBalanceStorage);
            return result;
        }
    }
}