using _Project.Scripts.CubeTowerGameScene.Configs;
using _Project.Scripts.CubeTowerGameScene.Scene;
using _Project.Scripts.CubeTowerGameScene.Services.Balance;
using _Project.Scripts.CubeTowerGameScene.UI.Cubes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using ZerglingUnityPlugins.ZenjectExtentions.SceneInstallers;

namespace _Project.Scripts.CubeTowerGameScene.Zenject
{
    public class CubeTowerGameSceneInstaller : SceneInstallerBasic
    {
        [SerializeField] private CubeTowerGameSceneObjectPoolContainer _objectPoolContainer;
        [SerializeField] private CubeTowerGameBalanceConfig _balanceConfig;

        public override void InstallBindings()
        {
            BindObjectPools();

            BindBalanceServices();
        }

        private void BindBalanceServices()
        {
            Container.Bind<ICubeTowerGameBalanceConfig>().FromInstance(_balanceConfig).AsSingle();
            Container.Bind<ICubeTowerGameBalanceService>().To<CubeTowerGameBalanceService>().AsSingle();
        }

        private void BindObjectPools()
        {
            BindCubeWidgetObjectPool();
        }

        private void BindCubeWidgetObjectPool()
        {
            var poolItem = _objectPoolContainer.CubeWidget;

            var prefab = poolItem.Prefab;
            var container = poolItem.Container;
            var poolInitSize = poolItem.PoolInitialSize;

            Container.BindMemoryPool<CubeWidget, CubeWidget.Pool>()
                .WithInitialSize(poolInitSize)
                .FromComponentInNewPrefab(prefab)
                .UnderTransform(container);
        }
    }
}