using _Project.Scripts.Project.Configs.Windows;
using _Project.Scripts.Project.Handlers.Localization;
using _Project.Scripts.Project.Handlers.SceneLoading;
using _Project.Scripts.Project.Handlers.UI.Panels;
using _Project.Scripts.Project.Handlers.UI.Popups;
using _Project.Scripts.Project.Handlers.UI.Views;
using _Project.Scripts.Project.Services;
using _Project.Scripts.Project.Services.SceneLoading;
using _Project.Scripts.Project.Services.UI.Panels;
using _Project.Scripts.Project.Services.UI.Popups;
using _Project.Scripts.Project.Services.UI.Views;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using ZerglingUnityPlugins.Localization_JSON_Object.Scripts;
using ZerglingUnityPlugins.Localization_Total_JSON.Scripts;
using ZerglingUnityPlugins.Tools.Scripts.Mono;
using ZerglingUnityPlugins.WindowsManagerAsync.Scripts.Configs;
using ZerglingUnityPlugins.WindowsManagerAsync.Scripts.Popups;
using ZerglingUnityPlugins.WindowsManagerAsync.Scripts.Services.Panels;
using ZerglingUnityPlugins.WindowsManagerAsync.Scripts.Services.Popups;
using ZerglingUnityPlugins.WindowsManagerAsync.Scripts.Services.Views;
using ZerglingUnityPlugins.ZenjectExtentions.ContextProvider;

namespace _Project.Scripts.Project.Zenject
{
    public class ProjectInstaller : MonoInstaller
    {
        [SerializeField] private MonoUpdater _monoUpdater;
        [SerializeField] private SceneLoadController _sceneLoadController;

        [Header("VIEWS")]
        [SerializeField] private ViewConfig _viewConfig;
        [SerializeField] private ViewController _viewController;

        [Header("POPUPS")]
        [SerializeField] private PopupConfig _popupConfig;
        [SerializeField] private PopupController _popupController;

        [Header("PANELS")]
        [SerializeField] private PanelConfig _panelConfig;
        [SerializeField] private PanelController _panelController;

        [Header("CONFIGS")]
        [SerializeField] private LocalizationConfig _localizationConfig;

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

            BindViewServices();

            BindPopupServices();

            BindPanelServices();

            BindLocalizationServices();

            BindProjectServiceIniter();
        }

        #region BasicServices

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

        private void BindViewServices()
        {
            Container.Bind<IViewsConfig>().FromInstance(_viewConfig).AsSingle();
            Container.Bind<IViewHandler>().To<ViewHandler>().AsSingle();
            Container.Bind<IViewController>().FromInstance(_viewController).AsSingle();
        }

        private void BindPopupServices()
        {
            Container.BindFactory<PopupWindow, PopupWindow, PopupWindow.Factory>().FromFactory<PopupFactory>();
            Container.Bind<IPopupsConfig>().FromInstance(_popupConfig).AsSingle();
            Container.Bind<IPopupHandler>().To<PopupHandler>().AsSingle();
            Container.Bind<IPopupController>().FromInstance(_popupController).AsSingle();
        }

        private void BindPanelServices()
        {
            Container.Bind<IPanelsConfig>().FromInstance(_panelConfig).AsSingle();
            Container.Bind<IPanelSettingsRepository>().To<PanelSettingsRepository>().AsSingle();
            Container.Bind<IPanelHandler>().To<PanelHandler>().AsSingle();
            Container.Bind<IPanelController>().FromInstance(_panelController).AsSingle();
        }

        private void BindLocalizationServices()
        {
            Container.Bind<ILocalizationConfig>().FromInstance(_localizationConfig).AsSingle();
            Container.Bind<ILocalizationServiceHandler>().To<LocalizationServiceHandler>().AsSingle();
            Container.Bind<ILocalizationService>().To<LocalizationService>().AsSingle();
        }

        private void BindProjectServiceIniter()
        { 
            Container.Bind<IProjectServiceIniter>().To<ProjectServiceIniter>().AsSingle();
        }

        #endregion BasicServices

        private void BindProjectServices()
        {
        }
    }
}