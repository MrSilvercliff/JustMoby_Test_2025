using _Project.Scripts.CubeTowerGameScene.UI.Cubes;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;
using ZerglingUnityPlugins.WindowsManagerAsync.Scripts.Views;

namespace _Project.Scripts.CubeTowerGameScene.UI.Windows.Views
{
    public struct TestStruct
    { 
    }

    public class GameView : ViewWindowWithSafeArea
    {
        [SerializeField] private CubeScrollWidget _cubeScrollWidget;
        [SerializeField] private GameDragAndDropPanel _gameDragAndDropPanel;

        protected override async Task<bool> OnInit()
        {
            await base.OnInit();
            _cubeScrollWidget.Init();
            _gameDragAndDropPanel.Init();
            return true;
        }

        protected override Task OnPreOpen()
        {
            _cubeScrollWidget.SpawnCubeWidgets();
            _gameDragAndDropPanel.Activate();
            return Task.CompletedTask;
        }

        protected override Task OnPreClose()
        {
            _gameDragAndDropPanel.Deactivate();
            return Task.CompletedTask;
        }
    }
}