using _Project.Scripts.CubeTowerGameScene.Configs;
using _Project.Scripts.CubeTowerGameScene.Services.Balance.Models;
using _Project.Scripts.Project.Balance.Storages;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using ZerglingUnityPlugins.Tools.Scripts.Log;

namespace _Project.Scripts.CubeTowerGameScene.Services.Balance.Storages
{
    public interface ICubeBalanceStorage : IBalanceStorageScriptableObject
    {
        bool TryGetCubeBalanceModel(string id, out ICubeBalanceModel cubeBalanceModel);
        IReadOnlyCollection<string> GetActiveCubeBalanceModels();
    }

    public class CubeBalanceStorage : BalanceStorageScriptableObject<ICubeTowerGameBalanceConfig, CubeTowerGameBalanceConfig>, ICubeBalanceStorage
    {
        private Dictionary<string, ICubeBalanceModel> _allCubesBalanceModels;

        public CubeBalanceStorage()
        {
            _allCubesBalanceModels = new();
        }

        protected override Task<bool> OnInit()
        {
            InitCubeBalanceModels();
            return Task.FromResult(true);
        }

        protected override bool OnFlush()
        {
            return true;
        }

        private void InitCubeBalanceModels()
        {
            var cubeConfigItems = _config.CubeBalanceConfig.AllCubeItems;

            foreach (var cubeConfigItem in cubeConfigItems)
            {
                var model = new CubeBalanceModel();
                model.Setup(cubeConfigItem);
                _allCubesBalanceModels[model.ID] = model;
            }
        }

        public bool TryGetCubeBalanceModel(string id, out ICubeBalanceModel cubeBalanceModel)
        {
            var result = _allCubesBalanceModels.TryGetValue(id, out cubeBalanceModel);

            if (!result)
                LogUtils.Error(this, $"Cube balance model with ID [{id}] DOES NOT EXIST!");

            return result;
        }

        public IReadOnlyCollection<string> GetActiveCubeBalanceModels()
        {
            var result = _config.CubeBalanceConfig.ActiveCubeItems;
            return result;
        }
    }
}