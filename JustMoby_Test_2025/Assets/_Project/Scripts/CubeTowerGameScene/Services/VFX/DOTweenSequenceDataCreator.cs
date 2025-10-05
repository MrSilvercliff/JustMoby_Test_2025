using _Project.Scripts.CubeTowerGameScene.Services.Balance.Models;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace _Project.Scripts.CubeTowerGameScene.Services.VFX
{
    public interface IDOTweenSequenceDataCreator
    {
        IDOTweenSequenceData CreateSequenceData(ICubeBalanceModel cubeBalanceModel, Vector2 eventDataPointerPosition);
    }

    public class DOTweenSequenceDataCreator : IDOTweenSequenceDataCreator
    {
        [Inject] private CubeDisappearDOTweenSequenceData.Factory _cubeDisappearFactory;

        public IDOTweenSequenceData CreateSequenceData(ICubeBalanceModel cubeBalanceModel, Vector2 eventDataPointerPosition)
        {
            var result = _cubeDisappearFactory.Create(cubeBalanceModel, eventDataPointerPosition);
            return result;
        }
    }
}