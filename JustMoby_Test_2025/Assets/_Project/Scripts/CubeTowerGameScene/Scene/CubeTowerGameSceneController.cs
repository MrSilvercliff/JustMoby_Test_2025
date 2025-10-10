using _Project.Scripts.CubeTowerGameScene.UI.Windows.Views;
using _Project.Scripts.Project.Scenes;
using _Project.Scripts.Project.Services;
using Assets._Project.Scripts.CubeTowerGameScene.Scene;
using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using Zenject;
using ZerglingUnityPlugins.WindowsManagerAsync.Scripts.Services.Views;

namespace _Project.Scripts.CubeTowerGameScene.Scene
{
    public class CubeTowerGameSceneController : SceneController
    {
        [Inject] private IProjectServiceIniter _projectServiceIniter;
        [Inject] private ICubeTowerGameSceneServiceIniter _serviceIniter;

        [Inject] private IViewController _viewController;

        protected override async Task OnAwake()
        {
            await _projectServiceIniter.Init();
            await _serviceIniter.Init();
        }

        protected override async Task OnStart()
        {
            await _projectServiceIniter.InitServices(0);

            await _serviceIniter.InitServices(1);

            await _serviceIniter.InitServices(2);

            await _viewController.OpenView<GameView>();
        }

        protected override Task OnLateStart()
        {
            return Task.CompletedTask;
        }

        protected override void OnFlush()
        {
            _serviceIniter.Flush();
            _projectServiceIniter.Flush();
        }
    }
}