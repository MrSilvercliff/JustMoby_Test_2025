using _Project.Scripts.CubeTowerGameScene.Enums;
using _Project.Scripts.CubeTowerGameScene.Services.VFX;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using Zenject;
using ZerglingUnityPlugins.Tools.Scripts.Log;
using ZerglingUnityPlugins.Tools.Scripts.Mono;
using ZerglingUnityPlugins.WindowsManagerAsync.Scripts.Panels;

namespace _Project.Scripts.CubeTowerGameScene.UI.Windows.Panels
{
    public class DOTweenVFXPanel : PanelWindowWithSafeArea, IMonoLateUpdatable
    {
        [SerializeField] private CubeDisappearDOTweenPanel _cubeDisappearPanel;
        [SerializeField] private CubeMoveToHoleDOTweenPanel _cubeMoveToHolePanel;
        [SerializeField] private ShowTextDOTweenPanel _showTextPanel;

        [Inject] private IMonoUpdater _monoUpdater;
        [Inject] private IDOTweenSequenceService _sequenceService;

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
            var sequenceDatas = _sequenceService.GetSequenceDatas();
            var playResult = false;

            foreach (var sequenceData in sequenceDatas)
            {
                var sequenceType = sequenceData.SequenceType;

                switch (sequenceType)
                {
                    case DOTweenSequenceType.Cube_Disappear:
                        playResult = _cubeDisappearPanel.PlaySequence(sequenceData);
                        break;

                    case DOTweenSequenceType.Cube_Move_To_Hole:
                        playResult = _cubeMoveToHolePanel.PlaySequence(sequenceData);
                        break;

                    case DOTweenSequenceType.Show_Text:
                        playResult = _showTextPanel.PlaySequence(sequenceData);
                        break;

                    default:
                        LogUtils.Error(this, $"Play sequence does not implemented for [{sequenceType}]!");
                        break;
                }
            }

            _sequenceService.Clear();
        }
    }
}