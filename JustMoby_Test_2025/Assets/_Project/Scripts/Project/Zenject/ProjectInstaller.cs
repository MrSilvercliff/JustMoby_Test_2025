using _Project.Scripts.Project.Handlers.SceneLoading;
using _Project.Scripts.Project.Services.SceneLoading;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using ZerglingUnityPlugins.Tools.Scripts.Mono;
using ZerglingUnityPlugins.ZenjectExtentions.ContextProvider;

namespace _Project.Scripts.Project.Zenject
{
    public class ProjectInstaller : MonoInstaller
    {
        [SerializeField] private MonoUpdater _monoUpdater;
        [SerializeField] private SceneLoadController _sceneLoadController;

        public override void InstallBindings()
        {
            BindBasicServices();
            BindProjectServices();
        }

        private void BindBasicServices()
        {
            BindZenjectExtensions();

            BindMonoUpdater();

            BindSceneLoadingServices();
        }

        private void BindZenjectExtensions()
        {
            Container.Bind<IZenjectContextProvider>().To<ZenjectContextProvider>().AsSingle();
        }

        private void BindMonoUpdater()
        {
            Container.Bind<IMonoUpdater>().FromInstance(_monoUpdater).AsSingle();
        }

        private void BindSceneLoadingServices()
        {
            Container.Bind<ISceneControllerProvider>().To<SceneControllerProvider>().AsSingle();
            Container.Bind<ISceneLoadHandler>().To<SceneLoadHandler>().AsSingle();
            Container.Bind<ISceneLoadController>().FromInstance(_sceneLoadController).AsSingle();
        }

        private void BindProjectServices()
        {
        }
    }
}