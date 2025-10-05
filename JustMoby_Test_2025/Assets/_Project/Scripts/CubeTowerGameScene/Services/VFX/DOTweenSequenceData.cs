using _Project.Scripts.CubeTowerGameScene.Enums;
using _Project.Scripts.CubeTowerGameScene.Services.Balance.Models;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace _Project.Scripts.CubeTowerGameScene.Services.VFX
{
    public interface IDOTweenSequenceData
    { 
        DOTweenSequenceType SequenceType { get; }
    }

    public abstract class DOTweenSequenceData : IDOTweenSequenceData
    {
        public abstract DOTweenSequenceType SequenceType { get; }
    }

    public class CubeDisappearDOTweenSequenceData : DOTweenSequenceData
    {
        public override DOTweenSequenceType SequenceType => DOTweenSequenceType.Cube_Disappear;

        public ICubeBalanceModel CubeBalanceModel { get; private set; }
        public Vector2 EventDataPointerPosition { get; private set; }

        public CubeDisappearDOTweenSequenceData(ICubeBalanceModel cubeBalanceModel, Vector2 eventDataPointerPosition)
        {
            CubeBalanceModel = cubeBalanceModel;
            EventDataPointerPosition = eventDataPointerPosition;
        }

        public class Factory : PlaceholderFactory<ICubeBalanceModel, Vector2, CubeDisappearDOTweenSequenceData> { }
    }
}