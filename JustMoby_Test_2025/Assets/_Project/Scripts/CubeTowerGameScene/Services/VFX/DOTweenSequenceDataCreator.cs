using _Project.Scripts.CubeTowerGameScene.Services.Balance.Models;
using _Project.Scripts.CubeTowerGameScene.UI.CubeDeleteHole;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using Zenject;
using ZerglingUnityPlugins.Tools.Scripts.Interfaces.ProjectService.AsyncSync;

namespace _Project.Scripts.CubeTowerGameScene.Services.VFX
{
    public interface IDOTweenSequenceDataCreator : IProjectService
    {
        IDOTweenSequenceData CreateSequenceData(ICubeBalanceModel cubeBalanceModel, Vector2 eventDataPointerPosition);
        IDOTweenSequenceData CreateSequenceData(ICubeDeleteHoleWidget cubeDeleteHoleWidget, ICubeBalanceModel cubeBalanceModel, Vector3 startWorldPosition);
        IDOTweenSequenceData CreateSequenceData(string textLocaleKey);
    }

    public class DOTweenSequenceDataCreator : IDOTweenSequenceDataCreator
    {
        [Inject] private CubeDisappearDOTweenSequenceData.Factory _cubeDisappearFactory;
        [Inject] private CubeMoveToHoleDOTweenSequenceData.Factory _cubeMoveToHoleFactory;
        [Inject] private ShowTextDOTweenSequenceData.Factory _showTextFactory;

        public Task<bool> Init()
        {
            return Task.FromResult(true);
        }

        public bool Flush()
        {
            return true;
        }

        public IDOTweenSequenceData CreateSequenceData(ICubeBalanceModel cubeBalanceModel, Vector2 eventDataPointerPosition)
        {
            var result = _cubeDisappearFactory.Create(cubeBalanceModel, eventDataPointerPosition);
            return result;
        }

        public IDOTweenSequenceData CreateSequenceData(ICubeDeleteHoleWidget cubeDeleteHoleWidget, ICubeBalanceModel cubeBalanceModel, Vector3 startWorldPosition)
        {
            var result = _cubeMoveToHoleFactory.Create(cubeDeleteHoleWidget, cubeBalanceModel, startWorldPosition);
            return result;
        }

        public IDOTweenSequenceData CreateSequenceData(string textLocaleKey)
        {
            var result = _showTextFactory.Create(textLocaleKey);
            return result;
        }
    }
}