using _Project.Scripts.CubeTowerGameScene.Services.ObjectPools;
using _Project.Scripts.Project.Services;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using Zenject;
using ZerglingUnityPlugins.WindowsManagerAsync.Scripts.Services.Panels;
using ZerglingUnityPlugins.WindowsManagerAsync.Scripts.Services.Popups;
using ZerglingUnityPlugins.WindowsManagerAsync.Scripts.Services.Views;

namespace Assets._Project.Scripts.CubeTowerGameScene.Scene
{
    public interface ICubeTowerGameSceneServiceIniter : IServiceIniter
    { 
    }

    public class CubeTowerGameSceneServiceIniter : ServiceIniter, ICubeTowerGameSceneServiceIniter
    {
        #region First

        // windows
        [Inject] private IViewController _viewController;
        [Inject] private IPopupController _popupController;
        [Inject] private IPanelSettingsRepository _panelSettingsRepository;
        [Inject] private IPanelController _panelController;

        // object pools
        [Inject] private ICubeTowerGameSceneObjectPoolService _cubeTowerGameSceneObjectPoolService;

        #endregion First

        protected override Task<bool> OnInit()
        {
            return Task.FromResult(true);
        }

        public override async Task<bool> InitServices(int stage)
        {
            var result = true;

            switch (stage)
            {
                case 1:
                    result = await InitServicesFirst();
                    break;
            }

            return result;
        }

        private async Task<bool> InitServicesFirst()
        {
            AddService(_viewController);
            AddService(_popupController);
            AddService(_panelSettingsRepository);
            AddService(_panelController);

            AddService(_cubeTowerGameSceneObjectPoolService);

            var result = await InitServices();
            return result;
        }
    }
}