using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using Zenject;
using ZerglingUnityPlugins.Tools.Scripts.Mono;
using ZerglingUnityPlugins.WindowsManagerAsync.Scripts.Panels;

namespace _Project.Scripts.CubeTowerGameScene.UI.Windows.Panels
{
    public class DOTweenVFXPanel : PanelWindowWithSafeArea, IMonoLateUpdatable
    {
        [Inject] private IMonoUpdater _monoUpdater;

        protected override Task OnPreOpen()
        {
            _monoUpdater.Subscribe(this);
            return Task.CompletedTask;
        }

        protected override Task OnPreClose()
        {
            _monoUpdater.UnSubscribe(this);
            return Task.CompletedTask;
        }

        public void OnLateUpdate()
        {
            
        }
    }
}