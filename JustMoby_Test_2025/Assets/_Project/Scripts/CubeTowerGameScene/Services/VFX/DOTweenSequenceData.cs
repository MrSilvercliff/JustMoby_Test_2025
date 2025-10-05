using _Project.Scripts.CubeTowerGameScene.Enums;
using _Project.Scripts.CubeTowerGameScene.Services.Balance.Models;
using _Project.Scripts.CubeTowerGameScene.UI.CubeDeleteHole;
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

    public class CubeMoveToHoleDOTweenSequenceData : DOTweenSequenceData
    {
        public override DOTweenSequenceType SequenceType => DOTweenSequenceType.Cube_Move_To_Hole;

        public ICubeDeleteHoleWidget CubeDeleteHoleWidget { get; private set; }
        public ICubeBalanceModel CubeBalanceModel { get; private set; }
        public Vector3 StartWorldPosition { get; private set; }

        public CubeMoveToHoleDOTweenSequenceData(ICubeDeleteHoleWidget cubeDeleteHoleWidget, ICubeBalanceModel cubeBalanceModel, Vector3 startWorldPosition)
        {
            CubeDeleteHoleWidget = cubeDeleteHoleWidget;
            CubeBalanceModel = cubeBalanceModel;
            StartWorldPosition = startWorldPosition;
        }

        public class Factory : PlaceholderFactory<ICubeDeleteHoleWidget, ICubeBalanceModel, Vector3, CubeMoveToHoleDOTweenSequenceData> { }
    }

    public class ShowTextDOTweenSequenceData : DOTweenSequenceData
    {
        public override DOTweenSequenceType SequenceType => DOTweenSequenceType.Show_Text;

        public string TextLocalizationKey { get; private set; }

        public ShowTextDOTweenSequenceData(string textLocalizationKey)
        {
            TextLocalizationKey = textLocalizationKey;
        }

        public class Factory : PlaceholderFactory<string, ShowTextDOTweenSequenceData> { }
    }
}